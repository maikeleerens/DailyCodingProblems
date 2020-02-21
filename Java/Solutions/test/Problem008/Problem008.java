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
    public void problem008SolutionTest(){
        Assert.assertEquals(5, numberOfUnivalSubTrees(new Node("0", new Node("1", null, null), new Node("0", new Node("1", new Node("1", null, null), new Node("1", null, null)), new Node("0", null, null)))));
    }

    public static int numberOfUnivalSubTrees(Node node) {
        var univalSubTreeCount = 0;

        if (node == null) return univalSubTreeCount;

        if (isUnival(node)) univalSubTreeCount += 1;

        if (node.getLeft() != null) {
            univalSubTreeCount += numberOfUnivalSubTrees(node.getLeft());
        }

        if (node.getRight() != null) {
            univalSubTreeCount += numberOfUnivalSubTrees(node.getRight());
        }

        return univalSubTreeCount;
    }

    private static boolean isUnival(Node node) {
        if (node.getLeft() == null && node.getRight() == null) return true;
        if (node.getLeft() == null || node.getRight() == null) return false;
        if (node.getValue() != node.getLeft().getValue() || node.getValue() != node.getRight().getValue()) return false;
        return isUnival(node.getLeft()) || isUnival(node.getRight());
    }
}

/**
 * A node in a binary tree
 */
class Node {
    private final String value;
    private final Node left;
    private final Node right;

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

    public Node getRight() {
        return right;
    }
}
