using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03.ArrayBasedStack
{
    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }
        private const int InitialCapacity = 16;
        private int capacity;
        public ArrayStack(int capacity = InitialCapacity)
        {
            this.Count = 0;
            this.elements = new T[capacity];
            this.capacity = capacity;
        }

        public void Push(T element)
        {
            this.Count++;
            if (this.Count >= this.capacity)
            {
                Grow();
            }
            this.elements[this.Count - 1] = element;    
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("The stack is empty");
            }
            this.Count--;
            T[] newArray = new T[this.capacity];
            T elementToReturn = this.elements[this.Count];

            GenerateNewArray(newArray);

            this.elements = newArray;
            return elementToReturn;
        }
        
        public T[] ToArray()
        {
            if (this.Count == 0)
            {
                return new T[0];
            }

            T[] array = new T[this.Count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = this.elements[this.Count - i - 1];
            }

            return array;
        }

        private void Grow()
        {
            this.capacity *= 2;
            T[] newElements = new T[this.capacity];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }
            this.elements = newElements;
        }

        private void GenerateNewArray(T[] newArray)
        {
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[i];
            }
        }
    }

}
