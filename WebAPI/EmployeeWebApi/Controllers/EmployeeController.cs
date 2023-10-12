using EmployeeWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
      
        private BusinessLayer.EmployeeBLL _BLL;
        public EmployeeController()
        {
            _BLL = new BusinessLayer.EmployeeBLL();
        }

        [HttpGet]
        [Route("GetEmployeeList")]
        public List<EmployeeMst> GetEmployeeList()
        {
            return _BLL.GetEmployeeList();
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult CreateEmployee(EmployeeMst employee)
        {
            _BLL.CreateEmployee(employee);
            return Ok(employee);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(int id,EmployeeMst employee)
        {

            var UpdateEmployee = _BLL.UpdateEmployee(id,employee);
            if (UpdateEmployee == false)
            {
                return BadRequest();
            }
            return Ok(employee);

        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            var DeleteEmployee = _BLL.DeleteEmployee(id);
            if (DeleteEmployee == false)
            {
                return BadRequest();
            }
            return Ok(id);
        }

        //public readonly EmployeeApidbContext _db;

        //public EmployeeController(EmployeeApidbContext db)
        //{
        //    _db = db;
        //}

        //[HttpGet]
        //public IActionResult GetEmployeeList()
        //{
        //    //return Ok(_db.EmployeeMsts.ToList());
        //    return _db.EmployeeMsts.ToList();
        //}

        //[HttpPost]
        //public IActionResult CreateEmployee(EmployeeMst employee)
        //{
        //    _db.EmployeeMsts.Add(employee);
        //    _db.SaveChanges();
        //    return Ok(employee);
        //}

        //[HttpPut]
        //public IActionResult UpdateEmployee(int id,EmployeeMst employee)
        //{
        //    if(id != employee.Id)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        _db.Entry(employee).State = EntityState.Modified;
        //        _db.SaveChanges();
        //        return Ok();
        //    }
        //}

        //[HttpDelete]
        //public IActionResult DeleteEmployee(int id)
        //{
        //    var employee = _db.EmployeeMsts.FirstOrDefault(x => x.Id == id);
        //    if(employee != null)
        //    {
        //        _db.EmployeeMsts.Remove(employee);
        //        _db.SaveChanges();
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

    }
}
