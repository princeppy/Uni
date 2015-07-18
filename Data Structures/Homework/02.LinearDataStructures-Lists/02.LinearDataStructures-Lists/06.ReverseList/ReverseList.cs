namespace _06.ReverseList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class ReverseList<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private int capacity;
        
        public ReverseList(int capacity = InitialCapacity)
        {
            this.capacity = capacity;
            this.Count = 0;
            this.Collection = new T[capacity];
        }

        public int Count { get; private set; }

        public T[] Collection { get; private set; }

        public T this[int index]
        {
            get
            {
                return this.Collection[this.Count - index - 1];
            }

            set
            {
                this.Collection[this.Count - index - 1] = value;
            }
        }

        public void Add(T item)
        {
            this.Count++;
            if (this.Count >= this.capacity)
            {
                this.Grow();
            }

            this.GenerateListAfterAddingElement(item);
        }

        public void Remove(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException("The index is outside of the boundaries of the collection!");
            }

            this.GenerateListAfterRemovalOfElement(index);
            this.Count--;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.Collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void GenerateListAfterRemovalOfElement(int index)
        {
            var tempCollection = new T[this.Count - 1];
            for (int i = 0; i < this.Count; i++)
            {
                if (i == this.Count - index - 1)
                {
                    continue;
                }

                if (i < this.Count - index - 1)
                {
                    tempCollection[i] = this.Collection[i];
                }
                else if (i > this.Count - index - 1)
                {
                    tempCollection[i - 1] = this.Collection[i];
                }
            }

            this.Collection = tempCollection;
        }

        private void GenerateListAfterAddingElement(T item)
        {
            T[] temporaryCollection = new T[this.capacity];

            for (int i = 0; i < this.Count - 1; i++)
            {
                temporaryCollection[i] = this.Collection[i];
            }
            
            temporaryCollection[this.Count - 1] = item;

            this.Collection = temporaryCollection;
        }
        
        private void Grow()
        {
            this.capacity *= 2;
            T[] newCollection = new T[this.capacity];

            for (int i = 0; i < this.Collection.Length; i++)
            {
                newCollection[i] = this.Collection[i];
            }

            this.Collection = newCollection;
        }
    }
}
