using System.Collections.Generic;
using Xunit;

namespace Solutions.Problem020
{
    /// <summary>
    /// This problem was asked by Google.
    /// 
    /// Given two singly linked lists that intersect at some point, find the intersecting node. The lists are non-cyclical.
    /// 
    /// For example, given A = 3 -> 7 -> 8 -> 10 and B = 99-> 1 -> 8 -> 10, return the node with value 8.
    /// 
    /// In this example, assume nodes with the same value are the exact same node objects.
    /// 
    /// Do this in O(M + N) time (where M and N are the lengths of the lists) and constant space.
    /// </summary>
    public class Problem020
    {
        [Fact]
        public void Problem020SolutionTest()
        {
            var list1 = new SinglyLinkedList<int>();
            var list2 = new SinglyLinkedList<int>();
            list1.AddLast(1);
            list1.AddLast(2);
            list1.AddLast(3);

            Assert.Equal(3, list1.Length);
        }
    }

    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode _head;
        public int Length { get; private set; }

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

        public SinglyLinkedListNode Search(T value)
        {
            if (_head == null)
                return default;

            var current = _head;
            while (current.NextNode != null)
            {

                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    return current;
                }
                current = current.NextNode;
            }

            return current;
        }


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
