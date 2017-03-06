using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinaryTree.Lib
{
    public class OrdinaryBinaryTree<T> : BinaryTree<T> where T : IComparable<T>
    {
        public OrdinaryBinaryTree(T root) : base(root) { }

        public override void Add(T data)
        {
            if (data == null) throw new NullReferenceException("Input data of null");

            Node<T> node = new Node<T>(data);
            Node<T> tmp = null;
            Node<T> current = _root;

            while (current != null)
            {
                tmp = current;
                if (node.CompareTo(current) == -1) current = current.Left;
                else current = current.Right;
            }

            node.Parent = tmp;

            if (tmp == null) _root = node;
            else
            {
                if (node.CompareTo(tmp) == -1) tmp.Left = node;
                else tmp.Right = node;
            }

            OnElementAdded(new ElementAddedEventArgs<T>(data));
        }

        public override void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
                Add(item);
        }

        public override void Delete(Node<T> node)
        {
            // Method implementation ...
            OnElementDeleted(new ElementDeletedEventArgs<T>(node.Data));
        }
    }
}
