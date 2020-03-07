namespace DailyCodingProblems.Solutions.Problem003
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
}
