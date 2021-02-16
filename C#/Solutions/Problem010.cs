using System;
using System.Threading;

namespace Solutions
{
    /// <summary>
    /// This problem was asked by Apple.
    /// 
    /// Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.
    /// </summary>
    public static class Problem010
    {
        public static string JobScheduler(Func<string> f, int n)
        {
            Thread.Sleep(n);
            return f.Invoke();
        }
    }
}
