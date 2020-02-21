package Problem003;

import org.junit.Assert;
import org.junit.Test;

/**
 * This problem was asked by Google.
 * Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
 * For example, given the following Problem003.Node class
 * class Problem003.Node:
 *     def __init__(self, val, left=None, right=None):
 *         self.val = val
 *         self.left = left
 *         self.right = right
 *
 * The following test should pass:
 * node = Problem003.Node('root', Problem003.Node('left', Problem003.Node('left.left')), Problem003.Node('right'))
 * assert deserialize(serialize(node)).left.left.val == 'left.left'
 */
public class Problem003 {

    @Test
    public void problem003SolutionTest(){
        var node = new Node("root",new Node("left",new Node("left.left", null, null) ,null) ,new Node("right", null, null) );

        Assert.assertEquals("left.left", NodeSerializer.deserialize(NodeSerializer.serialize(node)).getLeft().getLeft().getValue());
    }
}

/**
 * A node in a binary tree
 */
class Node {
    private final String value;
    private Node left;
    private Node right;

    public Node(String value, Node left, Node right) {
        this.value = value;
        this.left = left;
        this.right = right;
    }

    public String getValue() {
        return value;
    }

    public Node getLeft() {
        return left;
    }

    public void setLeft(Node left) {
        this.left = left;
    }

    public Node getRight() {
        return right;
    }

    public void setRight(Node right) {
        this.right = right;
    }
}

/**
 * Serializes and deserializes all Nodes from a binary tree
 */
class NodeSerializer {
    private static int _index;

    public static String serialize(Node node) {
        return node == null ? "empty" : node.getValue() + "-" + serialize(node.getLeft()) + "-" + serialize(node.getRight());
    }

    public static Node deserialize(String serializedNode) {
        var nodeList = serializedNode.split("-");

        if (_index >= nodeList.length) _index = 0;

        if (nodeList[_index].contains("empty"))
        {
            _index++;
            return null;
        }

        var nodeToReturn = new Node(nodeList[_index], null, null);
        _index++;
        nodeToReturn.setLeft(deserialize(serializedNode));
        nodeToReturn.setRight(deserialize(serializedNode));
        return nodeToReturn;
    }
}
