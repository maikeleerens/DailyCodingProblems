using System;
using Xunit;

namespace Solutions.Problem014
{
    /// <summary>
    /// This problem was asked by Google.
    /// 
    /// The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.
    /// 
    /// Hint: The basic equation of a circle is x2 + y2 = r2.
    /// </summary>
    public class Problem014
    {
        [Fact]
        public void Problem014SolutionTest()
        {
            Assert.Equal(3.141, Math.Round(EstimatePi(100000000), 3));
        }

        public static double EstimatePi(int numberOfRuns)
        {
            var circlePoints = 0;

            var random = new Random();

            for (var i = 0; i < numberOfRuns; i++)
            {
                var x = Math.Pow(random.NextDouble(), 2);
                var y = Math.Pow(random.NextDouble(), 2);

                if (Math.Sqrt(x + y) <= 1.0)
                    circlePoints++;
            }


            return 4 * ((double)circlePoints / numberOfRuns);
        }
    }
}
