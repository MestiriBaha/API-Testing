using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;
using EmployeeManagement.Test.Fixtures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class MoqTests : IClassFixture<MoqFixture>
    {
        private MoqFixture _MoqFixture;
        public MoqTests(MoqFixture moqFixture)
        {
            _MoqFixture = moqFixture;
        }
        [Fact]
        public void FetchInternalEmployee_EmployeeFetched_CalculatingSuggestedBonus()
        {
            //Arrange : 
            var employeeRepository = new EmployeeManagementTestDataRepository();
           
            var EmployeeService = new EmployeeService(employeeRepository, _MoqFixture.employeeFactory.Object);
            //Act
            var employee = EmployeeService.CreateInternalEmployee("DHIA", "Mestiri"); 
            //Assert 
            Assert.Equal(1000, employee.SuggestedBonus); 
        }
        [Fact]
        public void FetchInternalEmployee_EmployeeFetched_SuggestedBonusCalculated()
        {
            //Arrange : 
            //var employeeRepository = new EmployeeManagementTestDataRepository();

            var EmployeeService = new EmployeeService(_MoqFixture.employeeManagementRepository.Object, _MoqFixture.employeeFactory.Object);
            //Act
            var employee = EmployeeService.FetchInternalEmployee(It.IsAny<Guid>());
            //Assert 
            Assert.Equal(200, employee.SuggestedBonus);
        }
        [Fact]
        public async Task FetchInternalEmployee_EmployeeFetched_SuggestedBonusCalculatedAsync()
        {
            //Arrange : 
            //var employeeRepository = new EmployeeManagementTestDataRepository();

            var EmployeeService = new EmployeeService(_MoqFixture.employeeManagementRepository.Object, _MoqFixture.employeeFactory.Object);
            //Act
            var employee = await EmployeeService.FetchInternalEmployeeAsync(It.IsAny<Guid>());
            //Assert 
            Assert.Equal(200, employee.SuggestedBonus);
        }
    }
}
