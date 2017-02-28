using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinaryTree.Lib
{
    public class BinaryTree<T> : IEnumerable<T>, IEnumerator<T> where T : IComparable<T>
    {
        private Node<T> _current;

        public Node<T> Root { get; }
        public T Current
        {
            get { _current = _current ?? Root; return _current.Data; }
        }


        public void Add(T d)
        {

        }



        public bool MoveNext()
        {
            if (_current == null) return false;

        }

        public void Reset() => _current = Root;

        object IEnumerator.Current => Current;

        public IEnumerator<T> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => this;

        void IDisposable.Dispose() { }
    }
}
