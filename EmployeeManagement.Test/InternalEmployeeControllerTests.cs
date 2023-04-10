using AutoMapper;
using EmployeeManagement.Business;
using EmployeeManagement.Controllers;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class InternalEmployeeControllerTests
    {
        private readonly Mock<IMapper> _mapper;

        //Auto Generated !! ow nice ! 
        private readonly InternalEmployeesController _TestController;

        public InternalEmployeeControllerTests()
        {
            var employeeService = new Mock<IEmployeeService>();
            employeeService.Setup(x => x.FetchInternalEmployeesAsync()).ReturnsAsync
                (new List<InternalEmployee>()
                {
                    new InternalEmployee ("Baha","Mestiri",2,2500,false,2) ,
                    new InternalEmployee ("Baha","Mestiri",2,3000,false,3),
                    new InternalEmployee ("Baha","Mestiri",2,3500,false,5)

                });
            _mapper = new Mock<IMapper>();
            _mapper.Setup(x => x.Map<InternalEmployee, InternalEmployeeDto>(It.IsAny<InternalEmployee>())).Returns(new InternalEmployeeDto()); 
             _TestController = new InternalEmployeesController(employeeService.Object, _mapper.Object);
        }
        [Fact]
        public async Task GetInternalEmployee_ActionResult_OKMustBeReturnType()
        {
            //Arrange 
            
            //Act 
           var result = await _TestController.GetInternalEmployees();

            //Assert 
            Assert.IsType<ActionResult<IEnumerable<InternalEmployeeDto>>>(result); 
            Assert.IsType<OkObjectResult>(result.Result); 
        }
        [Fact]
        public async Task GetInternalEmployee_ActionResult_ReturnTypeMustBeIenumerable()
        {
            //Arrange
            //Act
            var result = await _TestController.GetInternalEmployees();
            //Assert 
            //An ERROR has Occured : the problem is the type of RESULT  is : Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<EmployeeManagement.Models.InternalEmployeeDto>>)
            //we have to change it !! 
            //Another problem : we get rid of the ActionResult , we still have to check about the OkReturnObject : .AspNetCore.Mvc.OkObjectResult 
            //Result.Value is giving null !! 
            Assert.IsAssignableFrom<IEnumerable<InternalEmployeeDto>>(((OkObjectResult) result.Result).Value) ;




        }
        [Fact]
        public async Task GetInternalEmployee_ActionResult_ThreeEmployeesMustBeReturned()
        {
            //Arrange ! 
            //Act 
            var castingResult = await _TestController.GetInternalEmployees();
            //Assert !! 
            //We will be doing so many castings until we get to our Result which is the IEnumerable Count 
            var firstresult = Assert.IsType<OkObjectResult>(castingResult.Result); 
            var result = Assert.IsAssignableFrom<IEnumerable<InternalEmployeeDto>>(firstresult.Value);
            Assert.Equal(3, ((IEnumerable<InternalEmployeeDto>)result).Count()); 


        }
    }
}
