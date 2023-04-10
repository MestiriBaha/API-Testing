using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.Fixtures
{
    public class MoqFixture : IDisposable
    {
        public Mock<IEmployeeManagementRepository> employeeManagementRepository { get;  } 
        public Mock<EmployeeFactory> employeeFactory { get; } 
        public MoqFixture()
        {
            employeeManagementRepository = new Mock<IEmployeeManagementRepository>();   
            employeeFactory = new Mock<EmployeeFactory>();
            employeeFactory.Setup(
               x =>
               x.CreateEmployee("baha",
                                               It.IsAny<String>(),
                                               null,
                                               false)
               ).Returns(new InternalEmployee("baha", "Mestiri", 5, 2500, false, 1));
            employeeFactory.Setup(
               x =>
               x.CreateEmployee("DHIA",
                                               It.Is<string>(x => x.Contains("M")),
                                               null,
                                               false)
               ).Returns(new InternalEmployee("DHIA", "Mestiri", 5, 2500, false, 1));
            //Configuring the IEmployeeManagementRepositoryMock !! 
            employeeManagementRepository.Setup(
                setup =>  setup.GetInternalEmployeeAsync(It.IsAny<Guid>()))
                .ReturnsAsync   (new InternalEmployee("Baha","Dhia",1,3000, false, 1)
                {
                    AttendedCourses = new List<Course>()
                    {
                        new Course("DESIGN PATTERNS  ") , 
                        new Course("dragon ball ") 
                    }
                }); 
                

        }
        public void Dispose()
        {
        }
    }
}
