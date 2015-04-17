//Assignment 4 for EECS 214
//Out: May 7th, 2014
//Due: May 16th, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_4
{

    public class BSTNode
    {
        public BSTNode parent
        {
            get;
            set;
        }
        public int key
        {
            get;
            set;
        }
        public BSTNode leftchild
        {
            get;
            set;
        }
        public BSTNode rightchild
        {
            get;
            set;
        }
        public BSTNode(int k)
        {
            key = k;
        }
        public BSTNode()
        {
            key = 0;
        }
    }

    public class BST
    {
        public BSTNode root;
        public void Insert(int value)
        {
            BSTNode temp = new BSTNode(value);
            if (root == null)
            {
                root = temp;
            }
            else
            {
                InsertAtNode(root, value);
            }
        }

        public BSTNode InsertAtNode(BSTNode n, int value)
        {
            BSTNode temp = new BSTNode(value);
            if (n == null)
            {
                n = temp;
                return n;
            }
            if (n.key == value)
            {
                return n;
            }

            if (value < n.key)
            {
                if (n.leftchild != null)
                {
                    return InsertAtNode(n.leftchild, value);
                }
                else
                {
                    n.leftchild = temp;
                    return n.leftchild;
                }
            }

            else if (value > n.key)
            {
                if (n.rightchild != null)
                {
                    return InsertAtNode(n.rightchild, value);
                }
                else
                {
                    n.rightchild = temp;
                    return n.rightchild;
                }
            }
            else
            {
                return null;
            }
        }
        public BSTNode Search(BSTNode node, int k)
        {
            if (node == null)
            {
                return null;
            }
            else if (k == node.key)
            {
                return node;
            }
            else if (k < node.key)
            {
                return Search(node.leftchild, k);
            }
            else
            {
                return Search(node.rightchild, k);
            }
        }
        public void Inorder(BSTNode x, List<int> l)
        {
            if (x.leftchild != null)
            {
                Inorder(x.leftchild, l);
            }
            l.Add(x.key);
            if (x.rightchild != null)
            {
                Inorder(x.rightchild, l);
            }

        }
        public BSTNode Minimum(BSTNode node)
        {
            while (node.leftchild != null)
            {
                node = node.leftchild;
            }
            return node;
        }
        public BSTNode Maximum(BSTNode node)
        {
            while (node.rightchild != null)
            {
                node = node.rightchild;
            }
            return node;
        }
        public BSTNode Successor(BSTNode node)
        {
            if (node.rightchild != null)
            {
                return Minimum(node.rightchild);
            }
            BSTNode temp = node.parent;
            while (temp != null && node == temp.parent)
            {
                temp = node;
                temp = node.parent;
            }
            return temp;
        }

        public void rotateRight(BSTNode b)
        {
            BSTNode a = (BSTNode)b.leftchild;
            b.leftchild = (BSTNode)a.rightchild;
            if (a.leftchild != null)
            {
                a.rightchild.parent = b;
            }
            a.parent = (BSTNode)b.parent;
            if (a.parent == null)
            {
                this.root = a;
            }
            else if (b == (BSTNode)a.parent.rightchild)
            {
                a.parent.rightchild = a;
            }
            else
            {
                a.parent.leftchild = a;
            }
            a.rightchild = b;
            b.parent = a;
        }
        public void rotateLeft(BSTNode a)
        {
            BSTNode b = (BSTNode)a.rightchild;
            a.rightchild = (BSTNode)b.leftchild;
            if (b.leftchild != null)
            {
                b.leftchild.parent = a;
            }
            b.parent = (BSTNode)a.parent;
            if (a.parent == null)
            {
                this.root = b;
            }
            else if (a == (BSTNode)a.parent.leftchild)
            {
                a.parent.leftchild = b;
            }
            else
            {
                a.parent.rightchild = b;
            }
            b.leftchild = b;
            a.parent = b;
        }
        //Put everything you wrote from assignment 3 here. But most importantly, have InOrder traversal.
        //Make sure you also have:
        //a. Class called BSTNode, make it public (and put it outside the BST class, so that the RBNode can derive from the BSTNode class) 
        //b. Write left-rotate and right-rotate functions
        //c. Write a function for inserting a node in the BST
    }
}
