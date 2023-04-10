
using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Services.Test;
using EmployeeManagement.Test.Fixtures;
using EmployeeManagement.Test.HttpMessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace EmployeeManagement.Test
{
    public  class TestIsolationApproachesTests : IClassFixture<InMemoryDatabaseFixture>
    {
        public InMemoryDatabaseFixture _Fixture; 
       public TestIsolationApproachesTests(InMemoryDatabaseFixture MemoryDatabase)
        {
            _Fixture = MemoryDatabase;  
        }
        [Fact]
        public async Task AttendCourseAsync_CourseAttended_RecalculationOfSuggestedBonus()
        {
            //Arrange 
            //In Memory For Testing Database 

            //Act
            //Get Course From Database 
            var AttendedClass = await _Fixture.employeeManagementRepository.GetCourseAsync(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
            //Get Existing Employee
            var employee = await _Fixture.employeeManagementRepository.GetInternalEmployeeAsync(Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")); 
            if (employee == null || AttendedClass==null)
            {
                throw new XunitException("Arranging the Test was FAILED  "); 
            }
            //Calculated the Expected BONUS After Attending the course 
            var expectedBonus = employee.SuggestedBonus = employee.YearsInService
                * employee.AttendedCourses.Count * 100;
            //Act 
            await _Fixture.employeeService.AttendCourseAsync(employee, AttendedClass); 
            Assert.Equal(expectedBonus, employee.SuggestedBonus);
        }
        [Fact]
        public async Task PromoteInternalEmployeeAsync_promotion_CheckIfInternalEmployeeIsEligibleForPromotion()
        {
            //Arrange 
            var httpclient = new HttpClient(new TestablePromotionEligibilityHandler(true)) ;
            var internalEmployee = new InternalEmployee("Baha", "Mestiri", 5, 3000, false, 1);
            var promotion = new PromotionService(httpclient, new EmployeeManagementTestDataRepository());

            //Act 

           await promotion.PromoteInternalEmployeeAsync(internalEmployee);
            //Assert 
            Assert.Equal(2, internalEmployee.JobLevel); 
    }
    }
}
