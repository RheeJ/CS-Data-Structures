//Assignment 4 for EECS 214
//Out: May 7th, 2014
//Due: May 16th, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_5
{
    class SkipList
    {
        //The Node class should have an integer value and a Node[]
        //of size specified as an input (i.e. a constructor that takes a value and a size/number of levels
        //as an input. Call this array of SkipNode(i.e. SkipNode[]) Next. This array would contain the "next" nodes of a particular node
        //Refer to slide number 17 of Skip Lists on Piazza for what we mean by size
        public class SkipNode
        {
            public int v;
            public int s;
            public SkipNode[] Next;

            public SkipNode(int value, int size)
            {
                v = value;
                s = size;
                Next = new SkipNode[size];
            }
        }

        public SkipNode Head = new SkipNode(0, 20);
        public int Levels = 1;
        public Random randNum = new Random();
        //Fields of the SkipList class. Should have the starting node, since it is a linked list
        //call it head, should have levels and a random number generator (C# has a class called Random!)
        //private Node head = new Node(0, 20); // Set the max. size to 20 and the first value to be 0
        //private int levels = 1;
        //private Random randNum = new Random();

        /// <summary>
        /// Inserts a value into the skip list.
        /// </summary>
        public int setNodeLevel(double probability, int maxLevel)
            {
                int Levels = 1;
                int R = ChooseRandLevel();
                while (R < probability)
                {
                    Levels++;
                }
                if (Levels > maxLevel)
                {
                    return maxLevel;
                }
                else
                {
                    return Levels;
                }
            }

        public int ChooseRandLevel()
        {
            int Rand = randNum.Next(1, 13);
            return Rand;
        }

        public void Insert(int value)
        {
            SkipNode NodeIn = new SkipNode(value, Levels + 1);
            SkipNode Current = Head;
            Levels = setNodeLevel(.125, 3);
            for (int i = Levels - 1; i >= 0; i--)
            {
                for (; Current.Next[i] != null; Current = Current.Next[i])
                {
                    if (Current.Next[i].v > value) break;
                }
                if (i <= Levels)
                {
                    NodeIn.Next[i] = Current.Next[i];
                    Current.Next[i] = NodeIn;
                }
            }
            // Determine the level of a new node. Generate a random number R by calling ChooseRandLevel() function
            // Use the setLevel algorithm we discuss in Slide 19 of Skip Lists
            // Insert this node into the skip list(remember skips lists are sorted)
            // And since this is a linked list, remember that you need to start at the head node
        }


        /// <summary>
        /// Checks if a value already exists in the  list
        /// </summary>
        public bool Contains(int value)
        {
            SkipNode Current = Head;
            for (int i = Levels - 1; i >= 0; i++)
            {
                for (; Current.Next[i] != null; Current = Current.Next[i])
                {
                    if (Current.Next[i].v > value) break;
                    if (Current.Next[i].v == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Removes a node with an input value from the skip list. 
        /// </summary>
        public bool Remove(int value)
        {
            SkipNode Current = Head;
            bool Exists = false;
            for (int i = Levels - 1; i >= 0; i--)
            {
                for (; Current.Next[i] != null; Current = Current.Next[i])
                {
                    if (Current.Next[i].v == value)
                    {
                        Exists = true;
                        Current.Next[i] = Current.Next[i].Next[i];
                        break;
                    }
                    if (Current.Next[i].v > value) break;
                }
            }
            return Exists;
        }
        /// <summary>
        /// Enabling an iterator so that we can iterate using a foreach loop
        /// </summary>
        /// 
        public IEnumerable<int> Enumerate()
        {
            SkipNode Current = Head.Next[0];
            while (Current != null)
            {
                yield return Current.v;
                Current = Current.Next[0];
            }
        }

        //ALSO WRITE A FUNCTION OR PROPERTY THAT RETURNS THE NEXT NODE OF AN INPUT NODE
        //THAT'S THE VALUE THAT SHOWS UP IN A MESSAGEBOX ON SEARCHING FOR A VALUE
    }
}
