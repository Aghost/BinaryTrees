using System;

namespace BTrees
{
    public class BTree
    {
        Node root;

        public BTree(int data) { root = new Node(data); }

        public void Insert(int data) {
            if (root != null) {
                root.Insert(data);
            } else {
                root = new Node(data);
            }
        }

        public Node Find(int data) {
            return root != null ? root.Find(data) : null;
        }

        // O(Log n)
        public Node FindRecursive(int data) {
            return root != null ? root.FindRecursive(data) : null;
        }

        public void Remove(int data) {
            Node current = root;
            Node parent = root;
            bool isLeft = false;

            if (current == null) {
                return;
            }

            while (current != null && current.data != data) {
                parent = current;

                if (data < current.data) {
                    current = current.left;
                    isLeft = true;
                } else {
                    current = current.right;
                    isLeft = false;
                }
            }

            // if node not found
            if (current == null) {
                return;
            }

            // check if left or right child node
            if (current.right == null && current.left == null) {
                if (current == root) {
                    root = null;
                } else {
                    if (isLeft) {
                        parent.left = null;
                    } else {
                        parent.right = null;
                    }
                }
            } else if (current.right == null) {
                if (current == root) {
                    root = current.left;
                } else {
                    if (isLeft) {
                        parent.left = current.left;
                    } else {
                        parent.right = current.left;
                    }
                }
            } else if (current.left == null) {
                if (current == root) {
                    root = current.right;
                } else {
                    if (isLeft) {
                        parent.left = current.right;
                    } else {
                        parent.right = current.right;
                    }
                }
            } else {
                Node successor = GetSuccessor(current);

                if (current == root) {
                    root = successor;
                } else if (isLeft) {
                    parent.left = successor;
                } else {
                    parent.right = successor;
                }
            }

        }

        public void InOrder() {
            if (root != null) { root.InOrder(); }
        }
        
        public void PreOrder() {
            if (root != null) { root.PreOrder(); }
        }

        public void PostOrder() {
            if (root != null) { root.PostOrder(); }
        }

        private Node GetSuccessor(Node node) {
            Node sParent = node;
            Node successor = node;
            Node current = node.right;

            while (current != null) {
                sParent = successor;
                successor = sParent;
                current = current.left;
            }

            if (successor != node.right) {
                sParent.left = successor.right;
                successor.right = node.right;
            }

            successor.left = node.left;

            return successor;
        }
    }
}
