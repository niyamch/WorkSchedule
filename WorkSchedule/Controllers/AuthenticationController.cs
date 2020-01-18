using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using WorkSchedule.Models.Authentication;
using Service.Authentication;
using Service.Helpers;

namespace WorkSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private IMapper mapper;
        private IUserService userService;
        private readonly IAuthenticationService authService;
        private IRoleService roleService;
        public AuthenticationController(IMapper mapper,
            IUserService userService,
            IAuthenticationService authService,
            IRoleService roleService
            )
        {
            this.mapper = mapper;
            this.userService = userService;
            this.authService = authService;
            this.roleService = roleService;
        }

        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Register([FromBody]RegisterViewModel model)
        {
            if (model == null)
            {
                return BadRequest("No parameters given.");
            }
            if (userService.GetByEmail(model.Email) != null)
            {
                return BadRequest("Email already exists.");
            }

            var role = roleService.GetByName("ROLE_USER");
            var user = mapper.Map(model, new User());
            user.RoleId = role.Id;

            user.Password = PasswordHasher.ComputeHash(model.Password, null);

            if (!userService.Create(user))
            {
                return Conflict("An error has occured! Could not register the user!");
            }

            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            User user = authService.IsAuthenticated(model.Email, model.Password);
            if (user == null)
            {
                return NotFound("Wrong Email/password or user not existing.");
            }

            var token = authService.GenerateToken(user);
            if (!authService.VerifySignedJwt(token))
            {
                return BadRequest();
            }

            return Ok("Bearer " + token);
        }
    }
}
