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

namespace Assignment_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///Don't worry about this being defined as a partial class, a partial class just allows you to split up code in 
    ///different files while telling the compiler to splice them together during compilation
    public partial class MainWindow : Window
    {
        int top = 100, left = 50;
        int index;
        bool Minimum = false;
        bool Maximum = false;
        bool Search = false;
        BST tree = new BST();


        public MainWindow()
        {

            InitializeComponent();
            drawStructure();

            //Registering callbacks for the 3 buttons
            SearchBtn.Click += SearchBtn_Click;
            MaximumBtn.Click += MaximumBtn_Click;
            MinimumBtn.Click += MinimumBtn_Click;

            //Insert your code here, read the comments in BST.cs for implementation details
            //Things that should work
            //a. When the program runs, draw the tree as an inorder traversal (i.e. sorted list) of boxes horizontally.
            //   That is, exactly similar to the queue visualization you made last time around.
            //b. If I search for a node that doesn't exist in the tree, a Message Box should pop-up saying
            //   that the node was not found
            //c. If I search for a node that does exist in the tree, change its color to highlight where it is
            //   in the sorted list (i.e. horizontal visualization of the inorder traversal of BST)
            //d. If I click the Minimum button, it should hightlight the minimum value and if I click the max.... you get the drift 
        }

        //Search for an element in the BST
        void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text == "")
            {
                MessageBoxResult message = MessageBox.Show("Enter a value first, please!");
            }
            else if (Convert.ToInt32(input.Text) > 9)
            {
                MessageBoxResult message = MessageBox.Show("Node not found!");
            }
            else
            {
                index = Convert.ToInt32(input.Text) - 1;
                Search = true;
                Minimum = false;
                Maximum = false;
                drawStructure();
            }
        }

        //Finds minimum value in BST
        void MinimumBtn_Click(object sender, RoutedEventArgs e)
        {
            Search = false;
            Maximum = false;
            Minimum = true;
            drawStructure();
        }

        //Finds max. value in BST
        void MaximumBtn_Click(object sender, RoutedEventArgs e)
        {
            Search = false;
            Minimum = false;
            Maximum = true;
            drawStructure();
        }

        //Draw the inorder traversal (i.e. sorted list) of BST you've defined
        private void drawStructure()
        {
            List<int> intList = new List<int>();
            tree.v_Traversal(tree.Current, intList);
            int[] intArray = intList.ToArray();

            canvas.Children.Clear(); //You need to call this function to redraw the canvas after each click
            for (int i = 0; i < intArray.Length; i++)
            {

                //canvas.Children.Clear(); //You need to call this function to redraw the canvas after each click

                Ellipse r = new Ellipse();
                r.Width = 40;
                r.Height = 40;

                SolidColorBrush rBrush = new SolidColorBrush(Color.FromArgb(90, 101, 135, 178));
                SolidColorBrush rStrBrush = new SolidColorBrush(Color.FromArgb(100, 46, 59, 74));
                SolidColorBrush lBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                r.Fill = rBrush; //The brush and it's color is defined earlier (Line 82). This is the color inside the rectangle
                if (Minimum && i == 0)
                {
                    r.Fill = new SolidColorBrush(Color.FromArgb(100, 50 ,0, 0));
                }
                else if (Maximum && i == (intArray.Length - 1))
                {
                    r.Fill = new SolidColorBrush(Color.FromArgb(100, 50, 0, 0));
                }
                else if (Search && i == index)
                {
                    r.Fill = new SolidColorBrush(Color.FromArgb(100, 50, 0, 0));
                }


                r.StrokeThickness = 2; //This defines the thickness of the outline of each rectangular block
                r.Stroke = rStrBrush; //Defines the color of the block

                int l = 0;
                if (i == 7) { l = -10; }
                else if (i == 1 || i == 8) { l = -5; }
                else if (i == 0 || i == 5) { l = 0; }
                else if (i == 3 || i == 6) { l = 5; }
                else if (i == 2 || i == 4) { l = 10; }
                Label value = new Label();//It's all about objects! A label is an object that can contain text
                value.Width = r.Width;//We have to define how wide the label can go, otherwise the text can overflow from the rectangle
                value.Height = r.Height;
                value.Content = intArray[i];//Read the i-th element in the stack
                value.FontSize = 12;
                value.Foreground = lBrush; //Again, consider that text is also painted on, the paint color is specified in line 84
                value.HorizontalContentAlignment = HorizontalAlignment.Center; //We are just centering the text horizontally and vertically
                value.VerticalContentAlignment = VerticalAlignment.Center;

                canvas.Children.Add(r); //Add the rectangle 
                Canvas.SetLeft(r, left + (i * r.Width)); //Set the left (i.e. x-coordinate of the rectangle)
                Canvas.SetTop(r, top + (10 * l)); //set the position of the rectangle in the canvas

                //Add the text. Note, if you've added the text before the rectangle, the text would have
                //been occluded by the rectangle. 
                //So the order of drawing things matter. The things you draw later, are the ones that are layered on top of the previous ones
                canvas.Children.Add(value);
                Canvas.SetTop(value, Canvas.GetTop(r));
                Canvas.SetLeft(value, left + (i * r.Width));
            }
        }
    }
}
