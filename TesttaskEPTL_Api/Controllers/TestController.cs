using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesttaskEPTL_Api.MasterInterface;
using TesttaskEPTL_Api.Models;

namespace TesttaskEPTL_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IEmployee iemployee;

        public TestController(IEmployee _iemployee)
        {
            iemployee = _iemployee;
        }

        [HttpPost]
        public int postdata([FromBody] EmployeeModel model)
        {
            int i = 1;
            iemployee.saveorupdate(model);
            return i;
        }
        [HttpGet]
        public List<EmployeeModel> Getdata()
        
        {
            List<EmployeeModel> model = iemployee.Getdata();
            return model;
        }
        [HttpPut("{id}")]
        public EmployeeModel Edit(int id,[FromBody] EmployeeModel model)
        {
             model = iemployee.Edit(id,model);
            return model;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            iemployee.Delete(id);
            
        }

    }
}
