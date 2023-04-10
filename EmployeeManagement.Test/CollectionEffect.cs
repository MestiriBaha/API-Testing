

namespace EmployeeManagement.Test
{
    [Collection("NoParallelism")]
    public class CollectionEffect
    {
        [Fact]
        public void SleepTest()
        {
            Thread.Sleep(2000);
            Assert.True(true);
        }
    }
}
