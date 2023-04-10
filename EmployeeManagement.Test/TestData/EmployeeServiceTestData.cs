using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.TestData
{
    public class EmployeeServiceTestData : IEnumerable<Object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new Object[] { 100, 5 };
                yield return new Object[] { 100, true };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }
}
