using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameLastName_NamesAreConcatenated()
        {
            var Employee = new InternalEmployee("Baha", "Mestiri", 0, 2500, false, 1); 
            Assert.Equal("Baha Mestiri",Employee.FullName, ignoreCase : true);
            Assert.StartsWith(Employee.FirstName, Employee.FullName); 
            //Assert.Matches("B(A|D|H)",Employee.FullName);   

        }
    }
}
