using ApiJul.Models;
using ApiJul.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJul.Controllers
{
    public class BaseController<T> : ControllerBase where T : IModele
    {
        protected IRepository<T> _repo;
        protected string baseUrl;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.Get());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id)
        {
            if (_repo.Get(id) == null) return NotFound($"Object with id {id} was not found.");

            return Ok(_repo.Get(id));
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] T value)
        {
            var validateData = value.Validate();
            if (validateData.Any()) return BadRequest($"Invalid data : {string.Join(" ", validateData)}");

            value.Id = Guid.Empty;
            var cust = _repo.Create(value);
            return Created(string.Format(baseUrl, cust.Id), cust);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put(Guid id, [FromBody] T value)
        {
            if (_repo.Get(id) == null) return NotFound($"Object with id {id} was not found.");

            var validateData = value.Validate();
            if (validateData.Any()) return BadRequest($"Invalid data : {string.Join(" ", validateData)}");

            value.Id = id;
            var cust = _repo.Update(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual void Delete(Guid id)
        {
            _repo.Delete(id);
        }
    }
}
