using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using System.Collections.Generic;
using WorkSchedule.Models.ShiftType;

namespace WorkSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ShiftTypeController : BaseController<ShiftType, ShiftTypeFormViewModel, ShiftTypeListViewModel, ShiftTypeNameViewModel>
    {
        public ShiftTypeController(IMapper mapper, IShiftTypeService service)
            : base(mapper, service)
        { }

        [HttpGet]
        public override ActionResult<List<ShiftTypeNameViewModel>> Get()
        {
            return base.Get();
        }

        [HttpGet("{id}")]
        public override IActionResult Get(int id)
        {
            return base.Get(id);
        }

        [HttpPost]
        public override IActionResult Create([FromBody]ShiftTypeFormViewModel formModel)
        {
            return base.Create(formModel);
        }

        [HttpDelete("{id}")]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [HttpPut]
        public override IActionResult Update(int id, [FromBody]ShiftTypeFormViewModel viewModel)
        {
            return base.Update(id, viewModel);
        }
    }
}
