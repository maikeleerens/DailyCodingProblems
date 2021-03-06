﻿namespace Solutions
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
    public static class Problem003
    {
        /// <summary>
        /// A node in a binary tree
        /// </summary>
        public class Node
        {
            public string Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(string value, Node left = null, Node right = null)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }

        /// <summary>
        /// Serializes and deserializes all <see cref="Node"/> from a binary tree     
        /// </summary>
        public static class NodeSerializer
        {
            private static int _index;

            public static string Serialize(Node node)
            {
                return node == null ? "empty" : $"{node.Value}-{Serialize(node.Left)}-{Serialize(node.Right)}";
            }

            public static Node Deserialize(string serializedNode)
            {
                var nodeList = serializedNode.Split("-");

                if (_index >= nodeList.Length) _index = 0;

                if (nodeList[_index].Contains("empty"))
                {
                    _index++;
                    return null;
                }

                var nodeToReturn = new Node(nodeList[_index]);
                _index++;
                nodeToReturn.Left = Deserialize(serializedNode);
                nodeToReturn.Right = Deserialize(serializedNode);
                return nodeToReturn;
            }
        }
    }
}
