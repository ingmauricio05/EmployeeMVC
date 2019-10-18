using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesModel
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<List<Employee>> GetEmployeesById(int? idEmployee);
    }
}
