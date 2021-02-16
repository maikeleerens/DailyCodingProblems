using System;
using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Google.
    /// 
    /// The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.
    /// 
    /// Hint: The basic equation of a circle is x2 + y2 = r2.
    /// </summary>
    public class Problem014Test
    {
        [Fact]
        public void Problem014SolutionTest()
        {
            Assert.Equal(3.141, Math.Round(Problem014.EstimatePi(100000000), 3, MidpointRounding.ToZero));
        }
    }
}
