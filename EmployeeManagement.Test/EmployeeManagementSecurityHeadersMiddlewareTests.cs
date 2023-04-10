using EmployeeManagement.Middleware;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeManagementSecurityHeadersMiddlewareTests
    {
        [Fact]
        public async Task InvokeAsync_Middleware_SetsExpectedResponseHeaders()
        {
            //Arrange 
            var Context = new DefaultHttpContext(); 
            //choosing the variable as delegate will get an ERROR !! 
            //Task.CompletedTask will give the middleware response result and stops there !! 
            RequestDelegate  next = (HttpContext httpContext) => Task.CompletedTask; 
            var middleware = new EmployeeManagementSecurityHeadersMiddleware(next); 
            //Act 
            await middleware.InvokeAsync(Context);
            //Assert 
           var firstcheck =  Context.Response.Headers["Content-Security-Policy"].ToString();
           var secondcheck = Context.Response.Headers["X-Content-Type-Options"].ToString(); 
            Assert.Equal("nosniff",secondcheck);    
            Assert.Equal("default - src 'self'; frame - ancestors 'none'; ",firstcheck);    

           
        }
    }
}
