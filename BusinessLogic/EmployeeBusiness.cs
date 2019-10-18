using DataAccess;
using DataAccess.Services;
using EmployeesModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeeBusiness
    {
        private readonly IEmployeeService employeeService;

        public EmployeeBusiness()
        {
            this.employeeService = new EmployeeService(new Repository());
        }
        public EmployeeBusiness(IRepository repository)
        {
            this.employeeService = new EmployeeService(repository);
        }


        public async Task<List<EmployeeDTO>> GetEmployeesDTOById(int? idEmployee)
        {
            List<EmployeeDTO> employeesDTO = new List<EmployeeDTO>();
            List<Employee> employees = await this.employeeService.GetEmployeesById(idEmployee);

            foreach (Employee empl in employees)
            {
                Contract contract = ContractFactory.ContractCreator(empl);
                employeesDTO.Add(this.MapperEmployeeToEmployeeDTO(empl, contract));
            }

            return employeesDTO;
        }

        public async Task<List<EmployeeDTO>> GetEmployeesDTO()
        {
            List<EmployeeDTO> employeesDTO = new List<EmployeeDTO>();
            List<Employee> employees = await this.employeeService.GetEmployees();

            foreach (Employee empl in employees)
            {
                Contract contract = ContractFactory.ContractCreator(empl);
                employeesDTO.Add(this.MapperEmployeeToEmployeeDTO(empl, contract));
            }

            return employeesDTO;
        }

        private EmployeeDTO MapperEmployeeToEmployeeDTO(Employee employee, Contract contract)
        {
            return new EmployeeDTO()
            {
                Id = employee.Id,
                ContractTypeName = employee.ContractTypeName,
                Name = employee.Name,
                RoleName = employee.RoleName,
                AnnualSalary = contract.AnnualSalary
            };
        }
    }
}
