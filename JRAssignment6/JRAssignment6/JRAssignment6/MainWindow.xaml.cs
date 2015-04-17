//Assignment 6 for EECS 214
//Out: May 23rd, 2014
//Due: May 30th, 2014
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

namespace Assignment_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///Don't worry about this being defined as a partial class, a partial class just allows you to split up code in 
    ///different files while telling the compiler to splice them together during compilation
    public partial class MainWindow : Window
    {
        Graph FlightMap = new Graph();

        public MainWindow()
        {
            
            InitializeComponent();
            
            searchRouteBtn.Click += searchRouteBtn_Click;

            Plot();
            drawStructure();
        }

        void Plot() 
        {
          GraphNode Chitown = new GraphNode(new Point(300, 100), "Chicago");
          GraphNode NYC = new GraphNode(new Point(425, 115), "New York");
          GraphNode Dallas = new GraphNode(new Point(285, 250), "Dallas");
          GraphNode Denver = new GraphNode(new Point(225, 115), "Denver");
          GraphNode SanDiego = new GraphNode(new Point(115, 250), "San Diego");
          GraphNode SanFran = new GraphNode(new Point(100, 100), "San Francisco");
          GraphNode LosAng = new GraphNode(new Point(100, 200), "Los Angeles");
          GraphNode Miami = new GraphNode(new Point(400, 300), "Miami");

          FlightMap.AddNode(Chitown);
          FlightMap.AddNode(Denver);
          FlightMap.AddNode(NYC);
          FlightMap.AddNode(SanDiego);
          FlightMap.AddNode(Dallas);
          FlightMap.AddNode(SanFran);
          FlightMap.AddNode(LosAng);
          FlightMap.AddNode(Miami);

          FlightMap.AddDirectedEdge(SanFran, LosAng, 45);
          FlightMap.AddDirectedEdge(SanDiego, LosAng, 50);
          FlightMap.AddDirectedEdge(Dallas, SanDiego, 80);
          FlightMap.AddDirectedEdge(Dallas, LosAng, 80);
          FlightMap.AddDirectedEdge(Denver, SanFran, 90);
          FlightMap.AddDirectedEdge(Denver, LosAng, 100);
          FlightMap.AddDirectedEdge(Chitown, Denver, 25);
          FlightMap.AddDirectedEdge(NYC, Denver, 100);
          FlightMap.AddDirectedEdge(NYC, Chitown, 80);
          FlightMap.AddDirectedEdge(NYC, Dallas, 125);
          FlightMap.AddDirectedEdge(NYC, Miami, 90);
          FlightMap.AddDirectedEdge(Miami, Dallas, 50);
        }

        void searchRouteBtn_Click(object sender, RoutedEventArgs e)
        {
            String from = fromInput.Text;
            String to = toInput.Text;
            FlightMap.FindShortestPath(from, to);
            drawStructure();
        }

        private void drawStructure()
        {
            canvas.Children.Clear();
            int counter = 0;

             List<Line> shortestpathlines = new List<Line>();
             foreach (GraphNode city in FlightMap.ShortestPath)
             {
                 if (FlightMap.ShortestPath.IndexOf(city) != FlightMap.ShortestPath.Count - 1)
                 {
                     GraphNode before = city.before;
                     Line l = new Line();
                     l.X1 = city.position.X + 15;
                     l.Y1 = city.position.Y + 15;
                     l.X2 = before.position.X + 15;
                     l.Y2 = before.position.Y + 15;
                     l.StrokeThickness = 2;
                     l.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                     shortestpathlines.Add(l);
                     counter++;
                 }
             }
           
            foreach (GraphNode city in FlightMap.Nodes) 
            {
              Ellipse e = new Ellipse();
              e.Height = 30;
              e.Width = 30;
              
              if (FlightMap.ShortestPath.Contains(city))
              {
                  e.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 255));
              }
              else
              {
                  e.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
              }
              Canvas.SetLeft(e, city.position.X);
              Canvas.SetTop(e, city.position.Y);
              canvas.Children.Add(e);

              Label l = new Label();
              l.Content = city.name;
              Canvas.SetLeft(l, city.position.X);
              Canvas.SetTop(l, city.position.Y - 20);

              canvas.Children.Add(l);
            }

            foreach (Line ln in shortestpathlines)
            {
                canvas.Children.Add(ln);
            }

        }

    }
}
