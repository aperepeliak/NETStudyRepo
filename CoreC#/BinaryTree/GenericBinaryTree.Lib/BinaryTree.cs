using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinaryTree.Lib
{
    public enum TraverseMethod { preOrder, inOrder, postOrder }

    public interface IBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        T Root { get; }

        event Action<T> ElementAdded;
        event Action<T> ElementDeleted;

        void Add(T data);
        void AddRange(IEnumerable<T> range);
    }

    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        Node<T> _root;
        public T Root { get; }

        public BinaryTree(T root) { _root = new Node<T>(root); }

        public event Action<T> ElementAdded;
        public event Action<T> ElementDeleted;

        public void Add(T data)
        {
            if (data == null) throw new NullReferenceException("Input data of null");

            Node<T> node = new Node<T>(data);
            Node<T> tmp = null;
            Node<T> current = _root;

            while (current != null)
            {
                tmp = current;
                if (node.Data.CompareTo(current.Data) == -1) current = current.Left;
                else current = current.Right;
            }

            node.Parent = tmp;

            if (tmp == null) _root = node;
            else
            {
                if (node.Data.CompareTo(tmp.Data) == -1) tmp.Left = node;
                else tmp.Right = node;
            }

            ElementAdded?.Invoke(data);
        }
        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range) { Add(item); }
        }

        public IEnumerable<T> Iterate(TraverseMethod method)
        {
            if (method == TraverseMethod.preOrder)
                return PreOrder(_root);

            if (method == TraverseMethod.inOrder)
                return InOrder(_root);

            if (method == TraverseMethod.postOrder)
                return PostOrder(_root);

            return null;
        }

        public IEnumerator<T> GetEnumerator() => _root.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            if (node == null)
                yield break;

            yield return node.Data;

            if (node.Left != null)
                foreach (var item in PreOrder(node.Left))
                    yield return item;

            if (node.Right != null)
                foreach (var item in PreOrder(node.Right))
                    yield return item;
        }
        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node == null)
                yield break;

            if (node.Left != null)
                foreach (var item in InOrder(node.Left))
                    yield return item;

            yield return node.Data;

            if (node.Right != null)
                foreach (var item in InOrder(node.Right))
                    yield return item;
        }
        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node == null)
                yield break;

            if (node.Left != null)
                foreach (var item in PostOrder(node.Left))
                    yield return item;

            if (node.Right != null)
                foreach (var item in PostOrder(node.Right))
                    yield return item;

            yield return node.Data;
        }
    }
}
