import org.junit.Assert;
import org.junit.Test;

/**
 * This problem was asked by Google.
 * Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
 * For example, given the following Node class
 * class Node:
 *     def __init__(self, val, left=None, right=None):
 *         self.val = val
 *         self.left = left
 *         self.right = right
 *
 * The following test should pass:
 * node = Node('root', Node('left', Node('left.left')), Node('right'))
 * assert deserialize(serialize(node)).left.left.val == 'left.left'
 */
public class DailyCodingProblem3 {

    @Test
    public void DailyCodingProblem3SolutionTest(){
        var node = new Node("root",new Node("left",new Node("left.left", null, null) ,null) ,new Node("right", null, null) );

        Assert.assertEquals("left.left", NodeSerializer.Deserialize(NodeSerializer.Serialize(node)).Left.Left.Value);
    }
}

/**
 * Node class
 */
class Node {
    public String Value;
    public Node Left;
    public Node Right;

    public Node(String value, Node left, Node right) {
        Value = value;
        Left = left;
        Right = right;
    }
}

/**
 * Serializes and deserializes all Nodes from a binary tree
 */
class NodeSerializer {
    private static int _index;

    public static String Serialize(Node node) {
        return node == null ? "empty" : node.Value + "-" + Serialize(node.Left) + "-" + Serialize(node.Right);
    }

    public static Node Deserialize(String serializedNode) {
        var nodeList = serializedNode.split("-");

        if (_index >= nodeList.length) _index = 0;

        if (nodeList[_index].contains("empty"))
        {
            _index++;
            return null;
        }

        var nodeToReturn = new Node(nodeList[_index], null, null);
        _index++;
        nodeToReturn.Left = Deserialize(serializedNode);
        nodeToReturn.Right = Deserialize(serializedNode);
        return nodeToReturn;
    }
}
