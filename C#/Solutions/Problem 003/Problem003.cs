﻿using Xunit;

namespace Daily_Coding_Problems.Problem_003
{
    /// <summary>
    /// This problem was asked by Google. <br></br>
    /// Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree. <br></br><br></br>
    /// 
    /// For example, given the following Node class <br></br>
    /// class Node : <br></br>
    ///    def __init__(self, val, left=None, right=None): <br></br>
    ///    self.val = val <br></br>
    ///   self.left = left <br></br>
    ///    self.right = right <br></br><br></br>
    ///
    /// The following test should pass: <br></br>
    ///    node = Node('root', Node('left', Node('left.left')), Node('right')) <br></br>
    ///    assert deserialize(serialize(node)).left.left.val == 'left.left' <br></br>
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

    /// <summary>
    /// Node class
    /// </summary>
    internal class Node
    {
        public string Value { get; set; }
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
    /// Serializes and Deserializes all <see cref="Node"/> from a binary tree     
    /// </summary>
    internal static class NodeSerializer
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