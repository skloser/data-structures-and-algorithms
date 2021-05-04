using System;
using System.Collections.Generic;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tree = new BinarySearchTree();
            //tree.Insert(9);
            //tree.Insert(4);
            //tree.Insert(6);
            //tree.Insert(20);
            //tree.Insert(170);
            //tree.Insert(15);
            //tree.Insert(1);

            //Console.WriteLine(string.Join(" ", tree.BreadthFirstSearch()));
            //var queue = new Queue<Node>();
            //queue.Enqueue(tree.Root);
            //Console.WriteLine(string.Join(" ", tree.BreadthFirstSearchRecursive(queue, new List<int>())));
            //Console.WriteLine(string.Join(" ", tree.DeapthFSInOrder()));
            //Console.WriteLine(string.Join(" ", tree.DeapthFSPreOrder()));
            //Console.WriteLine(string.Join(" ", tree.DeapthFSPostOrder()));

            var leftTree = new TreeNode(4, null, null);
            var rightTree = new TreeNode(6, new TreeNode(3), new TreeNode(7));

            var treeNode = new TreeNode(5, leftTree, rightTree);

            Console.WriteLine(treeNode.IsValidBST(treeNode));
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

            public int[] BreadthFirstSearch()
            {
                var currentNode = this.Root;
                var list = new List<int>();
                var queue = new Queue<Node>();
                queue.Enqueue(currentNode);

                while (queue.Count > 0)
                {
                    currentNode = queue.Dequeue();
                    list.Add(currentNode.Value);

                    if (currentNode.Left != null)
                    {
                        queue.Enqueue(currentNode.Left);
                    }

                    if (currentNode.Right != null)
                    {
                        queue.Enqueue(currentNode.Right);
                    }
                }

                return list.ToArray();
            }

            public int[] BreadthFirstSearchRecursive(Queue<Node> queue, List<int> list)
            {
                if (queue.Count == 0)
                {
                    return list.ToArray();
                }

                var currentNode = queue.Dequeue();
                list.Add(currentNode.Value);

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }

                return this.BreadthFirstSearchRecursive(queue, list);
            }

            public int[] DeapthFSInOrder()
            {
                return TraverseInOrder(this.Root, new List<int>());
            }

            private int[] TraverseInOrder(Node node, List<int> list)
            {
                if (node.Left != null)
                {
                    TraverseInOrder(node.Left, list);
                }

                list.Add(node.Value);

                if (node.Right != null)
                {
                    TraverseInOrder(node.Right, list);
                }

                return list.ToArray();
            }

            public int[] DeapthFSPostOrder()
            {
                return TraversePostOrder(this.Root, new List<int>());
            }

            private int[] TraversePostOrder(Node node, List<int> list)
            {

                if (node.Left != null)
                {
                    TraversePostOrder(node.Left, list);
                }

                if (node.Right != null)
                {
                    TraversePostOrder(node.Right, list);
                }

                list.Add(node.Value);

                return list.ToArray();
            }

            public int[] DeapthFSPreOrder()
            {
                return TraversePreOrder(this.Root, new List<int>());
            }

            private int[] TraversePreOrder(Node node, List<int> list)
            {
                list.Add(node.Value);

                if (node.Left != null)
                {
                    TraversePreOrder(node.Left, list);
                }

                if (node.Right != null)
                {
                    TraversePreOrder(node.Right, list);
                }

                return list.ToArray();
            }




        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }

            public bool IsValidBST(TreeNode root)
            {
                if (root == null)
                {
                    return true;
                }

                if (root.left != null && root.left.val >= root.val)
                {
                    return false;
                }

                if (root.right != null && root.right.val <= root.val)
                {
                    return false;
                }

                return IsValidBST(root.left) && IsValidBST(root.right);
            }
        }
    }
}
