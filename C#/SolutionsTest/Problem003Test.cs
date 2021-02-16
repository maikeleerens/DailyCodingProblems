using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Google.
    /// Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
    /// 
    /// For example, given the following Node class
    /// class Node :
    ///    def __init__(self, val, left=None, right=None):
    ///    self.val = val
    ///    self.left = left
    ///    self.right = right
    ///
    /// The following test should pass:
    ///    node = Node('root', Node('left', Node('left.left')), Node('right'))
    ///    assert deserialize(serialize(node)).left.left.val == 'left.left'
    /// </summary>
    public class Problem003Test
    {
        [Fact]
        public void Problem003SolutionTest()
        {
            var node = new Problem003.Node("root", new Problem003.Node("left", new Problem003.Node("left.left")), new Problem003.Node("right"));

            Assert.Equal("left.left", Problem003.NodeSerializer.Deserialize(Problem003.NodeSerializer.Serialize(node)).Left.Left.Value);
        }
    }
}
