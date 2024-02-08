using DataAccessLayer.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ValueController : ControllerBase
    {
        protected IRepository<Value> _repository;
        protected IValues _value;
        public ValueController(IRepository<Value> repository, IValues values)
        {
            _repository = repository;
            _value = values;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _repository.GetAll();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return Ok(result);
        }
      

        [HttpPost]
        public async Task<IActionResult> AddValue([FromBody] Value value)
        {
            var result = await _repository.Insert(value);
            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,Value value)
        {
            var result = await _value.UpdateValue(id,value);
            return Ok(result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return Ok(result);
            
        }
        [HttpGet]
        public async Task<List<Value>> TableView()
        {
            var response = await _value.TableView();
            return response.ToList();
        }

    }
}
