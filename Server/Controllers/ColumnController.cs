using DataAccessLayer.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class ColumnController : ControllerBase
    {
        protected IRepository<Column> _repository;
        protected IColumns _columns;
        protected CoreDbContext _ctx;
        protected ITableview _tableView;
        protected IValues _values;
      

        public ColumnController(IRepository<Column> repository, IColumns columns,ITableview tableview,IValues values,CoreDbContext ctx)
        {

            _columns = columns;
            _repository = repository;
            _tableView = tableview;
            _ctx = ctx;
            _values = values;
        }
        [HttpGet]
        public async Task<List<Column>> GetAllColumns()
        {
           var result=await _columns.GetAllColumns();
            return result;
        }
        [HttpGet]
        public async Task<List<Column>> GetAll()
        {
            var result = await _repository.GetAll();
            var query = result.OrderBy(x => x.Order);
            return query.ToList();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<List<TableView>> GetVisibleColumns()
        {
            var list = await _columns.GetVisibleColumns();
            return list;
        }
        [HttpPost]
        public async Task<IActionResult> AddColumn([FromBody] Column column)
        {
            var response = await _repository.Insert(column);
            return Ok(response);
        }
        
        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _repository.Delete(Id);
            return Ok(result);
        }
      
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateColumns(int id,Column column)
        {
        
            var result = await _columns.UpdateColumns(id,column);
            return Ok(result);
        }
        [HttpPut("{id:int}")] 
        public async Task<IActionResult> UpdateRecord(int id, Column column)
        {
            var list = _ctx.Find<Column>(id);
            list.IsVisible = column.IsVisible;
            list.Name = column.Name;
            list.Order = column.Order;
           

            
           var result=await  _ctx.SaveChangesAsync();
            return Ok(result);
            /*var result = await _repository.Update(column);
            return Ok(result);*/
        }
        [HttpGet]
        public async Task<List<TableView>> TableView()
        {
            var result= await _columns.TableView();
            return result;
        }
    }
}
