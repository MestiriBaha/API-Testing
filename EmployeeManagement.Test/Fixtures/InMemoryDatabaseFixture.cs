using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.DbContexts;
using EmployeeManagement.DataAccess.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Test.Fixtures
{
    public class InMemoryDatabaseFixture : IDisposable
    {
        public IEmployeeManagementRepository employeeManagementRepository { get; }
        public EmployeeService employeeService {get ; }
        public InMemoryDatabaseFixture()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();
            var optionBuilder = new DbContextOptionsBuilder<EmployeeDbContext>().UseSqlite(connection);
            var DbContext = new EmployeeDbContext(optionBuilder.Options);
            DbContext.Database.Migrate();
             employeeManagementRepository = new EmployeeManagementRepository(DbContext);
             employeeService = new EmployeeService(employeeManagementRepository, new EmployeeFactory());
        }
        public void Dispose()
        {
            //Clean up unmaneged ressources ! 
        }
    }
}
