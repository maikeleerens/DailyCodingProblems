namespace DailyCodingProblems.Solutions.Problem003
{
    /// <summary>
    /// Serializes and deserializes all <see cref="Node"/> from a binary tree     
    /// </summary>
    public class NodeSerializer
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
