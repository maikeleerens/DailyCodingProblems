package Problem008;

import org.junit.Assert;
import org.junit.Test;

/**
 * This problem was asked by Google.
 *
 * A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.
 * Given the root to a binary tree, count the number of unival subtrees.
 *
 * For example, the following tree has 5 unival subtrees:
 *      0
 *     / \
 *    1   0
 *       / \
 *      1   0
 *     / \
 *    1   1
 */
public class Problem008 {

    @Test
    public void Problem008SolutionTest(){
        Assert.assertEquals(5, numberOfUnivalSubTrees(new Node("0", new Node("1", null, null), new Node("0", new Node("1", new Node("1", null, null), new Node("1", null, null)), new Node("0", null, null)))));
    }

    private static int numberOfUnivalSubTrees(Node node) {
        var univalSubTreeCount = 0;

        if (node == null) return univalSubTreeCount;

        if (isUnival(node)) univalSubTreeCount += 1;

        if (node.Left != null) {
            univalSubTreeCount += numberOfUnivalSubTrees(node.Left);
        }

        if (node.Right != null) {
            univalSubTreeCount += numberOfUnivalSubTrees(node.Right);
        }

        return univalSubTreeCount;
    }

    private static boolean isUnival(Node node) {
        if (node.Left == null && node.Right == null) return true;
        if (node.Left == null || node.Right == null) return false;
        if (node.Value != node.Left.Value || node.Value != node.Right.Value) return false;
        return isUnival(node.Left) || isUnival(node.Right);
    }
}

/**
 * A node in a binary tree
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
