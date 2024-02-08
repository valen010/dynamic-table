using DataAccessLayer.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TableViewController : ControllerBase
    {
        protected CoreDbContext _ctx;
        protected IRepository<TableView> _repo;
        protected ITableview _tbView;


        public TableViewController(IRepository<TableView> repo, ITableview tbView)
        {
            _repo = repo;
            _tbView = tbView;
        }
        [HttpGet]
        public async Task<Dictionary<Column,Value>> GetTableView()
        {
            var list =await _tbView.Tableview();
            return list;
        }
      




    }
}
