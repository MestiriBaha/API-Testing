using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.TestData
{
    public class StronglyTypedEmployeeServiceTestData_FromFile : TheoryData<int,bool>
    {
        public StronglyTypedEmployeeServiceTestData_FromFile()
        {
            var readfile = File.ReadAllLines("TestData/EmployeeServiceTestData.csv"); 
            foreach(var line in readfile)
            {
               var  splitLine = line.Split(","); 
                if (int.TryParse(splitLine[0],out int Raise)   && bool.TryParse(splitLine[1],out bool Condition)) {
                    Add(Raise, Condition); 
                }
            }
        }
    }
}
