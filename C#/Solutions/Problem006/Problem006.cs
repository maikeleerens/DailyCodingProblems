using System;
using System.Collections.Generic;
using Xunit;

namespace DailyCodingProblems.Solutions.Problem006
{
    /// <summary>
    /// This problem was asked by Google.
    /// 
    /// An XOR linked list is a more memory efficient doubly linked list.
    /// Instead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node.
    /// 
    /// Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.
    /// 
    /// If using a language that has no pointers(such as Python), you can assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.
    /// </summary>
    public class Problem006
    {
        [Fact]
        public void Problem006SolutionTest()
        {
            var XorList = new XorList<int>();
            XorList.Add(10);
            XorList.Add(20);
            XorList.Add(30);

            Assert.Equal(10, XorList.Get(0));
            Assert.Equal(20, XorList.Get(1));
            Assert.Equal(30, XorList.Get(2));
        }
    }
}
