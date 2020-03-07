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

