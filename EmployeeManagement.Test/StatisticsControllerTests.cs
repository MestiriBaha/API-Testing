using AutoMapper;
using EmployeeManagement.Controllers;
using EmployeeManagement.MapperProfiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class StatisticsControllerTests
    {
        [Fact]
        public async Task StatisticsController_GetConnectionFeatures_IpAddressandPortNumbermustbeReturned()
        {
            //Arrange
            var localIpAddress = System.Net.IPAddress.Parse("192.11.0.147"); 
            var localPort  = 4000 ;
            var remoteAddress = System.Net.IPAddress.Parse("58.112.45.102");
            var remotePort = 8000; 
            var features = new Mock<IFeatureCollection>();
            features.Setup(x =>
            x.Get<IHttpConnectionFeature>())
                .Returns(new HttpConnectionFeature
                {
                    LocalIpAddress = localIpAddress,
                    LocalPort = localPort,
                    RemoteIpAddress = remoteAddress,
                    RemotePort = remotePort
                }) ;
            var MockHttpContext = new Mock<HttpContext>(); 
            MockHttpContext.Setup(x=> x.Features).Returns(features.Object);

            var mapperConfiguration = new MapperConfiguration(y => y.AddProfile<StatisticsProfile>());
            var mapper = new Mapper(mapperConfiguration);
            var statisticsController = new StatisticsController(mapper); 
            //Act 



        }
    }
}
