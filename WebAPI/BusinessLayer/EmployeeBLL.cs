﻿using Microsoft.AspNetCore.Mvc;
using EmployeeWebApi.Repository.Entities;

namespace BusinessLayer
{
    public class EmployeeBLL
    {
        private DataLayer.EmployeeDAL _DAL;
        public EmployeeBLL()
        {
            _DAL = new DataLayer.EmployeeDAL();
        }

        public List<EmployeeMst> GeteEmployeeList()
        {
            return _DAL.GeteEmployeeList();
        }


        public void CreateEmployee(EmployeeMst employee)
        {
            _DAL.CreateEmployee(employee);
        }

        public Boolean UpdateEmployee(int id, EmployeeMst employee)
        {
            var updateEmployee = _DAL.UpdateEmployee(id, employee);
            if (updateEmployee == false)
            {
                return false;
            }
            return true;
        }

        public Boolean DeleteEmployee(int id)
        {
            var deleteEmployee = _DAL.DeleteEmployee(id);
            if (deleteEmployee == false)
            {
                return false;
            }
            return true;
        }



    }
}