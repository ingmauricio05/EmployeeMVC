using EmployeesModel;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository repository;

        public EmployeeService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            Request request = new Request()
            {
                Method = HttpMethod.Get,
                Query = "Employees"
            };

            JArray objeto = await this.repository.MakeRequestGet(request);
            List<Employee> employees = objeto.ToObject<List<Employee>>();


            return employees;
        }

        public async Task<List<Employee>> GetEmployeesById(int? idEmployee)
        {
            Request request = new Request()
            {
                Method = HttpMethod.Get,
                Query = "Employees"
            };

            JArray objeto = await this.repository.MakeRequestGet(request);
            List<Employee> employees = objeto.ToObject<List<Employee>>();

            if (idEmployee == null)
            {
                return employees;
            }
            else
            {
                return employees.Where(em => em.Id.Equals(idEmployee)).ToList();
            }
        }
    }
}
