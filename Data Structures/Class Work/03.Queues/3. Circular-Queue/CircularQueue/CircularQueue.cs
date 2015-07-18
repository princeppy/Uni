using System;
using System.Linq;

public class CircularQueue<T>
{
    public int Count { get; private set; }

    public T[] Elements { get; set; }

    private int startIndex = 0;

    private int endIndex = 0;

    private const int InitialCapacity = 16;


    public int Capacity { get; private set; }

    public CircularQueue()
    {

        this.Capacity = InitialCapacity;
        this.Elements = new T[this.Capacity];
        this.Count = 0;
    }

    public CircularQueue(int capacity)
        : this()
    {
        this.Capacity = capacity;
    }

    public void Enqueue(T element)
    {

        if (this.Count >= this.Elements.Length)
        {
            this.Grow();
        }

        this.Elements[this.endIndex] = element;
        this.endIndex = (this.endIndex + 1) % (this.Elements.Length);
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }

        T result = this.Elements[this.startIndex];
        this.startIndex = (this.startIndex + 1)%this.Elements.Length;
        this.Count--;
        return result;
    }

    public T[] ToArray()
    {
        T[] newElements =new T[this.Count];
        newElements = GenerateArray(newElements);
        return newElements;
    }

    private void Grow()
    {
        T[] newElements = new T[this.Elements.Length * 2];
        newElements = GenerateArray(newElements);


        this.Elements = newElements;
        this.startIndex = 0;
        this.endIndex = this.Count;


    }

    private T[] GenerateArray(T[] newElements)
    {
        
        int sourceIndex = this.startIndex;
        int destinationIndex = 0;
        for (int i = 0; i < this.Count; i++)
        {
            newElements[destinationIndex] = this.Elements[sourceIndex];
            sourceIndex = (sourceIndex + 1)%(this.Elements.Length);
            destinationIndex++;
        }
        return newElements;
    }
}


class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
