//Assignment 1 for EECS 214
//Out: April 18th, 2014
//Due: April 25th, 2014
//Implemented as a binary search tree.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_2
{

    public class TreeNode
    {
        TreeNode Root;
        TreeNode[] Children = new TreeNode[2];
        int count = 0;
        Object val;

        public TreeNode(object o)
        {
            val = o;
        }

        public TreeNode LeftChildren
        {
            get { return Children[0]; }
            set { Children[0] = value; }
        }

        public TreeNode RightChildren
        {
            get { return Children[1]; }
            set { Children[1] = value; }
        }

        public Object Value
        {
            get { return val; }
            set { val = value; }
        }
    }
        /// <summary>
        /// Write the necessary classes for a tree using arrays
        /// and write a breadth first walk of that tree.
        /// </summary>
        public class Tree
        {
            Object test = 0;
            TreeNode Current;
            //This time, less sample code for you here. Fill in members and functions based on the class slides

            public TreeNode Search(TreeNode Node, Object val)
            {
                if (Node.Value == test)
                {
                    return null;
                }
                else if (Node.Value == val)
                {
                    return Node;
                }
                else
                {
                    if (Node.LeftChildren != null)
                    {
                        return Search(Node.LeftChildren, val);
                    }
                    if (Node.RightChildren != null)
                    {
                        return Search(Node.RightChildren, val);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public TreeNode BFS(Object val)
            {
                if (Current == null)
                {
                    return null;
                }
                else
                {
                    return Search(Current, val);
                }
            }

            public TreeNode Insert(TreeNode Node, Object val)
            {
                int alternating = 0;
                TreeNode temp = new TreeNode(val);
                if (Node == null)
                {
                    Node = temp;
                    return Node;
                }
                if (Node.Value == val)
                {
                    return Node;
                }

                if (alternating == 0)
                {
                    if (Node.LeftChildren != null)
                    {
                        alternating = 1;
                        return Insert(Node.LeftChildren, val);
                    }
                    else
                    {
                        Node.LeftChildren = temp;
                        alternating = 1;
                        return Node.LeftChildren;
                    }
                }

                else if (alternating == 1)
                {
                    if (Node.RightChildren != null)
                    {
                        alternating = 0;
                        return Insert(Node.RightChildren, val);
                    }
                    else
                    {
                        alternating = 0;
                        Node.RightChildren = temp;
                        return Node.RightChildren;
                    }
                }
                else
                {
                    return null;
                }
            }

            public void Add(Object val)
            {
                TreeNode temp = new TreeNode(val);
                if (Current == null)
                {
                    Current = temp;
                }
                else
                {
                    Insert(Current, val);
                }
            }

            public void Print()
            {
                DynArrayQueue Queue = new DynArrayQueue();
                Queue.Enqueue(Current);
                while (Queue.Count != 0)
                {
                    TreeNode CurrentNode = (TreeNode)Queue.Dequeue();
                    Console.WriteLine(CurrentNode.Value);
                    Queue.Enqueue(CurrentNode.LeftChildren);
                    Queue.Enqueue(CurrentNode.RightChildren);
                }
            }
        }
    }

