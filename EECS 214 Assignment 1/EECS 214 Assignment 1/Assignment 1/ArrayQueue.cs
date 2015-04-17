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
    /// A queue internally implemented as an array
    /// </summary>
    public class ArrayQueue : Queue
    {
        object[] value = new object[10];
        int top = 0;
        int bottom = 0;
        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public void ResetArray()
        {
            for (int i = bottom; i < top; i++)
            {
                value[i-bottom] = value[i];
            }
            top = top - bottom;
            bottom = 0;
        }

        public override void Enqueue(object o)
        {
            Console.WriteLine("");
            ResetArray();
            if(IsFull)
            {
                Console.WriteLine("Attempt to add to a full queue");
                Console.WriteLine("");
                throw new QueueFullException();
            }            
            else
            {
                value[top] = o;
                top = top + 1;
            }                                                                                                                                            
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public override object Dequeue()
        {
            Console.WriteLine("");
            ResetArray();
            if (IsEmpty)
            {
                Console.WriteLine("Attempt to remove from an empty queue");
                //return null;
                throw new QueueEmptyException();
            }

            else
            {
                return value[bottom++];
            }
        }

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        public override int Count
        {
            get 
            {
                ResetArray();
                return top - bottom;
            }
        }

        /// <summary>
        /// True if the queue is full and enqueuing of new elements is forbidden.
        /// </summary>
        public override bool IsFull
        {
            get 
            {
                ResetArray();
                if (Count == 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Print()
        {
            ResetArray();
            for(int i = 0; i < top; i++)
            {
                Console.WriteLine(value[i]);
            }
        }
    }
}
