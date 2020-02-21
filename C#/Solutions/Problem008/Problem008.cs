using Xunit;

namespace Solutions.Problem008
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
    public class Problem008
    {
        [Fact]
        public void Problem008SolutionTest()
        {
            Assert.Equal(5, NumberOfUnivalSubTrees(new Node("0", new Node("1"), new Node("0", new Node("1", new Node("1"), new Node("1")), new Node("0")))));
        }

        public static int NumberOfUnivalSubTrees(Node node)
        {
            var univalSubTreeCount = 0;

            if (node == null) return univalSubTreeCount;

            if (IsUnival(node)) univalSubTreeCount += 1;

            if (node.Left != null)
            {
                univalSubTreeCount += NumberOfUnivalSubTrees(node.Left);
            }

            if (node.Right != null)
            {
                univalSubTreeCount += NumberOfUnivalSubTrees(node.Right);
            }

            return univalSubTreeCount;
        }

        private static bool IsUnival(Node node)
        {
            if (node.Left == null && node.Right == null) return true;
            if (node.Left == null || node.Right == null) return false;
            if (node.Value != node.Left.Value || node.Value != node.Right.Value) return false;
            return IsUnival(node.Left) && IsUnival(node.Right);
        }
    }

    /// <summary>
    /// A node in a binary tree
    /// </summary>
    public class Node
    {
        public string Value { get; }
        public Node Left { get; }
        public Node Right { get; }

        public Node(string value, Node left = null, Node right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
