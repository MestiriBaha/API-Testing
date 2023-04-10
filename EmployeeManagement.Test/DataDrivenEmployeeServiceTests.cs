using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using EmployeeManagement.Test.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceCollection")]

    public class DataDrivenEmployeeServiceTests
    {
        public EmployeeServiceFixture _Fixture; 
        public DataDrivenEmployeeServiceTests(EmployeeServiceFixture fixture)
        {
            _Fixture = fixture; 
        }
        //For now , the idea is to create a test Method that will check for a particular INPUT Guid Id of course ! 
        [Theory]
        //INLINE DATA  : WATCH THE MAGIC  , every data we want to test it , we just have to pass it through the INLINE DATA  !! 
        [InlineData("37e03ca7-c730-4351-834c-b66f280cdb01")]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedCourseswithObject(Guid  courseID )
        {
            //Arrange
           
            //Act
            var newInternalEmployee = _Fixture.employeeService.CreateInternalEmployee("Dhia", "Mestiri");
            //Assert
            //this method can't work with Asynchronous Programming ! 
            Assert.Contains(newInternalEmployee.AttendedCourses,course => course.Id ==courseID);


        }
        //STATIC PROPERTY  !! 
        public static IEnumerable<Object[]> MemberDataTypeProperty
        {
            get
            {
                return new List<Object[]>
                {
                    new object[] { 100, true },
                    new object[] { 200, false }
                };
            }
        }
        public static TheoryData<int, bool> MemberDataStronglyType
        {
            get
                {
                return new TheoryData<int, bool>()
                {
                    { 100 , false } ,
                    { 200 , true }

                };
            }
        }
        
        //Let's try a STATIC METHOD  !! 
        public static IEnumerable<Object[]> MemberDataTypeMethod(int TakenDataforTest)
        {
            return new  List <Object[]>
                {
                new object[] { 100 , true },
                new object[] { 200, false }
            }.Take(TakenDataforTest); 
        }
        [Theory]
        //Member Data  : WATCH THE MAGIC  
        //CLASS DATA IS BETTER  !! 
        //[MemberData(nameof(MemberDataTypeMethod),1)]
        //[ClassData(typeof(EmployeeServiceTestData))]
        //[ClassData(typeof(StronglyTypedEmployeeTestData))]
        // [MemberData(nameof(MemberDataStronglyType))]    
        [ClassData(typeof(StronglyTypedEmployeeServiceTestData_FromFile))]
        public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseMatchesGivenRaise(int raiseGiven , bool expectedValueForMinimumRaiseGiven)
        {
            //Arrange
            var internalEmployee = new InternalEmployee("Brooklyn", "Mestiri", 5, 3000, false, 1);
            //Act
           await _Fixture.employeeService.GiveRaiseAsync(internalEmployee , raiseGiven);
            //Assert 
            Assert.Equal(expectedValueForMinimumRaiseGiven,internalEmployee.MinimumRaiseGiven);
        }
    }
}
