using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Jane Street.
    /// cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair.For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.
    /// 
    /// Given this implementation of cons: 
    /// def cons(a, b):
    ///     return lambda f : f(a, b)
    /// 
    /// Implement car and cdr.
    /// </summary>
    public class Problem005Test
    {
        [Fact]
        public void Problem005SolutionTest()
        {
            var pair = Problem005.Pair<int>.Cons(3, 4);

            Assert.Equal(3, Problem005.Pair<int>.Car(pair));
            Assert.Equal(4, Problem005.Pair<int>.Cdr(pair));
        }
    }
}
