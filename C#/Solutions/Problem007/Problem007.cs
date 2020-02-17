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

            if (messageAsString.Length > 2)
            {
                count += IsValidMappedLetter(Convert.ToInt32(messageAsString[..2]))
                    ? NumberOfWaysToDecodeMessage(Convert.ToInt32(messageAsString[2..]))
                    : 0;
                count += NumberOfWaysToDecodeMessage(
                    Convert.ToInt32(messageAsString.Substring(1, messageAsString.Length - 1)));
            }
            else if (messageAsString.Length == 2)
            {
                count += IsValidMappedLetter(Convert.ToInt32(messageAsString)) ? 2 : 1;
            }
            else if (messageAsString.Length == 1)
            {
                count = 1;
            }

            return count;
        }

        private static bool IsValidMappedLetter(int number)
        {
            return number < 27 && number > 0;
        }
    }
}
