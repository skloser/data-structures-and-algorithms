using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            //var stack = new KrumStack();
            //stack.Push(5);
            //stack.Push(10);
            //stack.Push(15);
            //Console.WriteLine(stack.Peek().Value);
            //Console.WriteLine(stack.Pop().Value);

            //var queue = new KrumQueue();
            //queue.Enqueue(5);
            //queue.Enqueue(12);
            //queue.Enqueue(15);
            //queue.Enqueue(22);
            //Console.WriteLine(queue.Dequeue().Value);
            //Console.WriteLine(queue.Dequeue().Value);
            //Console.WriteLine(queue.Dequeue().Value);
            //Console.WriteLine(queue.Dequeue().Value);

            var myQueue = new MyQueue();
            myQueue.Push(5);
            Console.WriteLine(myQueue.Pop());
        }
    }

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Next = null;
        }

        public int Value { get; set; }
        public Node Next { get; set; }
    }

    public class KrumQueue
    {
        public KrumQueue()
        {
            this.Length = 0;
        }

        public Node First { get; set; }
        public Node Last { get; set; }
        public int Length { get; set; }

        public void Enqueue(int value)
        {
            var newNode = new Node(value);

            if (this.Length == 0)
            {
                this.First = newNode;
                this.Last = newNode;
            }
            else
            {
                this.Last.Next = newNode;
                this.Last = newNode;
            }

            this.Length++;
        }


        public Node Dequeue()
        {
            if (this.First == null)
            {
                return null;
            }

            if (this.First == this.Last)
            {
                this.Last = null;
            }

            var firstNode = this.First;
            this.First = firstNode.Next;

            this.Length--;

            return firstNode;
        }


        public Node Peek()
        {
            return this.First;
        }
    }

    public class KrumStack
    {

        public KrumStack()
        {
            this.Top = null;
            this.Bottom = null;
            this.Length = 0;
        }
        public int Length { get; set; }
        public Node Top { get; set; }
        public Node Bottom { get; set; }

        public void Push(int value)
        {
            var newNode = new Node(value);

            if (this.Length == 0)
            {
                this.Top = newNode;
                this.Bottom = newNode;
            }
            else
            {
                var holdingPointer = this.Top;
                this.Top = newNode;
                this.Top.Next = holdingPointer;
            }

            this.Length++;
        }

        public Node Peek()
        {
            return this.Top;
        }

        public Node Pop()
        {
            if (this.Top == null)
            {
                return null;
            }

            if (this.Top == this.Bottom)
            {
                this.Bottom = null;
            }

            var holdingPointer = this.Top;
            this.Top = this.Top.Next;
            this.Length--;

            return holdingPointer;
        }

        public bool IsEmpty()
        {
            if (this.Bottom == null)
            {
                return true;
            }

            return false;
        }

    }


    /*
     
        232. Implement Queue using Stacks

        Implement a first in first out (FIFO) queue using only two stacks. The implemented queue should support all the functions of a normal queue (push, peek, pop, and empty).

        Implement the MyQueue class:

        void push(int x) Pushes element x to the back of the queue.
        int pop() Removes the element from the front of the queue and returns it.
        int peek() Returns the element at the front of the queue.
        boolean empty() Returns true if the queue is empty, false otherwise.
        Notes:

        You must use only standard operations of a stack, which means only push to top, peek/pop from top, size, and is empty operations are valid.
        Depending on your language, the stack may not be supported natively. You may simulate a stack using a list or deque (double-ended queue) as long as you use only a stack's standard operations.
        Follow-up: Can you implement the queue such that each operation is amortized O(1) time complexity? In other words, performing n operations will take overall O(n) time even if one of those operations may take longer.

 

        Example 1:

        Input
        ["MyQueue", "push", "push", "peek", "pop", "empty"]
        [[], [1], [2], [], [], []]
        Output
        [null, null, null, 1, 1, false]

        Explanation
        MyQueue myQueue = new MyQueue();
        myQueue.push(1); // queue is: [1]
        myQueue.push(2); // queue is: [1, 2] (leftmost is front of the queue)
        myQueue.peek(); // return 1
        myQueue.pop(); // return 1, queue is [2]
        myQueue.empty(); // return false
 

        Constraints:

        1 <= x <= 9
        At most 100 calls will be made to push, pop, peek, and empty.
        All the calls to pop and peek are valid.
     
     */

    public class MyQueue
    {
        private Stack<int> stack = new Stack<int>();

        /** Initialize your data structure here. */
        public MyQueue()
        {

        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            var newStack = new Stack<int>();
            while (stack.Any())
            {
                newStack.Push(stack.Pop());
            }
            newStack.Push(x);

            while (newStack.Any())
            {
                stack.Push(newStack.Pop());
            }
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            return stack.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            return stack.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return !stack.Any();
        }
    }

    /*
         * Your MyQueue object will be instantiated and called as such:
         * MyQueue obj = new MyQueue();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Peek();
         * bool param_4 = obj.Empty();
     */
}
