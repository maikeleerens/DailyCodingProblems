﻿namespace Solutions
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
    public static class Problem008
    {
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

        public static int NumberOfUniversalSubTrees(Node node)
        {
            var universalSubTreeCount = 0;

            if (node == null) return universalSubTreeCount;

            if (IsUniversal(node)) universalSubTreeCount += 1;

            if (node.Left != null)
            {
                universalSubTreeCount += NumberOfUniversalSubTrees(node.Left);
            }

            if (node.Right != null)
            {
                universalSubTreeCount += NumberOfUniversalSubTrees(node.Right);
            }

            return universalSubTreeCount;
        }

        private static bool IsUniversal(Node node)
        {
            if (node.Left == null && node.Right == null) return true;
            if (node.Left == null || node.Right == null) return false;
            if (node.Value != node.Left.Value || node.Value != node.Right.Value) return false;
            return IsUniversal(node.Left) && IsUniversal(node.Right);
        }
    }
}
