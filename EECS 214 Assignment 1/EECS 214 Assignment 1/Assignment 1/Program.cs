using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("//////////// THIS IS ARRAYQUEUE ////////////////");
            var myQueue = new ArrayQueue();
            myQueue.Enqueue(1);
            myQueue.Print();
            myQueue.Enqueue(3);
            myQueue.Print();
            myQueue.Enqueue(5);
            myQueue.Print();
            myQueue.Enqueue(7);
            myQueue.Print();
            myQueue.Enqueue(9);
            myQueue.Print();
            myQueue.Enqueue(11);
            myQueue.Print();
            myQueue.Enqueue(9);
            myQueue.Print();
            myQueue.Enqueue(7);
            myQueue.Print();
            myQueue.Enqueue(5);
            myQueue.Print();
            myQueue.Enqueue(3);
            myQueue.Print();
            myQueue.Enqueue(1);
            myQueue.Print();

            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
        
            myQueue.Enqueue(2);
            myQueue.Print();
            myQueue.Enqueue(4);
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Enqueue(6);
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Enqueue(8);
            myQueue.Print();

            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();
            myQueue.Dequeue();
            myQueue.Print();

            Console.WriteLine("//////////////// END ARRAYQUEUE ///////////////////////");
            //Create Queues of both Linked List Queue and Array Queue
            //Perform at least 3 Enqueue and 2 Dequeue Operations
            //Then declare a deque("DECK") and do a couple of AddFront operations
            //Followed by a RemoveFront operation, then do the same with AddEnd and RemoveEnd

            Console.WriteLine("/////////////// THIS IS FOR LINKEDLISTQUEUE /////////////////");
            var myLink = new LinkedListQueue();
            myLink.Enqueue(5);
            myLink.Print();
            myLink.Enqueue(7);
            myLink.Print();
            myLink.Enqueue(9);
            myLink.Print();
            myLink.Dequeue();
            myLink.Print();
            myLink.Dequeue();
            myLink.Print();
            myLink.Dequeue();
            myLink.Print();
            myLink.Dequeue();
            myLink.Print();
            Console.WriteLine("////////////////// END LINKEDLISTQUEUE ////////////////////");
            
            Console.WriteLine("////////////////// THIS IS FOR DEQUE //////////////////////");
            var myDeque = new Deque();
            myDeque.AddFront(5);
            myDeque.Print();
            myDeque.AddFront(7);
            myDeque.Print();
            myDeque.AddFront(9);
            myDeque.Print();
            myDeque.AddFront(11);
            myDeque.Print();
            myDeque.RemoveFront();
            myDeque.Print();
            myDeque.AddEnd(1);
            myDeque.Print();
            myDeque.AddEnd(40);
            myDeque.Print();
            myDeque.AddEnd(50);
            myDeque.Print();
            myDeque.RemoveEnd();
            myDeque.Print();
            myDeque.AddEnd(15);
            myDeque.Print();
            myDeque.RemoveFront();
            myDeque.Print();
            myDeque.RemoveEnd();
            myDeque.Print();
            myDeque.RemoveFront();
            myDeque.Print();
            myDeque.RemoveEnd();
            myDeque.Print();
            myDeque.RemoveFront();
            myDeque.Print();
            myDeque.RemoveEnd();
            myDeque.Print();
            myDeque.RemoveFront();
            myDeque.Print();
            Console.WriteLine("////////////////// END DEQUE /////////////////////");
        }
    }
}
