//Assignment 4 for EECS 214
// Nevil George, nsg622
//Out: May 7th, 2014
//Due: May 16th, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_4
{

    public class RBNode : BSTNode
    {
        public string color
        {
            get;
            set;
        }

        public RBNode(string c)
        {
            color = c;
        }

        public RBNode(int k)
        {
            key = k;
        }

        public RBNode(int k, string c)
        {
            color = c;
            key = k;
        }
    }


    public class RBTree : BST
    {
        public RBNode root;
        RBNode Nil = new RBNode("black");

        public void BuildTree(List<int> key)
        {
            int[] keyArray = key.ToArray();
            for (int i = 0; i < keyArray.Length; i++)
            {
                Insert(keyArray[i]);
            }
        }
        public void Insert(int k)
        {
            RBNode n = new RBNode(k);
            RBNode a = root;
            RBNode b = null;
            while (a != null)
            {
                b = a;
                if (n.key < a.key)
                {
                    a = (RBNode)a.leftchild;
                }
                else
                {
                    a = (RBNode)a.rightchild;
                }
            }
            n.parent = b;
            if (b == null)
            {
                root = n;
            }
            else if (n.key < b.key)
            {
                b.leftchild = n;
            }
            else if (n.key > b.key)
            {
                b.rightchild = n;
            }
            n.leftchild = null;
            n.rightchild = null;
            n.color = "Red";
            fixUp(n);
        }
        public void fixUp(RBNode n)
        {
            RBNode parent = (RBNode)n.parent;
            while (parent != null && parent.color == "Red")
            {
                parent = (RBNode)n.parent;
                RBNode grandparent = (RBNode)n.parent.parent;
                RBNode leftuncle = (RBNode)grandparent.leftchild;
                RBNode rightuncle = (RBNode)grandparent.rightchild;
                if (parent == leftuncle)
                {
                    RBNode b = rightuncle;
                    if (b == null)
                    {
                        return;
                    }
                    else if (b.color == "Red")
                    {
                        parent.color = "Black";
                        b.color = "Black";
                        grandparent.color = "Red";
                        n = grandparent;
                    }
                    else if (b.color == "Black")
                    {
                        if (n == parent.rightchild)
                        {
                            n = parent;
                            rotateLeft(n);
                        }
                        parent.color = "Black";
                        grandparent.color = "Red";
                        rotateRight(grandparent);
                    }
                }
                else
                {
                    RBNode b = leftuncle;
                    if (b == null)
                    {
                        return;
                    }
                    else if (b.color == "Red")
                    {
                        parent.color = "Black";
                        b.color = "Black";
                        grandparent.color = "Red";
                        n = grandparent;
                    }
                    else if (b.color == "Black")
                    {
                        if (n == n.parent.leftchild)
                        {
                            n = parent;
                            rotateRight(n);
                        }
                        parent.color = "Black";
                        grandparent.color = "Red";
                        rotateLeft(grandparent);
                    }
                }
                parent = (RBNode)n.parent;
            }
            this.root.color = "Black";
        }
        public int BlackHeight(RBNode n)
        {
            int sum = 0;
            if (n == this.root)
                return 0;
            else
            {
                while (n != this.root)
                {
                    if (n.color == "Black")
                    {
                        sum++;
                    }
                    n = (RBNode)n.parent;
                }
                return sum;
            }
        }
        public void Inorder(RBNode x, List<int> l, List<RBNode> n)
        {
            if (x.leftchild != null)
            {
                Inorder((RBNode)x.leftchild, l, n);
            }
            l.Add(x.key);
            n.Add(x);
            if (x.rightchild != null)
            {
                Inorder((RBNode)x.rightchild, l, n);
            }
        }
        public void rotateRight(RBNode b)
        {
            RBNode a = (RBNode)b.leftchild;
            b.leftchild = (RBNode)a.rightchild;
            if (a.leftchild != null)
            {
                a.rightchild.parent = b;
            }
            a.parent = (RBNode)b.parent;
            if (a.parent == null)
            {
                this.root = a;
            }
            else if (b == (RBNode)a.parent.rightchild)
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
        public void rotateLeft(RBNode a)
        {
            RBNode b = (RBNode)a.rightchild;
            a.rightchild = (RBNode)b.leftchild;
            if (b.leftchild != null)
            {
                b.leftchild.parent = a;
            }
            b.parent = (RBNode)a.parent;
            if (a.parent == null)
            {
                this.root = b;
            }
            else if (a == (RBNode)a.parent.leftchild)
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
        //Ensure the following
        //a. Class called RBNode that derives from the BSTNode 
        //b. Have a Fix-up function that fixes up the tree after each insertion
        //c. Ensure that you know what you are doing with the Nil nodes.
        //d. Have a function that calculates and returns the black height in a MessageBox
        //The syntax for showing a messagebox is: MessageBoxResult m = MessageBox.Show("hello folks");
        //Instead of the messagebox, if you want to show the black height as a label inside the visualizer, feel free to add it to the
        //xaml file
    }
}
