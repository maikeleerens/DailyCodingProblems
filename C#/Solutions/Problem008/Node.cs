namespace DailyCodingProblems.Solutions.Problem008
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
}
