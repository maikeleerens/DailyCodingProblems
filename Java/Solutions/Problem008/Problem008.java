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
        Assert.assertEquals(5, numberOfUniversalSubTrees(new Node("0", new Node("1", null, null), new Node("0", new Node("1", new Node("1", null, null), new Node("1", null, null)), new Node("0", null, null)))));
    }

    public static int numberOfUniversalSubTrees(Node node) {
        var universalSubTreeCount = 0;

        if (node == null) return universalSubTreeCount;

        if (isUniversal(node)) universalSubTreeCount += 1;

        if (node.getLeft() != null) {
            universalSubTreeCount += numberOfUniversalSubTrees(node.getLeft());
        }

        if (node.getRight() != null) {
            universalSubTreeCount += numberOfUniversalSubTrees(node.getRight());
        }

        return universalSubTreeCount;
    }

    private static boolean isUniversal(Node node) {
        if (node.getLeft() == null && node.getRight() == null) return true;
        if (node.getLeft() == null || node.getRight() == null) return false;
        if (node.getValue() != node.getLeft().getValue() || node.getValue() != node.getRight().getValue()) return false;
        return isUniversal(node.getLeft()) || isUniversal(node.getRight());
    }
}

