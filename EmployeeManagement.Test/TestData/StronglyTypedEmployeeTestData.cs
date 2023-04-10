using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.TestData
{
    public class StronglyTypedEmployeeTestData : TheoryData<int,bool>
    {
        public StronglyTypedEmployeeTestData()
        {
            Add(100,false); 
            Add(200,true);  
        }
    }
}
