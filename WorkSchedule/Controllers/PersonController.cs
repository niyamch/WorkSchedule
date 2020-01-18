using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using WorkSchedule.Models.Person;

namespace WorkSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : BaseController<Person, PersonFormViewModel, PersonListViewModel,PersonNameViewModel>
    {
        public PersonController(IMapper mapper, IPersonService service) 
            : base(mapper,service)
        { }

        [HttpGet]

        public override ActionResult<List<PersonNameViewModel>> Get()
        {
            return base.Get();
        }

        [HttpGet("{id}")]
        public override IActionResult Get(int id)
        {
            return base.Get(id);
        }

        [HttpPost]
        public override IActionResult Create([FromBody]PersonFormViewModel formModel)
        {
            return base.Create(formModel);
        }

        [HttpDelete("{id}")]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [HttpPut]
        public override IActionResult Update(int id, [FromBody]PersonFormViewModel viewModel)
        {
            return base.Update(id, viewModel);
        }
    }
}