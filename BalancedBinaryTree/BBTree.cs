using System;

namespace BalancedBinaryTree
{
    public class BBTree<T> where T : IComparable<T>
    {
        private Node root = null;

        public bool Contains(T value)
        {
            return FindNodeWithValue(root, value) != null;
        }

        public void Add(T value)
        {
            Add(value, ref root);
        }

        private void Add(T value, ref Node at)
        {
            if (at == null)
            {
                at = new Node {Value = value};
            }
            else if (value.IsSmallerThan(at.Value))
            {
                var left = at.Left;
                Add(value, ref left);
                at.Left = left;
            }
            else if (value.IsLargerThan(at.Value))
            {
                var right = at.Right;
                Add(value, ref right);
                at.Right = right;
            }
        }

        internal Node FindNodeWithValue(Node at, T value)
        {
            if (at.Value.Equals(value)) return at;
            if (value.IsSmallerThan(at.Value))
            {
                return FindNodeWithValue(at.Left, value);
            }
            else
            {
                return FindNodeWithValue(at.Right, value);
            }
        }

        internal class Node
        {
            public T Value { get; set; }
            public Node Left;
            public Node Right;
            public int Height { get; set; } = 1;

            private void UpdateNodeHeight(Node root)
            {
                root.Height = Math.Max(Left?.Height ?? 0, Right?.Height ?? 0) + 1;
            }
        }
    }

    internal static class NodeExtensions
    {
        public static bool IsSmallerThan<T>(this T left, T right) where T : IComparable<T>
            => left.CompareTo(right) < 0;

        public static bool IsLargerThan<T>(this T left, T right)
            where T : IComparable<T>
            => left.CompareTo(right) > 0;
    }
}
