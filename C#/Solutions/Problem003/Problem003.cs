using Xunit;

namespace DailyCodingProblems.Solutions.Problem003
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
    public class Problem003
    {
        [Fact]
        public void Problem003SolutionTest()
        {
            var node = new Node("root", new Node("left", new Node("left.left")), new Node("right"));

            Assert.Equal("left.left", NodeSerializer.Deserialize(NodeSerializer.Serialize(node)).Left.Left.Value);
        }
    }
}
