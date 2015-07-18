using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private ListNode<T> head;
    private ListNode<T> tail;
    public int Count { get; private set; }
    

    public DoublyLinkedList()
    {
        this.head = null;
        this.tail = null;
        this.Count = 0;
    } 

    public void AddFirst(T element)
    {
        ListNode<T> newHead = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.tail = newHead;
            this.head = newHead;
        }

        else
        {
            newHead.NextNode = this.head;
            this.head.PrevNode = newHead;
            this.head = newHead;

        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        ListNode<T> newTail = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.head = newTail;
            this.tail = newTail;
        }
        else
        {
            newTail.PrevNode = this.tail;
            this.tail.NextNode = newTail;
            this.tail = newTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty!");
        }
        T value = this.head.Value;
        if (this.Count == 1)
        {

            this.head = null;
            this.tail = null;
        }
        else
        {
            this.head = this.head.NextNode;
            this.head.PrevNode = null;

        }
        this.Count--;
        return value;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty!");
        }
        T value = this.tail.Value;
        if (this.Count == 1)
        {

            this.head = null;
            this.tail = null;
        }
        else
        {
            this.tail = this.tail.PrevNode;
            this.tail.NextNode = null;

        }
        this.Count--;
        return value;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        if (this.Count == 0)
        {
            return new T[0];
        }
        var arr = new T[this.Count];
        var currHead = this.head;
        for (int i = 0; i < this.Count; i++)
        {
            var value = currHead.Value;
            arr[i] = value;
            currHead = currHead.NextNode;
        }
        return arr;

    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
