//Assignment 1 for EECS 211
//Out: April 11th, 2014
//Due: April 18th, 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1
{
    //Again, note how the ArrayQueue implements the Abstract class Queue
    //And how the methods/functions defined in the Queue abstract class
    //Are overriden
    /// <summary>
    /// A queue internally implemented as a linked list of objects
    /// </summary>
    public class LinkedListQueue : Queue
    {
        private Node Head;
        private Node Current;
        int hcounter;
        int tcounter;
        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public override void Enqueue(object o)
        {
            Console.WriteLine("");
            Node n = new Node(o);
            if(Head == null)
            {
                Head = n;
                Current = Head;
            }
            else 
            {
                Current.Next = n;
                Current = Current.Next;
            }
            hcounter = hcounter + 1;
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public override object Dequeue()
        {
            Console.WriteLine("");
            if (Head == null)
            {
                Console.WriteLine("Attempt to remove from an empty queue");
                //return null;
                throw new QueueEmptyException();
            }
            else
            {
                Object val = Head.Value;
                Head = Head.Next;
                tcounter = tcounter + 1;
                return val;

            }
        }

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        public override int Count
        {
            get
            {
                return hcounter - tcounter;
            }
        }

        /// <summary>
        /// True if the queue is full and enqueuing of new elements is forbidden.
        /// Note: LinkedListQueues can be grown to arbitrary length, and so can
        /// never fill.
        /// </summary>
        public override bool IsFull
        {
            get
            {
                return false;
            }
        }
        public void Print()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Next;
            }
        }
    }
}
