//Assignment 1 for EECS 214
//Out: April 18th, 2014
//Due: April 25th, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EECS_214_Assignment_2;

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///Don't worry about this being defined as a partial class, a partial class just allows you to split up code in 
    ///different files while telling the compiler to splice them together during compilation
    public partial class MainWindow : Window
    {
        //The top, left and margin variables are used in the
        //drawStructure function. Their only purpose is to specify where to draw
        //the shapes
        int top = 200, left = 130, margin = 10;
        Deque d = new Deque();

        public MainWindow()
        {
            //************************************CODE RELATED TO VISUALIZATION************************************//
            //Here you'll see an example where we visualize a stack
            //Your as far as the visualization is concerned, is to splice in your Deque as a queue
            //Note: make the visualization for the queue a horizontal drawing (mentally, we picture stacks as vertical, and queues as
            //Horizontal. When you do that, also change the button from saying Push and Pop, to Enqueue and Dequeue.

            //Remove this sample code for the stack before submitting.
            //Inserting values for stack
            d.AddFront("Start");
            d.AddFront(400);
            d.AddFront(500);
            InitializeComponent();

            //This is where we register a "callback". Callbacks are basically functions that take executable
            //code as input. Well, if that sounds like hocus pocus, don't worry about it.
            //All you need to understand is that there are these things called eventHandlers i.e. functions
            //that are called when an event happens. Such as when you click your mouse, when you drag your mouse etc.
            //Here we are referring to the "click" event on the push and pop buttons
            //So where are the popBtn and PushBtn names defined?
            RemoveFrontBtn.Click += popBtn_Click; //Look in the MainWindow.xaml file, you'll see a attribute called x:name inside a Button tag
            AddFrontBtn.Click += pushBtn_Click;
            AddEndBtn.Click += AddEnd_Click;
            RemoveEndBtn.Click += RemoveEnd_Click;
            drawStructure();


            //************************************CODE RELATED TO Dynamic Array Based Queue************************************//
            //Declare a dynamic array based queue and do a few Enqueue and Dequeue operations 
            var myQueue = new DynArrayQueue();
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

            //************************************CODE RELATED TO TREE************************************//
            //Create a tree with at least 5 nodes. Ensure that the tree has at least 3 levels (say 0 1 and 2)
            //Print out a breadth first traversal of the tree
            //If you can hook into the visualizer, that'd be awesome and worth 2% extra credit
            var t = new Tree();
            t.Add(3);
            t.Print();
            t.Add(1);
            t.Print(); 
            t.Add(4);
            t.Print();
            t.Add(5);
            t.Print();
            t.Add(9);
            t.Print();
            t.Add(8);
            t.Print();
            t.Add(7);
            t.Print();
            t.Add(2);
            t.Print();
            t.Add(9);
            t.Print();
        }

        //Notice when we defined the callback, in lines 53 and 54, we didn't pass any parameters?
        //The system does it for you. It sends a couple of object when you click. An object called sender and event details in 
        //in an object called e
        void pushBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text != "")
            {
                d.AddFront(input.Text);
                drawStructure();
                input.Text = "";
            }
            else
            {
                MessageBoxResult message = MessageBox.Show("Type Value First");
            }
        }

        void popBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!d.IsEmpty)
            {
                d.RemoveFront();
                drawStructure();
            }
            else
            {
                MessageBoxResult message = MessageBox.Show("Empty Stack");
            }
        }
        void AddEnd_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text != "")
            {
                d.AddEnd(input.Text);
                drawStructure();
                input.Text = "";
            }
            else
            {
                MessageBoxResult message = MessageBox.Show("Type Value First");
            }
        }
        void RemoveEnd_Click(object sender, RoutedEventArgs e)
        {
            if (!d.IsEmpty)
            {
                d.RemoveEnd();
                drawStructure();
            }
            else
            {
                MessageBoxResult message = MessageBox.Show("Empty Stack");
            }
        }


        private void drawStructure()
        {
            canvas.Children.Clear(); //You need to call this function to redraw the canvas after each click

            SolidColorBrush rBrush = new SolidColorBrush(Color.FromArgb(90, 101, 135, 178));
            SolidColorBrush rStrBrush = new SolidColorBrush(Color.FromArgb(100, 46, 59, 74));
            SolidColorBrush lBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            //We are drawing a square block for each element in our Stack
            int i = 0;
            foreach (Object e in d)
            {
                i++;
                //Think about this drawing exercise as your having brushes dipped in different types of paint
                //And you use those brushes to paint a rectangle
                Rectangle r = new Rectangle();
                r.Width = 40;
                r.Height = 40;

                r.Fill = rBrush; //The brush and it's color is defined earlier (Line 82). This is the color inside the rectangle
                r.StrokeThickness = 2; //This defines the thickness of the outline of each rectangular block
                r.Stroke = rStrBrush; //Defines the color of the block

                Label value = new Label();//It's all about objects! A label is an object that can contain text
                value.Width = r.Width;//We have to define how wide the label can go, otherwise the text can overflow from the rectangle
                value.Height = r.Height;
                value.Content = e ;//Read the i-th element in the stack
                value.FontSize = 12;
                value.Foreground = lBrush; //Again, consider that text is also painted on, the paint color is specified in line 84
                value.HorizontalContentAlignment = HorizontalAlignment.Center; //We are just centering the text horizontally and vertically
                value.VerticalContentAlignment = VerticalAlignment.Center;

                canvas.Children.Add(r); //Add the rectangle 
                Canvas.SetLeft(r, left - i * r.Width + margin); //Set the left (i.e. x-coordinate of the rectangle)
                Canvas.SetTop(r, top); //set the position of the rectangle in the canvas

                //Add the text. Note, if you've added the text before the rectangle, the text would have
                //been occluded by the rectangle. 
                //So the order of drawing things matter. The things you draw later, are the ones that are layered on top of the previous ones
                canvas.Children.Add(value);
                Canvas.SetTop(value, Canvas.GetTop(r));
                Canvas.SetLeft(value, left);
            }

        }
    }


    //This is the ArrayStack implementation that we did for micro-quiz 1
    //I've only added a method called Read(), that returns the object at an 
    //index i in the array
    interface IStack<T>
    {
        void Push(T v);
        T Pop();
        bool isEmpty { get; }
        object Top { get; }
        object Read(int i);
    }

    class ArrayStack<T> : IStack<T>
    {
        private T[] values = new T[100];
        private int top = 0;

        //Explicit implementation of interface method
        void IStack<T>.Push(T v)
        {
            values[top++] = v;
        }

        T IStack<T>.Pop()
        {
            //Notice the difference between pre and post decrement operators
            //That is, how does --top differ from top--
            return values[--top];
        }

        bool IStack<T>.isEmpty
        {
            get { return (top == 0); }
        }

        object IStack<T>.Top
        {
            get { return top; }
        }

        object IStack<T>.Read(int i)
        {
            return values[i];
        }
    }
}
