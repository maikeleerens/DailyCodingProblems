using System.Text;
using Xunit;

namespace Daily_Coding_Problem_3
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
    public class DailyCodingProblem3
    {
        [Fact]
        public void DailyCodingProblem3SolutionTest()
        {
            var node = new Node("root", new Node("left", new Node("left.left")), new Node("right"));

            var test2 = NodeSerializer.Deserialize(NodeSerializer.Serialize(node));

            Assert.Equal("left.left", NodeSerializer.Deserialize(NodeSerializer.Serialize(node)).Left.Left.Value);
        }
    }

    /// <summary>
    /// Node class
    /// </summary>
    public class Node
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
    /// Serializes and deserializes all nodes from a binary tree
    /// </summary>
    public static class NodeSerializer
    {
        private static int _index;

        /// <summary>
        /// Serializes the <see cref="Node"/> to a <see cref="string"/>
        /// </summary>
        /// <param name="node">The <see cref="Node"/> to serialize</param>
        /// <returns></returns>
        public static string Serialize(Node node)
        {
            return node == null ? "empty" : $"{node.Value}-{Serialize(node.Left)}-{Serialize(node.Right)}";
        }

        /// <summary>
        /// Deserializes the serialized <see cref="string"/> to a <see cref="Node"/>
        /// </summary>
        /// <param name="serializedNode">The serialized string to deserialize a <see cref="Node"/></param>
        /// <returns></returns>
        public static Node Deserialize(string serializedNode)
        {
            var nodeList = serializedNode.Split("-");

            if (_index >= nodeList.Length) _index = 0;

            if (nodeList[_index] == "empty")
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
