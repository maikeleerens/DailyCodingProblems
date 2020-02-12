package Problem006;

import org.junit.Assert;
import org.junit.Test;

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
    public void Problem006SolutionTest() {
        var XORList = new XORList<Integer>();
        XORList.Add(10);
        XORList.Add(20);
        XORList.Add(30);

        Assert.assertEquals(10, (int)XORList.Get(0));
        Assert.assertEquals(20, (int)XORList.Get(1));
        Assert.assertEquals(30, (int)XORList.Get(2));
    }
}

/**
 * XOR Linked list containing XOR list nodes
 */
class XORList<T> {
    private final Map<Integer, XORListNode<T>> _memory = new HashMap<Integer, XORListNode<T>>();
    private int _memoryAddress = 1;
    private boolean _hasNodes;

    public void Add(T value) {
        if (!_hasNodes) {
            _memory.put(_memoryAddress, new XORListNode<T>(_memoryAddress, 0, value));
            _hasNodes = true;
        } else {
            var currentNode = _memory.get(1);
            var previousNode = (XORListNode)null;

            while(true) {
                var nextNodeAddress = currentNode.Both ^ (previousNode == null ? 0 : previousNode.Address);
                if (nextNodeAddress == 0) break;

                previousNode = currentNode;
                currentNode = _memory.get(nextNodeAddress);
            }

            var nodeToAdd = new XORListNode<T>(_memoryAddress, currentNode.Address, value);
            currentNode.Both ^= nodeToAdd.Address;
            _memory.put(_memoryAddress, nodeToAdd);
        }
        _memoryAddress++;
    }

    public T Get(int index) {
        if (index >= _memory.size())
            throw new IndexOutOfBoundsException("Index out of bound");
        var currentNode = _memory.get(1);
        var previousNode = (XORListNode)null;

        for (var i = 0; i < index; i++) {
            var nextNodeAddress = currentNode.Both ^ (previousNode == null ? 0 : previousNode.Address);

            previousNode = currentNode;
            currentNode = _memory.get(nextNodeAddress);
        }

        return  currentNode.Value;
    }
}

/**
 * Node in a XOR linked list
 */
class XORListNode<T> {
    public int Address;
    public int Both;
    public T Value;

    public XORListNode(int address, int both, T value) {
        Address = address;
        Both = both;
        Value = value;
    }
}
