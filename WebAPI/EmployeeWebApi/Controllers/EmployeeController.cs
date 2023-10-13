using EmployeeWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using EmployeeWebApi.ViewModel;
using DTO.ReqResDTO;

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
        public List<EmployeeViewModel> GetEmployeeList()
        {
            List<EmployeeViewModel> lstEmployee = new List<EmployeeViewModel>();
            foreach (EmployeeMstDTO employee in _BLL.GetEmployeeList())
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                employeeViewModel.EmployeeId = employee.Id;
                employeeViewModel.EmployeeFirstName = employee.FirstName;
                employeeViewModel.EmployeeLastName = employee.LastName;
                lstEmployee.Add(employeeViewModel);
            }
            return lstEmployee;
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            var employeeMstDTO = new EmployeeMstDTO()
            {
                Id = employeeViewModel.EmployeeId,
                FirstName = employeeViewModel.EmployeeFirstName,
                LastName = employeeViewModel.EmployeeLastName,
            };

            _BLL.CreateEmployee(employeeMstDTO);

           
            return Ok(employeeMstDTO);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(int id, EmployeeViewModel employeeViewModel)
        {
            var employeeMstDTO = new EmployeeMstDTO()
            {
                Id = employeeViewModel.EmployeeId,
                FirstName = employeeViewModel.EmployeeFirstName,
                LastName = employeeViewModel.EmployeeLastName,
            };

            var UpdateEmployee = _BLL.UpdateEmployee(id, employeeMstDTO);
            if (UpdateEmployee == false)
            {
                return BadRequest();
            }
            return Ok(employeeMstDTO);

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
