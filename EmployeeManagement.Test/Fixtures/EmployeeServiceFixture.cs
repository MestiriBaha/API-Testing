using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Services.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.Fixtures
{
    public class EmployeeServiceFixture : IDisposable
    {
        public IEmployeeManagementRepository employeeManagementTestDataRepository { get;  }
        public EmployeeService employeeService { get;  }
        public EmployeeServiceFixture()
        {
            employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            employeeService = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory()); 
        }

        public void Dispose()
        {
          //clean up code ! 
        }
    }
}
