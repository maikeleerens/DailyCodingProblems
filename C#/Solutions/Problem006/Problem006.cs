using System;
using System.Collections.Generic;
using Xunit;

namespace Solutions.Problem006
{
    /// <summary>
    /// This problem was asked by Google.
    /// An XOR linked list is a more memory efficient doubly linked list. Instead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node.
    /// Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.
    /// If using a language that has no pointers(such as Python), you can assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.
    /// </summary>
    public class Problem006
    {
        [Fact]
        public void Problem006SolutionTest()
        {
            var XORList = new XORList<int>();
            XORList.Add(10);
            XORList.Add(20);
            XORList.Add(30);

            Assert.Equal(10, XORList.Get(0));
            Assert.Equal(20, XORList.Get(1));
            Assert.Equal(30, XORList.Get(2));
        }
    }

    /// <summary>
    /// XOR linked list containing <see cref="XORListNode{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class XORList<T>
    {
        private readonly Dictionary<int, XORListNode<T>> _memory = new Dictionary<int, XORListNode<T>>();
        private int _memoryAddressCounter;
        private int _listItemCount;
        private int _firstNode;
        private int _lastNode;

        public XORList()
        {
            _memory.Add(0, new XORListNode<T>{MemoryAddress = 0, Both = 0 ^ 0});
            _memoryAddressCounter = 1;
            _listItemCount = 0;
            _firstNode = 0;
            _lastNode = 0;
        }

        public void Add(T value)
        {
            if (_memory[_firstNode].MemoryAddress == 0)
            {
                _memory.Add(_memoryAddressCounter, new XORListNode<T>{MemoryAddress = _memoryAddressCounter, Both = 0 ^ 0, Value = value});
                _firstNode = _memoryAddressCounter;
                _lastNode = _firstNode;
            }
            else
            {
                var lastNode = _memory[_lastNode];
                var nodeToAdd = new XORListNode<T>{MemoryAddress = _memoryAddressCounter, Both = 0 ^ lastNode.MemoryAddress, Value = value};
                lastNode.Both ^= nodeToAdd.MemoryAddress;
                _lastNode = _memoryAddressCounter;
                _memory.Add(_memoryAddressCounter, nodeToAdd);
            }

            _listItemCount++;
            _memoryAddressCounter++;
        }

        public T Get(int index)
        {
            if (index >= _listItemCount) throw new IndexOutOfRangeException("Index out of range");
            var currentNode = _memory[_firstNode];
            var previousNode = _memory[0];

            for (var i = 0; i < index; i++)
            {
                var address = previousNode.MemoryAddress ^ currentNode.Both;
                previousNode = currentNode;
                currentNode = _memory[address];
            }

            return currentNode.Value;
        }
    }

    /// <summary>
    /// Nodes in a <see cref="XORList{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class XORListNode<T>
    {
        public int MemoryAddress { get; set; }
        public int Both { get; set; }
        public T Value { get; set; }
    }
}
