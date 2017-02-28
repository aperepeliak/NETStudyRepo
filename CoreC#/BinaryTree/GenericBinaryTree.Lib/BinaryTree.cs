using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinaryTree.Lib
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public Node<T> Root { get; protected set; }
        public BinaryTree(T root) { Root = new Node<T>(root); }

        public void Add(T data)
        {
            var node = new Node<T>(data);
            Node<T> tmp = null;
            Node<T> _current = Root;

            while (_current != null)
            {
                tmp = _current;
                if (node.Data.CompareTo(_current.Data) == -1)
                {
                    _current = _current.Left;
                }
                else
                {
                    _current = _current.Right;
                }
            }

            node.Parent = tmp;

            if (tmp == null)
            {
                Root = node;
            }
            else
            {
                if (node.Data.CompareTo(tmp.Data) == -1)
                {
                    tmp.Left = node;
                }
                else
                {
                    tmp.Right = node;
                }
            }
        }

        public IEnumerator<T> GetEnumerator() => Root.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
