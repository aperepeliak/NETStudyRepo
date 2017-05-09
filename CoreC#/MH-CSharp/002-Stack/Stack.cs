using System;
using System.Collections.Generic;
using System.Linq;

namespace _002_Stack
{
    public class Stack
    {
        private List<object> _container;
        private int _head;

        public Stack()
        {
            _container = new List<object>();
        }

        public void Push(object obj)
        {
            if (obj == null)
                throw new InvalidOperationException("Storing nulls is forbidden");

            _container.Add(obj);
            _head++;
        }

        public object Pop()
        {
            if (_head == 0)
                throw new InvalidOperationException("The stack is empty.");

            _head--;
            var obj = _container[_head];

            _container = _container.Take(_head).ToList();
            return obj;
        }

        public void Clear()
        {
            _container = new List<object>();
            _head = 0;
        }
    }
}
