//Assignment 4 for EECS 214
//Out: May 7th, 2014
//Due: May 16th, 2014

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

namespace Assignment_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///Don't worry about this being defined as a partial class, a partial class just allows you to split up code in 
    ///different files while telling the compiler to splice them together during compilation
    public partial class MainWindow : Window
    {
        int top = 100, left = 30;
        RBNode foundNode;
        bool search = false;

        List<int> keyList = new List<int>() {
            10, 2, 15, 0, 7, 11, 17, 91
        };

        RBTree tree = new RBTree();


        public MainWindow()
        {            
            InitializeComponent();
            tree.BuildTree(keyList);

            drawStructure();
            searchBtn.Click += searchBtn_Click;
            insertBtn.Click += insertBtn_Click;
            bhBtn.Click += bhBtn_Click;
        }
        void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text == "")
            {
                MessageBoxResult message1 = MessageBox.Show("Enter a Value!");
            }
            else
            {
                int addValue = Convert.ToInt32(input.Text);
                tree.Insert(addValue);
                keyList.Add(addValue);
                drawStructure();
            }
        }
        void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text == "")
            {
                MessageBoxResult message1 = MessageBox.Show("Enter a Value!");
            }
            else
            {
                int searchItem = Convert.ToInt32(input.Text);
                foundNode = (RBNode)tree.Search(tree.root, searchItem);
                if (foundNode == null)
                {
                    MessageBoxResult message1 = MessageBox.Show("Value Doesn't Exist!");
                }
                else
                {
                    search = true;
                }
                drawStructure();
            }
        }
        void bhBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text == "")
            {
                MessageBoxResult message1 = MessageBox.Show("Enter a Height");
            }
            else
            {
                int value = Convert.ToInt32(input.Text);
                RBNode bhNode = (RBNode)tree.Search((RBNode)tree.root, value);
                if (bhNode == null) {
                    MessageBoxResult message1 = MessageBox.Show("Node Doesn't Exist!");
                } 
                else 
                {
                    int bh = tree.BlackHeight(bhNode);
                    MessageBoxResult message1 = MessageBox.Show("Black Height = " + bh.ToString());
                }
                drawStructure();
            }
        }
        private void drawStructure()
        {
            List<int> intList = new List<int>();
            List<RBNode> nodeList = new List<RBNode>();
            tree.Inorder(tree.root, intList, nodeList);
            int[] intArray = intList.ToArray();
            RBNode[] nodeArray = nodeList.ToArray();

            canvas.Children.Clear();

            for (int i = 0; i < intArray.Length; i++)
            {
                Ellipse e = new Ellipse();
                e.Width = 40;
                e.Height = 40;

                SolidColorBrush eStrBrush = new SolidColorBrush(Color.FromArgb(100, 46, 59, 74));
                SolidColorBrush lBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                if (nodeArray[i].color == "Red")
                    e.Fill = new SolidColorBrush(Color.FromArgb(200, 255, 0, 0));
                else if (nodeArray[i].color == "Black")
                    e.Fill = new SolidColorBrush(Color.FromArgb(200, 0, 0, 0));

                if (search && foundNode != null && nodeArray[i].key == foundNode.key)
                    e.Fill = new SolidColorBrush(Color.FromArgb(200, 0, 255, 0));

                e.StrokeThickness = 2;
                e.Stroke = eStrBrush; 

                Label value = new Label();
                value.Width = e.Width;
                value.Height = e.Height;
                value.Content = intArray[i];
                value.FontSize = 12;
                value.Foreground = lBrush;
                value.HorizontalContentAlignment = HorizontalAlignment.Center;
                value.VerticalContentAlignment = VerticalAlignment.Center;

                canvas.Children.Add(e);
                Canvas.SetLeft(e, left + (i * e.Width));
                Canvas.SetTop(e, top);
                canvas.Children.Add(value);
                Canvas.SetTop(value, Canvas.GetTop(e));
                Canvas.SetLeft(value, left + (i * e.Width));

            }
            SolidColorBrush redBrush = new SolidColorBrush(Color.FromArgb(90, 201, 56, 76));
            SolidColorBrush blackBrush = new SolidColorBrush(Color.FromArgb(90, 11, 32, 56));
        }
        //Insert your code here, read the comments in BST.cs for implementation details
        //Things that should work
        //a. When the program runs, draw the tree as an inorder traversal (i.e. sorted list) of boxes horizontally. 
        //   Same as assignment 3
        //b. If I search for a node that doesn't exist in the tree, a Message Box should pop-up saying
        //   that the node was not found
        //c. If I search for a node that DOES exist in the tree, change its stroke color to highlight where it is
        //   in the sorted list (i.e. horizontal visualization of the inorder traversal of the RBT).
        //   N.B. don't change the colour of the fill(should be red or black), only change the outlines to highlight
        //d. Clicking on the insert button should insert the value/key in the input box. Do proper validation (numbers only, empty box etc.)
        //e. RECOMMENDATION: Use the red and black colors defined in the drawstructure function for the red and black nodes,
        //   While we encourage creative freedom, grading this assignment would kill me and Aleck if we
        //   see different shades of red and black from all of you :).
    }
}
