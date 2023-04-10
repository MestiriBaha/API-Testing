using EmployeeManagement.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class CheckShowStatisticsHeaderTests
    {
        [Fact]
        public void OnActionExecuting_ActionFilter_BadRequestMustBeReturned()
        {
            //Arrange
            var checkshowstatisticsheader = new CheckShowStatisticsHeader();
            var httpContext = new DefaultHttpContext();
            var actionContex = new ActionContext(httpContext, new(), new(), new());
            var OnGoingActionContext = new ActionExecutingContext(actionContex, new List<IFilterMetadata>(), new Dictionary<String, Object?>(), controller: null); 
            //Act 
                checkshowstatisticsheader.OnActionExecuting(OnGoingActionContext);
            //Assert
            Assert.IsType<BadRequestResult>(OnGoingActionContext.Result); 
        }
    }
}
