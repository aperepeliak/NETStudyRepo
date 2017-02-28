using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinaryTree.Lib
{
    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; } = null;
        public Node<T> Left { get; set; } = null;
        public Node<T> Right { get; set; } = null;

        public Node(T d) { Data = d; }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}
