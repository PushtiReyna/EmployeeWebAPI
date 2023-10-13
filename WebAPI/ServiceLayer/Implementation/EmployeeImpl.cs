using EmployeeWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.ReqResDTO;

namespace ServiceLayer
{
    public class EmployeeImpl : IEmployee
    {
        public DataLayer.EmployeeDAL _DAL;

        public EmployeeImpl()
        {
            _DAL = new DataLayer.EmployeeDAL();
        }

        public List<EmployeeMst> GetEmployeeList()
        {
            return _DAL.GetEmployeeList();
        }

        public void CreateEmployee(EmployeeMst employee)
        {
            _DAL.CreateEmployee(employee);
        }

        public Boolean UpdateEmployee(int id, EmployeeMst employee)
        {
            return _DAL.UpdateEmployee(id, employee);
        }

        public Boolean DeleteEmployee(int id)
        {
            return _DAL.DeleteEmployee(id);
        }      
    }
}
