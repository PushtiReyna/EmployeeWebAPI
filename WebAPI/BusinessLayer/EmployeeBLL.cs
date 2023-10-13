using EmployeeWebApi.Entities;
using ServiceLayer.Interface;
using DTO.ReqResDTO;


namespace BusinessLayer
{
    public class EmployeeBLL 
    {
        public readonly IEmployee _Iemployee;


        public EmployeeBLL()
        {
            _Iemployee = new ServiceLayer.EmployeeImpl();
        }

        public List<EmployeeMstDTO> GetEmployeeList()
        {
            List<EmployeeMstDTO> lstEmployee = new List<EmployeeMstDTO>();
            foreach (EmployeeMst employee in _Iemployee.GetEmployeeList())
            {
                EmployeeMstDTO employeeDTO = new EmployeeMstDTO();
                employeeDTO.Id = employee.Id;
                employeeDTO.FirstName = employee.FirstName;
                employeeDTO.LastName = employee.LastName;
                lstEmployee.Add(employeeDTO);
            }
            return lstEmployee;

            //return _Iemployee.GetEmployeeList();
          }


        public void CreateEmployee(EmployeeMstDTO employeeDTO)
        {
            var employeeMst = new EmployeeMst()
            {
                Id = employeeDTO.Id,
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
            };

            // _DAL.CreateEmployee(employee);
            _Iemployee.CreateEmployee(employeeMst);
        }

        public Boolean UpdateEmployee(int id, EmployeeMstDTO employeeDTO)
        {
            var employeeMst = new EmployeeMst()
            {
                Id = employeeDTO.Id,
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
            };

            var updateEmployee = _Iemployee.UpdateEmployee(id, employeeMst);
            if (updateEmployee == false)
            {
                return false;
            }
            return true;
        }

        public Boolean DeleteEmployee(int id)
        {
            var deleteEmployee = _Iemployee.DeleteEmployee(id);
            if (deleteEmployee == false)
            {
                return false;
            }
            return true;
        }

    }
}