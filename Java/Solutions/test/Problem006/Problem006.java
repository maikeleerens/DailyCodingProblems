package Problem006;

import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Dictionary;
import java.util.HashMap;
import java.util.Map;

/**
 * This problem was asked by Google.
 *
 * An XOR linked list is a more memory efficient doubly linked list.
 * Instead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node.
 *
 * Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.
 *
 * If using a language that has no pointers (such as Python),
 * you can assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.
 */
public class Problem006 {

    @Test
    public void problem006SolutionTest() {
        var XORList = new XORList<Integer>();
        XORList.add(10);
        XORList.add(20);
        XORList.add(30);

        Assert.assertEquals(10, (int)XORList.get(0));
        Assert.assertEquals(20, (int)XORList.get(1));
        Assert.assertEquals(30, (int)XORList.get(2));
    }
}

/**
 * XOR Linked list containing XOR list nodes
 */
class XORList<T> {
    private final Map<Integer, XORListNode> _memory = new HashMap<Integer, XORListNode>();
    private int _memoryAddress = 1;
    private boolean _hasNodes;

    public void add(T value) {
        if (!_hasNodes) {
            _memory.put(_memoryAddress, new XORListNode(_memoryAddress, value, 0));
            _hasNodes = true;
        } else {
            var currentNode = _memory.get(1);
            var previousNode = (XORListNode) null;

            while(true) {
                var nextNodeAddress = currentNode.getBoth() ^ (previousNode == null ? 0 : previousNode.getAddress());
                if (nextNodeAddress == 0) break;

                previousNode = currentNode;
                currentNode = _memory.get(nextNodeAddress);
            }

            var nodeToAdd = new XORListNode(_memoryAddress, value, currentNode.getAddress());
            currentNode.setBoth(currentNode.getBoth() ^ nodeToAdd.getAddress());
            _memory.put(_memoryAddress, nodeToAdd);
        }
        _memoryAddress++;
    }

    public T get(int index) {
        if (index >= _memory.size())
            throw new IndexOutOfBoundsException("Index out of bound");
        var currentNode = _memory.get(1);
        var previousNode = (XORListNode) null;

        for (var i = 0; i < index; i++) {
            var nextNodeAddress = currentNode.getBoth() ^ (previousNode == null ? 0 : previousNode.getAddress());

            previousNode = currentNode;
            currentNode = _memory.get(nextNodeAddress);
        }

        return  currentNode.getValue();
    }

    /**
     * Node in a XOR linked list
     */
    protected class XORListNode {
        private final int address;
        private final T value;
        private int both;

        public XORListNode(int address, T value, int both) {
            this.address = address;
            this.value = value;
            this.both = both;
        }

        public int getAddress() {
            return address;
        }

        public int getBoth() {
            return both;
        }

        public void setBoth(int both) {
            this.both = both;
        }

        public T getValue() {
            return value;
        }
    }
}
