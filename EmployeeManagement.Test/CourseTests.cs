using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public  class CourseTests
    {
        [Fact]
        public void CourseConstructor_NewCourse_IsNewMustBeTrue()
        {
            Course course = new Course("Agile Methodology");
            Assert.True(course.IsNew); 

        }
    }
}
