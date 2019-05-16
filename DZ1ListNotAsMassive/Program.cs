using System;
using System.Collections;
using System.Collections.Generic;

namespace DZ1ListNotAsMassive
{
    class Program
    {
        static void Main(string[] args)
        {
            ListCollection<int> list = new ListCollection<int>();
            list.Add(1);
            list.Add(3);
            list.Add(1);
            list.Add(10);
            foreach (var l in list)
            {
                Console.WriteLine(l.ToString());
            }
        }
    }

    public class ListCollection<T> : IEnumerable<T>
    {
        ListNode<T> head;
        ListNode<T> tail;
        int count;
        public int Count { get { return count; } }

        public void Add(T data)
        {
            ListNode<T> node = new ListNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            ListNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }

    class ListNode<T>
    {
        public ListNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public ListNode<T> Previous { get; set; }
        public ListNode<T> Next { get; set; }
    }
}
