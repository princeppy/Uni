﻿using System;
using System.Collections;
using System.Collections.Generic;

public class Tree<T>
{
    
    
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();
        foreach (var child in children)
        {
            this.Children.Add(child);
        }
    }

    public ICollection<Tree<T>> Children { get; set; }
    public T Value { get; set; }

    public void Print(int indent = 0)
    {
        Console.Write(new string(' ', indent*2));
        Console.WriteLine(this.Value);
        foreach (var child in this.Children)
        {
            child.Print(indent+1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (var child in this.Children)
        {
            child.Each(action);        
        }
    }
}
