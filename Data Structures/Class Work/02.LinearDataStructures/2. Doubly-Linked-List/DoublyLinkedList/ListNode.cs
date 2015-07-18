using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ListNode<T>
    {
        public T Value { get; set; }
        public ListNode<T> NextNode { get; set; }
        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        } 
        
    }

