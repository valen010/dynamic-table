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
    public class RecordController : ControllerBase
    {
        protected IRepository<Record> _repository;
        protected IRecord _record;
        public RecordController(IRepository<Record> repository, IRecord record)
        {
            _repository = repository;
            _record = record;
        }
        [HttpGet]
        public async Task<IActionResult> GetColumns()
        {
            var list = await _repository.GetAll();
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddRecord( Record record)
        {
            var response = await _repository.Insert(record);
            return Ok(response);

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var response = await _repository.Delete(id);

            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRecord([FromQuery] Record record)
        {
            var response = await _repository.Update(record);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _repository.GetById(id);

            return Ok(response);
        }
    }
}
