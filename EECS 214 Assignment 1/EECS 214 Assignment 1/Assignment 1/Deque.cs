//Assignment 1 for EECS 211
//Out: April 11th, 2014
//Due: April 18th, 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1
{
    
    /// <summary>
    /// A double-ended queue
    /// Implement this as a doubly-linked list
    /// </summary>
    public class Deque
    {
        Node Front = null;
        Node Rear = null;
        int counter = 0;
        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public void AddFront(object o)
        {
            Console.WriteLine("");
            Node temp = Front;
            Node n = new Node(o);
            Front = n;
            Front.Next = temp;
            counter++;
            if (Count == 1)
            {
                Rear = Front;
            }
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public object RemoveFront()
        {
            Console.WriteLine("");
            if (Front == null)
            {
                Console.WriteLine("Attempt to remove from an empty queue");
                //return null;
                throw new QueueEmptyException();
            }
            else
            {
                Front = Front.Next;
                Object val = Front.Value;
                counter--;
                return val;
            }
        }

        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public void AddEnd(object o)
        {
            Console.WriteLine("");
            Node n = new Node(o);
            //if empty, set rear and front to a new node with object o as val
            if (IsEmpty) //isEmpty
            {
                Front = n;
            }
            else
            {
                Rear.Next = n;
            }
            Rear = n;
            counter++;
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public object RemoveEnd()
        {
            Console.WriteLine("");
            if (IsEmpty)
            {
                Console.WriteLine("Attempt to remove from an empty queue");
                //return null;
                throw new QueueEmptyException();
            }
            else
            {
                if (Count == 1)
                {
                    Object val = Front.Value;
                    Front = null;
                    Rear = null;
                    return val;
                }
                else
                {
                    Node temp = Front;
                    while (temp.Next != Rear)
                    {
                        temp = temp.Next;
                    }
                    temp.Next = null;
                    Rear = temp;
                    Object val = Rear.Value;
                    counter--;
                    return val;
                }
            }
        }

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        public int Count
        {
            get
            {
                return counter;
            }
        }

        /// <summary>
        /// True if the queue is empty and dequeuing is forbidden.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return counter == 0;
            }
        }
        public void Print()
        {
            Node temp = Front;
            while (temp != null)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Next;
            }
        }
    }
}
