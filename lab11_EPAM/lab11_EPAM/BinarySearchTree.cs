using System;
using System.Collections;
using System.Collections.Generic;

namespace lab11_EPAM
{
    public sealed class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node _root;
        private readonly IComparer<T> _comparer;

        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (ReferenceEquals(null, collection))
                throw new ArgumentNullException(nameof(collection));
            if (ReferenceEquals(null, comparer))
            {
                _comparer = Comparer<T>.Default;

            }
            else
            {
                _comparer = comparer;
            }
            foreach (var elem in collection)
            {
                Add(elem);
            }
        }

        public BinarySearchTree(IEnumerable<T> collection) : this(collection, null)
        {
        }

        public BinarySearchTree() { }

        /// <returns>enumerator для foreach</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var value in collection)
            {
                Add(value);
            }
        }

        public void Add(T elem)
        {
            if (ReferenceEquals(null, elem))
                throw new ArgumentNullException();
            if (ReferenceEquals(null, _root))
            {
                _root = new Node(elem);
                return;
            }
            Node currentRoot = _root;
            Node dadyRoot = null;

            while (!ReferenceEquals(null, currentRoot))
            {
                if (_comparer.Compare(currentRoot.Value, elem) == 0)
                    return;
                dadyRoot = currentRoot;
                if (_comparer.Compare(currentRoot.Value, elem) < 0)
                    currentRoot = currentRoot.Right;
                else
                    currentRoot = currentRoot.Left;
            }

            if (_comparer.Compare(dadyRoot.Value, elem) > 0)
                dadyRoot.Left = new Node(elem);
            else
                dadyRoot.Right = new Node(elem);

        }

        public void Clear()
        {
            _root = null;

        }

        // Начинает обход с корневого элемента
        public IEnumerable<T> PreOrder() => PreOrder(_root);

        // Начинает обход с корневого элемента
        public IEnumerable<T> PostOrder() => PostOrder(_root);

        // Начинает обход с корневого элемента
        public IEnumerable<T> InOrder() => InOrder(_root);

        private class Node
        {
            private T _value;
            public T Value
            {
                get { return _value; }
            }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(T value)
            {
                _value = value;
            }

        }

        private IEnumerable<T> PostOrder(Node node)
        {
            if (node == null)
                yield break;

            foreach (var e in PostOrder(node.Left))
                yield return e;

            foreach (var e in PostOrder(node.Right))
                yield return e;

            yield return node.Value;
        }


        private IEnumerable<T> PreOrder(Node node)
        {
            if (node == null)
                yield break;

            yield return node.Value;

            foreach (var e in PreOrder(node.Left))
                yield return e;

            foreach (var e in PreOrder(node.Right))
                yield return e;
        }

        private IEnumerable<T> InOrder(Node node)
        {
            if (node == null)
                yield break;

            foreach (var n in InOrder(node.Left))
                yield return n;

            yield return node.Value;
            foreach (var n in InOrder(node.Right))
                yield return n;
        }
    }
}