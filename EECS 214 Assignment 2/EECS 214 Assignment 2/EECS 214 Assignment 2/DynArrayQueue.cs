//Assignment 1 for EECS 214
//Out: April 18th, 2014
//Due: April 25th, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Assignment_2
{
    //Again, note how the ArrayQueue implements the Abstract class Queue
    //And how the methods/functions defined in the Queue abstract class
    //Are overriden
    /// <summary>
    /// A queue internally implemented as an array
    /// </summary>
    public class DynArrayQueue : Queue, IEnumerable
    {
        int counter = 0;
        Object[] Array = new Object[0];
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (int n in Array)
            {
                yield return Array[n];
            }
        }

        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public override void Enqueue(object o)
        {
            Console.WriteLine("");
            Object[] ExpandedArray = new Object[counter + 1];
            for (int n = 0; n < Array.Length; n++)
            {
                ExpandedArray[n] = Array[n];
            }
            ExpandedArray[ExpandedArray.Length - 1] = o;
            Array = ExpandedArray;
            counter++;
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public override object Dequeue()
        {
            Console.WriteLine("");
            if (IsEmpty)
            {
                Console.WriteLine("Attempt to remove from an empty queue");
                return null;
            }
            else
            {
                Object result = Array[0];
                Object[] ReducedArray = new Object[counter - 1];
                for (int n = 1; n < Array.Length; n++)
                {
                    ReducedArray[n - 1] = Array[n];
                }
                counter--;
                Array = ReducedArray;
                return result;
            }
        }

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        public override int Count
        {
            get
            {
                return counter;
            }
        }

        /// <summary>
        /// True if the queue is full and enqueuing of new elements is forbidden.
        /// </summary>
        public override bool IsFull
        {
            get
            {
                return (counter == Array.Length);
            }
        }

        public void Print()
        {
            for (int n = 0; n < Array.Length; n++)
            {
                Console.WriteLine(Array[n]);
            }
        }
    }
}
