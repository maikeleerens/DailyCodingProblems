package Problem006;

import java.util.HashMap;
import java.util.Map;

/**
 * XOR Linked list containing XOR list nodes
 */
public class XorList<T> {
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
    public class XORListNode {
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
