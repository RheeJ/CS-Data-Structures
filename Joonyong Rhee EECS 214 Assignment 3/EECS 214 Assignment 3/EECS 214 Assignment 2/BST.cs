//Assignment 1 for EECS 214
//Out: April 18th, 2014
//Due: April 25th, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Assignment_3
{
    public class BSTNode
    {
        public BSTNode Parent { get; set; }
        public BSTNode LeftChild { get; set; }
        public BSTNode RightChild { get; set; }
        public int Value { get; set; }
    }
    public class BST
    {
        public BSTNode Current;
        public BST()
        {
            BSTNode b1 = new BSTNode();
            BSTNode b2 = new BSTNode();
            BSTNode b3 = new BSTNode();
            BSTNode b4 = new BSTNode();
            BSTNode b5 = new BSTNode();
            BSTNode b6 = new BSTNode();
            BSTNode b7 = new BSTNode();
            BSTNode b8 = new BSTNode();
            BSTNode b9 = new BSTNode();
            b1.Value = 1;
            b2.Value = 2;
            b3.Value = 3;
            b4.Value = 4;
            b5.Value = 5;
            b6.Value = 6;
            b7.Value = 7;
            b8.Value = 8;
            b9.Value = 9;
            Current = b8;
            b2.Parent = Current;
            b9.Parent = Current;
            Current.LeftChild = b2;
            Current.RightChild = b9;
            b2.LeftChild = b1;
            b2.RightChild = b6;
            b1.Parent = b2;
            b6.Parent = b2;
            b6.LeftChild = b4;
            b6.RightChild = b7;
            b4.Parent = b6;
            b7.Parent = b6;
            b4.LeftChild = b3;
            b4.RightChild = b5;
            b3.Parent = b4;
            b5.Parent = b4;
        }
        public BSTNode Maximum(BSTNode b)
        {
            while (b.RightChild != null)
            {
                b = b.RightChild;
            }
            return b;
        }

        public BSTNode Minimum(BSTNode b)
        {
            while (b.LeftChild != null)
            {
                b = b.LeftChild;
            }
            return b;
        }

        public BSTNode Successor(BSTNode b)
        {
            if (b.RightChild != null)
            {
                return Minimum(b.RightChild);
            }

            BSTNode p = b.Parent;
            while (p != null && b == p.RightChild)
            {
                b = p;
                p = b.Parent;
            }
            return p;
        }
        public void InOrder(BSTNode b)
        {
            InOrder(b.LeftChild);
            Console.WriteLine(b.Value);
            InOrder(b.RightChild);
        }
        public void v_Traversal (BSTNode b, List<int> l)
        {
            if (b.LeftChild != null) 
            {
                v_Traversal(b.LeftChild, l);
            }
            l.Add(b.Value);
            if (b.RightChild != null)
            {
                v_Traversal(b.RightChild, l);
            }
        }
    }
}

      