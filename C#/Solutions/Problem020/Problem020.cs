using System;
using Xunit;

namespace DailyCodingProblems.Solutions.Problem020
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
            list1.AddLast(3);
            list1.AddLast(7);
            list1.AddLast(8);
            list1.AddLast(10);

            var list2 = new SinglyLinkedList<int>();
            list2.AddLast(99);
            list2.AddLast(1);
            list2.AddLast(8);
            list2.AddLast(10);

            Assert.Equal(new SinglyLinkedList<int>.SinglyLinkedListNode(8).Value, GetIntersectionNode(list1, list2).Value);
        }

        public SinglyLinkedList<int>.SinglyLinkedListNode GetIntersectionNode(SinglyLinkedList<int> listA,
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
