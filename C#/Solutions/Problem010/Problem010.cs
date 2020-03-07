using System;
using System.Threading;
using Xunit;

namespace DailyCodingProblems.Solutions.Problem010
{
    /// <summary>
    /// This problem was asked by Apple.
    /// 
    /// Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.
    /// </summary>
    public class Problem010
    {
        [Fact]
        public void Problem010SolutionTest()
        {
            Assert.Equal("done", JobScheduler(Function, 5000));
        }

        private static string Function()
        {
            return "done";
        }

        private static string JobScheduler(Func<string> f, int n)
        {
            Thread.Sleep(n);
            return f.Invoke();
        }
    }
}
