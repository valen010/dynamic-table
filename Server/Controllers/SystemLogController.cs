using DataAccessLayer.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SystemLogController : ControllerBase
    {
            protected IRepository<SystemLog> _repository;
        protected IsystemLogs _syslog;
            protected CoreDbContext _ctx;

            public SystemLogController(IRepository<SystemLog> repository,IsystemLogs syslog,CoreDbContext ctx)
            {
                _repository = repository;
                _syslog = syslog;
            _ctx = ctx;
            }
        List<string> logs = new List<string>();
        [HttpGet]
        public IActionResult GetAllLogs()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2GVBSVF\\SQLEXPRESS;initial catalog=BtyonDB;integrated security=true;");
            SqlDataAdapter adp = new SqlDataAdapter("Select Top 10(Description) from SystemLogs order by Id desc", con);
            adp.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            con.Open();
             adp.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                logs.Add(dt.Rows[i].Field<string>("Description"));
            }
            con.Close();
            return Ok(logs);

        }
        
    }
}
