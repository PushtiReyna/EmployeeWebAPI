using EmployeeWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class EmployeeDAL
    {

        public EmployeeDAL()
        {

        }

        public List<EmployeeMst> GetEmployeeList()
        {
            //return Ok(_db.EmployeeMsts.ToList());
            var db = new EmployeeApidbContext();
            return db.EmployeeMsts.ToList();
        }

        public void CreateEmployee(EmployeeMst employee)
        {
            var db = new EmployeeApidbContext();
            db.EmployeeMsts.Add(employee);
            db.SaveChanges();
        }

        public Boolean UpdateEmployee(int id, EmployeeMst employee)
        {
            var db = new EmployeeApidbContext();

            if (id != employee.Id)
            {
                return false;
            }
            else
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public Boolean DeleteEmployee(int id)
        {
            var db = new EmployeeApidbContext();

            var employee = db.EmployeeMsts.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                db.EmployeeMsts.Remove(employee);
                db.SaveChanges();
                return true;
            }
            return false;
        }


    }
}