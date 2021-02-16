using System;

namespace Solutions
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
    public  static class Problem020
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
        }

        public static SinglyLinkedList<int>.SinglyLinkedListNode GetIntersectionNode(SinglyLinkedList<int> listA,
            SinglyLinkedList<int> listB)
        {
            var currentA = listA.GetFirst();
            var currentB = listB.GetFirst();

            if (listA.Length == listB.Length)
            {
                while (currentA.Value != currentB.Value)
                {
                    currentA = currentA.NextNode;
                    currentB = currentB.NextNode;
                }

                return currentA;
            }

            var lengthDifference = Math.Abs(listA.Length - listB.Length);
            if (listA.Length > listB.Length)
            {
                var counter = 0;
                while (currentA.Value != currentB.Value)
                {
                    currentA = currentA.NextNode;
                    counter++;
                    if (counter <= lengthDifference) continue;
                    currentB = currentB.NextNode;
                }

                return currentA;
            }
            else
            {
                var counter = 0;
                while (currentA.Value != currentB.Value)
                {
                    currentB = currentB.NextNode;
                    counter++;
                    if (counter <= lengthDifference){ continue;}
                    currentA = currentA.NextNode;
                }

                return currentA;
            }
        }
    }
}
