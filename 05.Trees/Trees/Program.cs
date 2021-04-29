using System;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree();
            tree.Insert(9);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(20);
            tree.Insert(170);
            tree.Insert(15);
            tree.Insert(1);

            var lookup6 = tree.Lookup(20);
        }

        public class Node
        {
            public Node(int value)
            {
                this.Value = value;
                this.Left = null;
                this.Right = null;
            }

            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        public class BinarySearchTree
        {
            public BinarySearchTree()
            {
                this.Root = null;
            }

            public Node Root { get; set; }

            public Node Lookup(int value)
            {
                if (this.Root == null)
                {
                    return null;
                }

                return Lookup(this.Root, value);
            }

            private Node Lookup(Node node, int value)
            {
                if (node == null)
                {
                    return null;
                }

                if (node.Value == value)
                {
                    return node;
                }

                if (value < node.Value)
                {
                    return Lookup(node.Left, value);
                }
                else
                {
                    return Lookup(node.Right, value);
                }
            }

            public void Insert(int value)
            {
                var newNode = new Node(value);

                if (this.Root == null)
                {
                    this.Root = newNode;
                    return;
                }
                else
                {
                    this.Insert(this.Root, newNode);
                }
            }

            private void Insert(Node parentNode, Node newNode)
            {
                if (newNode.Value < parentNode.Value)
                {
                    if (parentNode.Left == null)
                    {
                        parentNode.Left = newNode;
                        return;
                    }
                    else
                    {
                        this.Insert(parentNode.Left, newNode);
                    }
                }
                else
                {
                    if (parentNode.Right == null)
                    {
                        parentNode.Right = newNode;
                        return;
                    }
                    else
                    {
                        this.Insert(parentNode.Right, newNode);
                    }
                }
            }
        }
    }
}
