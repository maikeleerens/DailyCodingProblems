using Solutions;
using Xunit;

namespace SolutionsTest
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
    public class Problem020Test
    {
        [Fact]
        public void Problem020SolutionTest()
        {
            var list1 = new Problem020.SinglyLinkedList<int>();
            list1.AddLast(3);
            list1.AddLast(7);
            list1.AddLast(8);
            list1.AddLast(10);

            var list2 = new Problem020.SinglyLinkedList<int>();
            list2.AddLast(99);
            list2.AddLast(1);
            list2.AddLast(8);
            list2.AddLast(10);

            Assert.Equal(new Problem020.SinglyLinkedList<int>.SinglyLinkedListNode(8).Value, Problem020.GetIntersectionNode(list1, list2).Value);
        }
    }
}
