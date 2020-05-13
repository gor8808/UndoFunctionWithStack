using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack.List
{
    /// <summary>
    /// A Last In First Out (LIFO) collection implemented as a linked list.
    /// </summary>
    /// <typeparam name="T">The type of item contained in the stack</typeparam>
    class Stack<T> : IEnumerable<T>
    {
        private LinkedList<T> _list =  new LinkedList<T>();

        /// <summary>
        /// Adds the specified item to the stack
        /// </summary>
        /// <param name="item">The item</param>
        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        /// <summary>
        /// Removes and returns the top item from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Pop()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T value = _list.First.Value;
            _list.RemoveFirst();

            return value;
        }

        /// <summary>
        /// Returns the top item from the stack without removing it from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return _list.First.Value;
        }

        /// <summary>
        /// The current number of items in the stack
        /// </summary>
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        /// <summary>
        /// Removes all items from the stack
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
