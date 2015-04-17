//Assignment 5 for EECS 214
//Out: May 16th, 2014
//Due: May 23rd, 2014

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

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///Don't worry about this being defined as a partial class, a partial class just allows you to split up code in 
    ///different files while telling the compiler to splice them together during compilation
    public partial class MainWindow : Window
    {
        SkipNode foundNode;
        SkipList list = new SkipList();
        List<int> keyList = new List<int>() {
            1,2,3,4,5,6,7,8,9
        };

        public MainWindow()
        {
            
            InitializeComponent();
            
            //Registering callbacks for the 3 buttons
            searchBtn.Click += searchBtn_Click;
            insertBtn.Click += insertBtn_Click;
            removeBtn.Click += removeBtn_Click;
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

        void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text == "")
            {
                MessageBoxResult message1 = MessageBox.Show("Enter a value to insert first!");
            }
            else
            {
                int addValue = Convert.ToInt32(input.Text);
                list.Remove(addValue);
                keyList.Remove(addValue);
                drawStructure();
            }
        }

        void insertBtn_Click(object sender, RoutedEventArgs e)
         {
            if (input.Text == "")
            {
                MessageBoxResult message1 = MessageBox.Show("Enter a value to insert first!");
            }
            else
            {
                int addValue = Convert.ToInt32(input.Text);
                list.Insert(addValue);
                keyList.Add(addValue);
                drawStructure();
            }
        }

        //Search for an element in the RBTree
        void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text == "")
            {
                MessageBoxResult message1 = MessageBox.Show("Enter a value to search first!");
            }
            else
            {
                int searchItem = Convert.ToInt32(input.Text);
                foundNode = (SkipNode)list.Search(list.root, searchItem);
                if (foundNode == null)
                {
                    MessageBoxResult message1 = MessageBox.Show("Cannot find value!");
                }
                else
                {
                    search = true;
                }
                drawStructure();
            }
        }


        //Draw contents of the Skip List
        private void drawStructure()
        {
            //Feel free to use whatever colours you want
        }
    }
}
