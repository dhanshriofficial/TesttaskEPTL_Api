using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesttaskEPTL_Api.Models;

namespace TesttaskEPTL_Api.MasterInterface
{
    public interface IEmployee
    {
        int saveorupdate(EmployeeModel model);
        List<EmployeeModel> Getdata();

        EmployeeModel Edit(int id, EmployeeModel model);

        void Delete(int id);
    }
}
