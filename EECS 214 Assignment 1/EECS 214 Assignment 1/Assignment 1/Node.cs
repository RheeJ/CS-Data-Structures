using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1
{
    public class Node
    {
        object val;
        Node next;
        Node prev;

        public Node(object o)
        {
            val = o;
        }
        public Object Value
        {
            get { return val; }
            set { val = value; }
        }
        public Node Next
        {
            get { return next; }
            set { next = value; }
        }
        public Node Prev
        {
            get { return prev; }
            set { prev = value; }
        }
    }
}
