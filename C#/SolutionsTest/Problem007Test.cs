using System;
using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Facebook.
    /// 
    /// Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
    /// For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
    /// You can assume that the messages are decodable. For example, '001' is not allowed.
    /// </summary>
    public class Problem007Test
    {
        [Fact]
        public void Problem007SolutionTest()
        {
            Assert.Equal(3, Problem007.NumberOfWaysToDecodeMessage(111));
        }
    }
}
