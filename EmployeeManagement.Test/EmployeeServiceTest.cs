using EmployeeManagement.Business;
using EmployeeManagement.Business.EventArguments;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;
using EmployeeManagement.Test.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceCollection")]
    //Can you believe the MAGIC  
    public class EmployeeServiceTest // : IClassFixture<EmployeeServiceFixture>
    {
        public EmployeeServiceFixture _Fixture; 
        public EmployeeServiceTest(EmployeeServiceFixture fixture)
        {
            _Fixture = fixture;
        }
        
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedCourseswithObject()
        {
            //Arrange
            //We won't need those unecessary instantiation anymore !! 
            //var employeeMaagementTestData = new EmployeeManagementTestDataRepository(); 
            //var EmployeeServiceTest = new EmployeeService(employeeMaagementTestData, new EmployeeFactory() );
            var obligatoryCourse =  _Fixture.employeeManagementTestDataRepository.GetCourse(
                Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
            //Act
            var newInternalEmployee = _Fixture.employeeService.CreateInternalEmployee("Dhia", "Mestiri");
            //Assert
            //this method can't work with Asynchronous Programming ! 
            Assert.Contains(obligatoryCourse, newInternalEmployee.AttendedCourses); 


        }
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedCourseswithPredicate()
        {
            //Arrange
            //var employeeMaagementTestData = new EmployeeManagementTestDataRepository();
            //var EmployeeServiceTest = new EmployeeService(employeeMaagementTestData, new EmployeeFactory());
            //var obligatoryCourse = employeeMaagementTestData.GetCourse(
            //    Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
            //Act
            var newInternalEmployee = _Fixture.employeeService.CreateInternalEmployee("Dhia", "Mestiri");
            //Assert
            //this method can't work with Asynchronous Programming ! 
            Assert.Contains(newInternalEmployee.AttendedCourses,
                course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
            //Assertion over a collection : 
            Assert.All(newInternalEmployee.AttendedCourses, Cour => Assert.False(Cour.IsNew )) ; 


        }
        [Fact]
        public async void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedCourseswithObject_Async()
        {
            //Arrange
           // var employeeMaagementTestData = new EmployeeManagementTestDataRepository();
           // var EmployeeServiceTest = new EmployeeService(employeeMaagementTestData, new EmployeeFactory());
            var obligatoryCourse = await _Fixture.employeeManagementTestDataRepository.GetCourseAsync(
                Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
            //Act
            var newInternalEmployee = await _Fixture.employeeService.CreateInternalEmployeeAsync("Dhia", "Mestiri");
            //Assert
            //this method can't work with Asynchronous Programming ! 
            //Even  using Asynchronous Programming , nothing changed in the Assertion Method ! 
            Assert.Contains(obligatoryCourse, newInternalEmployee.AttendedCourses);


        }
        [Fact]
        public async void EmployeeRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseMustBeThrown()

        {
            //Arrange
           // var employeeService = new EmployeeService(new EmployeeManagementTestDataRepository(), new EmployeeFactory());
            var employee = new InternalEmployee("Baha", "Mestiri", 5 , 2500, false,1);

            //Act & Assert ! 
             await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(async() => await _Fixture.employeeService.GiveRaiseAsync(employee,50)); 
            
        }
        [Fact]
        public void NotifyOfAbsence_AbsentEmployee_EmployeeAbsentEventMustBeTriggered()
        {
            //Arrange
            //var employeeService = new EmployeeService(new EmployeeManagementTestDataRepository(), new EmployeeFactory());
            var employee = new InternalEmployee("Dhia", "Mestiri", 5, 2500, false, 1);
            //Act & Assert 
            Assert.Raises<EmployeeIsAbsentEventArgs>(handler => _Fixture.employeeService.EmployeeIsAbsent += handler , handler => _Fixture.employeeService.EmployeeIsAbsent -= handler 
                                        , () => _Fixture.employeeService.NotifyOfAbsence(employee)); 


        }
    }
}
