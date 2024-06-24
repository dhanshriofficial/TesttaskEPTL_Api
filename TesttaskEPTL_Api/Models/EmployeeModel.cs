using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesttaskEPTL_Api.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Emp_name { get; set; }
        public string Emp_address { get; set; }
        public string Emp_contact { get; set; }
        public DateTime Emp_DOB { get; set; }
        public string Emp_designation { get; set; }
        public string Emp_email { get; set; }
        public decimal Emp_salary { get; set; }


    }
}
