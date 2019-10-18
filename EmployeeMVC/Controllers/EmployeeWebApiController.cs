using BusinessLogic;
using EmployeesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeMVC.Controllers
{
    public class EmployeeWebApiController : ApiController
    {
        private readonly EmployeeBusiness employeeBus = new EmployeeBusiness();

        [HttpGet]
        [Route("api/GetEmplooyees")]
        public async Task<IHttpActionResult> GetEmplooyees()
        {
            try
            {
                List<EmployeeDTO> employeeDTO = await employeeBus.GetEmployeesDTO();
                return this.Ok(employeeDTO);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [Route("api/GetEmplooyeesById/{id}")]
        public async Task<IHttpActionResult> GetEmplooyeesById(int id)
        {
            try
            {
                List<EmployeeDTO> employeeDTO = await employeeBus.GetEmployeesDTOById(id);
                return this.Ok(employeeDTO);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
