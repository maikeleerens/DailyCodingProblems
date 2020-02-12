using System;
using System.Linq;
using Xunit;

namespace Solutions.Problem007
{
    /// <summary>
    /// This problem was asked by Facebook.
    /// 
    /// Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
    /// For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
    /// You can assume that the messages are decodable. For example, '001' is not allowed.
    /// </summary>
    public class Problem007
    {
        [Fact]
        public void Problem007SolutionTest()
        {
            Assert.Equal(3, NumberOfWaysToDecodeMessage(111));
        }

        private static int NumberOfWaysToDecodeMessage(int message)
        {
            var messageAsString = message.ToString();
            var count = 0;
            if (messageAsString.Length == 1)
                count = 1;
            else if (messageAsString.Length == 2)
            {
                count = 1 + (message > 26 || message < 1 ? 0 : 1);
            }
            else
            {
                count = NumberOfWaysToDecodeMessage(Convert.ToInt32(messageAsString[Range.StartAt(1)]));

               if (Convert.ToInt32(messageAsString[Index.Start..^2]) < 27 || Convert.ToInt32(messageAsString[Index.Start..^2]) > 0)
               {
                   count += NumberOfWaysToDecodeMessage(Convert.ToInt32(messageAsString[Range.StartAt(2)]));
               }
            }

            return count;
        }
    }
}
