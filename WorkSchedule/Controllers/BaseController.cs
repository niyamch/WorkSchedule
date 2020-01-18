using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WorkSchedule.Models;
using Service.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace WorkSchedule.Controllers
{
    [Route("api/controller")]
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseController<TEntity,TFormViewModel,TListViewModel,TNameViewModel>
        : Controller
        where TEntity : BaseEntity, new()
        where TFormViewModel : FormViewModel
        where TListViewModel : ListViewModel
        where TNameViewModel : ListViewModel
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseService<TEntity> _service;

        public BaseController(IMapper mapper, IBaseService<TEntity> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public virtual ActionResult<List<TNameViewModel>> Get()
        {
            var items = _service.GetAll().ToList();
            if(items.Count <= 0)
            {
                return NoContent();
            }
            var mappedItems = _mapper.Map<List<TEntity>, List<TNameViewModel>>(items);
            return mappedItems;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ListViewModel),200)]
        [ProducesResponseType(404)]
        public virtual IActionResult Get(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            var mappedItem = _mapper.Map<TListViewModel>(item);
            return Ok(mappedItem);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ListViewModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        //[Authorize]
        public virtual IActionResult Create([FromBody]TFormViewModel formModel)
        {
            if(formModel == null)
            {
                return BadRequest();
            }
            var item = _mapper.Map(formModel, new TEntity());
            if(!_service.Create(item))
            {
                return BadRequest();
            }
            ListViewModel viewModel = _mapper.Map<TListViewModel>(item);
            return CreatedAtAction("Get", new { id = viewModel.Id }, viewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        //[Authorize]
        public virtual IActionResult Update(int id, [FromBody] TFormViewModel formModel)
        {
            if(formModel == null)
            {
                return BadRequest();
            }
            TEntity item = _service.GetById(id);
            if(item == null)
            {
                return NotFound();
            }
            _mapper.Map(formModel, item);
            if(!_service.Update(item))
            {
                return Conflict();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
       // [Authorize]
        public virtual IActionResult Delete(int id)
        {
            var item = _service.GetById(id);
            if(item == null)
            {
                return NotFound();
            }
            if(!_service.Delete(id))
            {
                return Conflict();
            }
            return Ok();
        }
    }
}
