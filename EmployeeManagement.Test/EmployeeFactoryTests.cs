using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace EmployeeManagement.Test
{
    [Collection("NoParallelism")]

    public class EmployeeFactoryTests : IDisposable
    {
        public void Dispose()
        {
            //Nothing to say here , everything is good ! 

        }
        private EmployeeFactory _factory;
        private ITestOutputHelper _OutputHelper; 
        public EmployeeFactoryTests(ITestOutputHelper outputHelper)
        {
            _factory = new EmployeeFactory();
            _OutputHelper = outputHelper;   
        }

        //As you can see we are instantiating the  EmployeeFactory class for each test , the optimized solution is to instantiate as a text context and use IDISPOSABLE to clean up unused ressources ! 
        //Naming Guidelines is Important !! 
        //For testing we specify test description , action description and expected Outcome !
        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_EmployeeSalary")]

        public void InternalEmployee_ConstructInternalEmployee_SalaryMustbe2500()
        {
            //Arrange
           // var employeeFactory = new EmployeeFactory();
            //Act
            var employee = (InternalEmployee)_factory.CreateEmployee("Baha", "mestiri"); 
            //Assert 
            Assert.Equal(2500,employee.Salary);

        }
        [Fact]
        [Trait("Category","EmployeeFactory_CreateEmployee_EmployeeSalary")]
        public void InternalEmployee_ConstructInternalEmployee_PRECISIONTEST()
        {
            //Arrange
            //var employeeFactory = new EmployeeFactory();
            //Act
            var employee = (InternalEmployee)_factory.CreateEmployee("Baha", "mestiri");
            employee.Salary = 2500.15m; 
            //Assert 
            Assert.Equal(2500, employee.Salary, precision:0);

        }
        [Fact]
        [Trait("Category","EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_IsExternalisTrue_ExternalEmployeMustbeCreated()
        {
            //Arrange : 
            //var TestFactory = new EmployeeFactory();
            //Act
           var test = _factory.CreateEmployee("Baha", "Mestiri", "GIZ", true);
            //Assert : 
            _OutputHelper.WriteLine($"Name is {test.LastName} , that is it for now !! "); 
            Assert.IsType<ExternalEmployee>(test); 
            Assert.IsAssignableFrom<Employee>(test);  

        }
        //We can see that tests are not running in parallele :o 
      

        
    }
}
