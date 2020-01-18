using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSchedule.Models.Position;

namespace WorkSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PositionController : BaseController<Position, PositionFormViewModel, PositionListViewModel, PositionNameViewModel>
    {
        public PositionController(IMapper mapper, IPositionService service)
            : base(mapper, service)
        { }

        [HttpGet]
        public override ActionResult<List<PositionNameViewModel>> Get()
        {
            return base.Get();
        }

        [HttpGet("{id}")]
        public override IActionResult Get(int id)
        {
            return base.Get(id);
        }

        [HttpPost]
        public override IActionResult Create([FromBody]PositionFormViewModel formModel)
        {
            return base.Create(formModel);
        }

        [HttpDelete("{id}")]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [HttpPut]
        public override IActionResult Update(int id, [FromBody]PositionFormViewModel viewModel)
        {
            return base.Update(id, viewModel);
        }
    }
}
