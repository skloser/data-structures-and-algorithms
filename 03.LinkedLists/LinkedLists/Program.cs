using System;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new KrumDoubleLinkedList(3);
            linkedList.Append(5);
            linkedList.Append(10);
            linkedList.Prepend(17);

            linkedList.Insert(18, 1);
            linkedList.Insert(18, 4);

            linkedList.Remove(2);

            var reversed = linkedList.Reverse();
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
    public class KrumDoubleLinkedList
    {
        public KrumDoubleLinkedList(int value)
        {
            var node = new Node()
            {
                Value = value,
                Next = null,
                Previous = null
            };
            this.Head = node;

            this.Tail = node;
            this.Length = 1;
        }

        public int Length { get; set; }
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void Append(int value)
        {
            var node = new Node()
            {
                Value = value,
                Previous = this.Tail,
                Next = null
            };

            node.Previous = this.Tail;
            this.Tail.Next = node;
            this.Tail = node;
            this.Length++;
        }

        public void Prepend(int value)
        {
            var node = new Node()
            {
                Value = value,
                Previous = null,
                Next = null
            };

            node.Next = this.Head;
            node.Next.Previous = node;
            this.Head = node;
            this.Length++;
        }

        public void Insert(int value, int index)
        {
            if (index >= this.Length)
            {
                this.Append(value);
                return;
            }

            if (index == 0)
            {
                this.Prepend(value);
                return;
            }

            var node = new Node()
            {
                Value = value,
                Next = null,
                Previous = null
            };

            var leaderNode = this.Traverse(index - 1);

            node.Next = leaderNode.Next;
            node.Previous = leaderNode;
            leaderNode.Next = node;
            this.Length++;
        }

        public void Remove(int index)
        {
            if (index == 0)
            {
                this.Head = this.Head.Next;
                this.Length--;
                return;
            }

            if (index >= this.Length - 1)
            {
                var beforeLastNode = this.Traverse(this.Length - 2);
                beforeLastNode.Next = null;
                this.Tail = beforeLastNode;
                this.Length--;
                return;
            }

            var currentNode = this.Traverse(index - 1);

            currentNode.Next = currentNode.Next.Next;
            currentNode.Next.Previous = currentNode;

            this.Length--;
        }

        public Node Traverse(int index)
        {
            if (index == 0)
            {
                return this.Head;
            }

            if (index >= this.Length)
            {
                return this.Tail;
            }

            var count = 0;
            var currentNode = this.Head;

            while (count != index)
            {
                currentNode = currentNode.Next;
                count++;
            }

            return currentNode;
        }

        public void PrintNodes()
        {
            var currentNode = this.Head;

            while (currentNode.Next != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }

            Console.WriteLine(this.Tail.Value);
        }

        public KrumDoubleLinkedList Reverse()
        {
            if (this.Head.Next == null)
            {
                return this;
            }

            var first = this.Head;
            this.Tail = this.Head;
            this.Tail.Previous = this.Head.Next;
            var second = this.Head.Next;

            while (second != null)
            {
                var temp = second.Next;
                second.Next = first;
                second.Previous = temp;
                first = second;
                second = temp;
            }

            this.Head.Next = null;
            this.Head = first;
            
            return this;
        }
    }
}
