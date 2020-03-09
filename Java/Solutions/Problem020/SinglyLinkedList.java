package Problem020;

/**
 * Singly linked list
 */
public class SinglyLinkedList<T> {
    private SinglyListNode _head;
    private int length;

    public int getLength() {
        return length;
    }

    /**
     * Adds a node at the end of the singly linked list
     * @param value
     */
    public void addLast(T value) {
        if (_head == null){
            _head = new SinglyListNode(value);
        }
        else {
            var current = _head;
            while (current.nextNode != null) {
                current = current.nextNode;
            }
            current.nextNode = new SinglyListNode(value);
        }
        length++;
    }

    /**
     * Get the first element of the singly linked list
     */
    public SinglyListNode getFirst() {
        return _head;
    }

    /**
     * Node in a singly linked list
     */
    public class SinglyListNode {
        private T value;
        private SinglyListNode nextNode;

        public SinglyListNode(T value) {
            this.value = value;
        }

        public T getValue() {
            return value;
        }

        public SinglyListNode getNextNode() {
            return nextNode;
        }

        public void setNextNode(SinglyListNode nextNode) {
            this.nextNode = nextNode;
        }
    }
}
