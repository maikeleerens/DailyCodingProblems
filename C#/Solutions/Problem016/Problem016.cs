using System.Collections.Generic;
using Xunit;

namespace DailyCodingProblems.Solutions.Problem016
{
    /// <summary>
    /// This problem was asked by Twitter.
    /// 
    /// You run an e-commerce website and want to record the last N order ids in a log. Implement a data structure to accomplish this, with the following API:
    /// 
    /// record(order_id): adds the order_id to the log
    /// 
    /// get_last(i): gets the ith last element from the log. i is guaranteed to be smaller than or equal to N.
    /// 
    /// You should be as efficient with time and space as possible.
    /// </summary>
    public class Problem016
    {
        [Fact]
        public void Problem016SolutionTest()
        {
            var log = new Log(3);
            log.Record(1);
            log.Record(2);
            log.Record(3);

            Assert.Equal(1, log.GetLast(3));
            Assert.Equal(2, log.GetLast(2));
            Assert.Equal(3, log.GetLast(1));
        }
    }
}
