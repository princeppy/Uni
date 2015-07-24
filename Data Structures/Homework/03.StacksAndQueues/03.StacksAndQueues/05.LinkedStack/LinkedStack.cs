using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.LinkedStack
{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public LinkedStack()
        {
            this.Count = 0;
            
        } 
        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new Node<T>(element);
            }
            else
            {
                this.firstNode = new Node<T>(element, this.firstNode);
            }
            this.Count++;

        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }
            var resultNode = firstNode;
            firstNode = firstNode.NextNode;
            this.Count--;

            return resultNode.Value;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            var nextNode = this.firstNode;
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = nextNode.Value;
                nextNode = nextNode.NextNode;
            }

            return result;
        }

        
        private class Node<T>
        {
            public Node<T> NextNode { get; private set; }

            public T Value { get; private set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }
    }
}
