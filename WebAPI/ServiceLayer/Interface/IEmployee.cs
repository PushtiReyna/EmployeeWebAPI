using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWebApi.Entities;
using DTO.ReqResDTO;


namespace ServiceLayer.Interface
{
    public interface IEmployee
    {

        List<EmployeeMst> GetEmployeeList();
        void CreateEmployee(EmployeeMst employee);

        Boolean UpdateEmployee(int id, EmployeeMst employee);

        Boolean DeleteEmployee(int id);

    }
}
