using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Apple.
    /// 
    /// Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.
    /// </summary>
    public class Problem010Test
    {
        [Fact]
        public void Problem010SolutionTest()
        {
            Assert.Equal("done", Problem010.JobScheduler(Function, 5000));
        }

        private static string Function()
        {
            return "done";
        }
    }
}
