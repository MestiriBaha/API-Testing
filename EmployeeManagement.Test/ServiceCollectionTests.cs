using EmployeeManagement.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void ServicesRegistered_Execute_DataServicesAreRegistered()
        {
            //Arrange 
            var serviceCollection = new ServiceCollection();
            // IEnumerable<KeyValuePair<string, string>> initialData
            var builder = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<String, String>
            {
                {"ConnectionStrings:EmployeeManagementDB" , "AnyValue" }

            }).Build(); 
            //Act
            serviceCollection.RegisterDataServices(builder);
            var services = serviceCollection.BuildServiceProvider();
            //Assert
            Assert.NotNull(services.GetService<IEmployeeManagementRepository>());
        }
    }
}
