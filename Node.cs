using System;
using static System.Console;

namespace BTrees
{
    public class Node
    {
        public Node left = null;
        public Node right = null;
        public int data;

        public Node(int data) {
            this.data = data;
        }

        public void Insert(int data) {
            if (data >= this.data) {
                if (right == null) {
                    right = new Node(data);
                } else {
                    right.Insert(data);
                }
            } else {
                if (left == null) {
                    left = new Node(data);
                } else {
                    left.Insert(data);
                }
            }
        }

        public Node Find(int data) {
            Node current = this;

            while (current != null) {
                if (data == current.data) {
                    return current;
                } else if (data > current.data) {
                    current = current.right;
                } else {
                    current = current.left;
                }
            }

            return null;
        }

        public Node FindRecursive(int data) {
            if (data == this.data) {
                return this;
            } else if (data < this.data && left != null) {
                return left.FindRecursive(data);
            } else if (right != null) {
                return right.FindRecursive(data);
            } else {
                return null;
            }
        }

        public void InOrder() {
            if (left != null) { left.InOrder(); }
            WriteLine(data);
            if (right != null) { right.InOrder(); }
        }

        public void PreOrder() {
            WriteLine(data);
            if (left != null) { left.PreOrder(); }
            if (right != null) { right.PreOrder(); }
        }

        public void PostOrder() {
            if (left != null) { left.PostOrder(); }
            if (right != null) { right.PostOrder(); }
            WriteLine(data);
        }
    }
}
