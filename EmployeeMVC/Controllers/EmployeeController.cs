using BusinessLogic;
using EmployeesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeBusiness employeeBus = new EmployeeBusiness();

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            List<EmployeeDTO> employeeDTO = await employeeBus.GetEmployeesDTO();

            return View(employeeDTO);
        }

        public async Task<ActionResult> Search(int? idEmployee)
        {
            List<EmployeeDTO> employeeDTO = await employeeBus.GetEmployeesDTOById(idEmployee);

            return View("Index", employeeDTO);
        }
    }
}