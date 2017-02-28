using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinaryTree.Lib
{
    public class Node<T> : IEnumerable<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; } = null;
        public Node<T> Left { get; set; } = null;
        public Node<T> Right { get; set; } = null;

        public Node(T data) { Data = data; }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Left != null)
            {
                foreach (var v in Left)
                {
                    yield return v;
                }
            }

            yield return Data;

            if (Right != null)
            {
                foreach (var v in Right)
                {
                    yield return v;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
