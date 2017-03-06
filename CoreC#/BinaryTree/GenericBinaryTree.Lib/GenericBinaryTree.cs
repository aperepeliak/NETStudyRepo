using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinaryTree.Lib
{
    public enum TraverseMethod { preOrder, inOrder, postOrder }

    public abstract class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        protected Node<T> _root;
        public T Root => _root.Data;

        public BinaryTree(T root) { _root = new Node<T>(root); }

        public event EventHandler<ElementAddedEventArgs<T>> ElementAdded;
        public event EventHandler<ElementDeletedEventArgs<T>> ElementDeleted;

        protected virtual void OnElementAdded(ElementAddedEventArgs<T> e)
            => ElementAdded?.Invoke(this, e);
        protected virtual void OnElementDeleted(ElementDeletedEventArgs<T> e)
            => ElementDeleted?.Invoke(this, e);

        public abstract void Add(T data);
        public abstract void AddRange(IEnumerable<T> range);
        public abstract void Delete(Node<T> node);

        public IEnumerator<T> GetEnumerator() => _root.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual IEnumerable<T> Iterate(TraverseMethod method)
        {
            if (method == TraverseMethod.preOrder)
                return PreOrder(_root);

            if (method == TraverseMethod.inOrder)
                return InOrder(_root);

            if (method == TraverseMethod.postOrder)
                return PostOrder(_root);

            return null;
        }

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

    public class ElementAddedEventArgs<T> : EventArgs
    {
        public readonly T NewElement;
        public ElementAddedEventArgs(T newElement) { NewElement = newElement; }
    }

    public class ElementDeletedEventArgs<T> : EventArgs
    {
        public readonly T DeletedElement;
        public ElementDeletedEventArgs(T deletedElement) { DeletedElement = deletedElement; }
    }
}
