using DataAccess.Entities;
using DataAccess.Repositories.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Services.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Context;
using Service.Helpers;

namespace Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration configuration;
        private readonly IUserService service;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDistributedCache cache;

        public AuthenticationService(
            IConfiguration configuration,
            IUserService service,
            IHttpContextAccessor httpContextAccessor,
            IDistributedCache cache
            )
        {
            this.configuration = configuration;
            this.service = service;
            this.httpContextAccessor = httpContextAccessor;
            this.cache = cache;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            WorkScheduleContext context = new WorkScheduleContext();
            RoleRepository roleRepository = new RoleRepository(context);
            RoleService roleService = new RoleService(roleRepository);
            var expires = DateTime.Now.AddMinutes(30);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim(ClaimTypes.Role, roleService.GetById(user.RoleId).Name)
            };
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Issuer"],
                claims: claims,
                expires: expires,
                signingCredentials: credentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        public int GetUserId()
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(GetCurrentToken()) as JwtSecurityToken;
            return int.Parse(token.Claims.First(c => c.Type == "jti").Value);
        }

        private string GetCurrentToken()
        {
            var authorizationHeader = httpContextAccessor
                .HttpContext.Request.Headers["Authorization"];
            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(" ").Last();
        }

        public async Task<bool> IsActive(string token) 
            => await cache.GetStringAsync(GetTokenKey(token)) == null;

        private static string GetTokenKey(string token)
            => $"tokens:{token}:deactivated";

        public User IsAuthenticated(string email, string password)
        {
            var user = service.GetByEmail(email);
            if (user != null)
            {
                bool credentials = PasswordHasher.VerifyHash(password, user.Password);
                if (!credentials)
                {
                    user = null;
                }
            }
            return user;
        }

        public async Task<bool> IsCurrentActiveToken() => await IsActive(GetCurrentToken());

        public bool VerifySignedJwt(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            }, out var parsedToken);
            return claimsPrincipal.Identity.IsAuthenticated;
        }
    }

}
