using System;
using System.Threading.Tasks;
using BusinessLogic;
using EmployeesModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmployeeTest
{
    [TestClass]
    public class EmployeeBusinessUnitTest
    {
        [TestMethod]
        public async Task GetEmployeesDTOByIdTestMethodAsync()
        {
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(r => r.MakeRequestGet(It.IsAny<Request>())).Returns(GetEmployees());
            EmployeeBusiness business = new EmployeeBusiness(repositoryMock.Object);
            int employeeId = 1;
            var result = await business.GetEmployeesDTOById(employeeId);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public async Task GetEmployeesDTOTestMethodAsync()
        {
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(r => r.MakeRequestGet(It.IsAny<Request>())).Returns(GetEmployees());
            EmployeeBusiness business = new EmployeeBusiness(repositoryMock.Object);
            var result = await business.GetEmployeesDTO();
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result[0].Id == 1);
        }

        private Task<JArray> GetEmployees()
        {
            return Task.Factory.StartNew(() =>
            {
                return JsonConvert.DeserializeObject<JArray>("[{ 	\"id\": 1, 	\"name\": \"Juan\", 	\"contractTypeName\": \"HourlySalaryEmployee\", 	\"roleId\": 1, 	\"roleName\": \"Administrator\", 	\"roleDescription\": null, 	\"hourlySalary\": 60000, 	\"monthlySalary\": 80000 }]");
                
            });
        }
    }
}
