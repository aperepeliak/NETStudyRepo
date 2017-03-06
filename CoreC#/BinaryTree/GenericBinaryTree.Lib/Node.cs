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
        public Node<T> Parent { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data) { Data = data; }
       
        public IEnumerator<T> GetEnumerator()
        {
            if (Left != null)
                foreach (var v in Left)
                    yield return v;

            yield return Data;

            if (Right != null)
                foreach (var v in Right)
                    yield return v;
        }

        public int CompareTo(Node<T> other) => Data.CompareTo(other.Data);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
