package Problem020;

import org.junit.Assert;
import org.junit.Test;


/**
 * This problem was asked by Google.
 *
 * Given two singly linked lists that intersect at some point, find the intersecting node. The lists are non-cyclical.
 *
 * For example, given A = 3 -> 7 -> 8 -> 10 and B = 99 -> 1 -> 8 -> 10, return the node with value 8.
 *
 * In this example, assume nodes with the same value are the exact same node objects.
 *
 * Do this in O(M + N) time (where M and N are the lengths of the lists) and constant space.
 */
public class Problem020 {

    @Test
    public void problem020SolutionTest(){
        var list1 = new SinglyLinkedList<Integer>();
        list1.addLast(3);
        list1.addLast(7);
        list1.addLast(8);
        list1.addLast(10);

        var list2 = new SinglyLinkedList<Integer>();
        list2.addLast(99);
        list2.addLast(1);
        list2.addLast(8);
        list2.addLast(10);

        Assert.assertEquals(8, (int)getIntersectionNode(list1, list2).getValue());
    }

    public SinglyLinkedList<Integer>.SinglyListNode getIntersectionNode(SinglyLinkedList<Integer> listA, SinglyLinkedList<Integer> listB) {
        var currentA = listA.getFirst();
        var currentB = listB.getFirst();

        if (listA.getLength() == listB.getLength()) {
            while (currentA.getValue() != currentB.getValue()) {
                currentA = currentA.getNextNode();
                currentB = currentB.getNextNode();
            }
            return currentA;
        }

        var lengthDifference = Math.abs(listA.getLength() - listB.getLength());
        if (listA.getLength() > listB.getLength()) {
            var counter = 0;
            while (currentA.getValue() != currentB.getValue()) {
                currentA = currentA.getNextNode();
                counter++;
                if (counter <= lengthDifference) continue;
                currentB = currentB.getNextNode();
            }
            return currentA;
        } else {
            var counter = 0;
            while (currentA.getValue() != currentB.getValue()) {
                currentB = currentB.getNextNode();
                counter++;
                if (counter <= lengthDifference) continue;
                currentA = currentA.getNextNode();
            }
        }
        return currentA;
    }
}
