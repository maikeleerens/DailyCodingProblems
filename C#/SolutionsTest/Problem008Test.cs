using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Google.

    /// A unival tree(which stands for "universal value") is a tree where all nodes under it have the same value.
    /// Given the root to a binary tree, count the number of unival subtrees.
    /// 
    /// For example, the following tree has 5 unival subtrees: 
    ///    0
    ///   / \
    ///  1   0
    ///     / \
    ///    1   0
    ///   / \
    ///  1   1
    /// </summary>
    public class Problem008Test
    {
        [Fact]
        public void Problem008SolutionTest()
        {
            Assert.Equal(5, Problem008.NumberOfUniversalSubTrees(new Problem008.Node("0", new Problem008.Node("1"), new Problem008.Node("0", new Problem008.Node("1", new Problem008.Node("1"), new Problem008.Node("1")), new Problem008.Node("0")))));
        }
    }
}
