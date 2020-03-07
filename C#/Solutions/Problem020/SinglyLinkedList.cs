namespace DailyCodingProblems.Solutions.Problem020
{
    /// <summary>
    /// Singly linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode _head;
        public int Length { get; private set; }

        /// <summary>
        /// Adds a <see cref="SinglyLinkedListNode"/> as last element in the <see cref="SinglyLinkedList{T}"/>
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            if (_head == null)
            {
                _head = new SinglyLinkedListNode(value);
            }
            else
            {
                var current = _head;
                while (current.NextNode != null)
                {
                    current = current.NextNode;
                }
                current.NextNode = new SinglyLinkedListNode(value);
            }
            Length++;
        }

        /// <summary>
        /// Gets the first <see cref="SinglyLinkedListNode"/> from a <see cref="SinglyLinkedList{T}"/>
        /// </summary>
        /// <returns></returns>
        public SinglyLinkedListNode GetFirst()
        {
            return _head;
        }

        /// <summary>
        /// Node in a <see cref="SinglyLinkedList{T}"/>
        /// </summary>
        public class SinglyLinkedListNode
        {
            public T Value { get; }
            public SinglyLinkedListNode NextNode { get; set; }

            public SinglyLinkedListNode(T value)
            {
                Value = value;
                NextNode = null;
            }
        }
    }
}
