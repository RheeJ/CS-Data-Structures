//Assignment 7 for EECS 214
//Out: May 30rd, 2014
//Due: June 6th, 2014
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

namespace Assignment_7
{
    public partial class MainWindow : Window
    {
        
        Graph map = new Graph();
        Graph testgraph = new Graph();
        

        public MainWindow()
        {
            
            InitializeComponent();
            searchRouteBtn.Click += searchRouteBtn_Click;

            Plot();
            drawStructure();
        }

        void Plot() {
          GraphNode SF = new GraphNode(new Point(100, 100), "San Francisco");
          GraphNode LA = new GraphNode(new Point(100, 200), "Los Angeles");
          GraphNode SD = new GraphNode(new Point(115, 250), "San Diego");
          GraphNode DA = new GraphNode(new Point(285, 250), "Dallas");
          GraphNode NY = new GraphNode(new Point(425, 115), "New York");
          GraphNode MI = new GraphNode(new Point(400, 300), "Miami");
          GraphNode CH = new GraphNode(new Point(300, 100), "Chicago");
          GraphNode DE = new GraphNode(new Point(225, 115), "Denver");
          map.AddNode(SF);
          map.AddNode(LA);
          map.AddNode(SD);
          map.AddNode(DA);
          map.AddNode(NY);
          map.AddNode(MI);
          map.AddNode(CH);
          map.AddNode(DE);
          map.AddDirectedEdge(DE, SF, 90);
          map.AddDirectedEdge(DE, LA, 100);
          map.AddDirectedEdge(CH, DE, 25);
          map.AddDirectedEdge(CH, SF, 60);
          map.AddDirectedEdge(SF, LA, 45);
          map.AddDirectedEdge(SD, LA, 50);
          map.AddDirectedEdge(NY, DA, 125);
          map.AddDirectedEdge(NY, MI, 90);
          map.AddDirectedEdge(MI, DA, 50);
          map.AddDirectedEdge(DA, SD, 80);
          map.AddDirectedEdge(DA, LA, 80);
          map.AddDirectedEdge(NY, DE, 100);
          map.AddDirectedEdge(NY, CH, 80);
        }
        void searchRouteBtn_Click(object sender, RoutedEventArgs e)
        {
            String from = fromInput.Text;
            String to = toInput.Text;
            map.DijkstraShortestAlg(from, to);
            drawStructure();
        }

        private void drawStructure()
        {
            canvas.Children.Clear();
            int counter = 0;

             List<Line> shortestpathlines = new List<Line>();
             foreach (GraphNode city in map.DijkstraShortestPath)
             {
                 if (map.DijkstraShortestPath.IndexOf(city) != map.DijkstraShortestPath.Count - 1)
                 {
                     GraphNode predecessor = city.predecessor;
                     Line connector = new Line();
                     connector.X1 = city.position.X + 30 / 2;
                     connector.Y1 = city.position.Y + 30 / 2;
                     connector.X2 = predecessor.position.X + 30 / 2;
                     connector.Y2 = predecessor.position.Y + 30 / 2;
                     connector.StrokeThickness = 2;
                     connector.Stroke = new SolidColorBrush(Color.FromRgb(175, 175, 175));
                     shortestpathlines.Add(connector);
                     counter++;
                 }
             }
           
            foreach (GraphNode city in map.Nodes) {
              Ellipse e = new Ellipse();
              e.Height = 30;
              e.Width = 30;
              
              e.StrokeThickness = 3;
              if (map.DijkstraShortestPath.Contains(city))
              {
                  e.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 255));
                  e.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));
              }
              else
              {
                  e.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                  e.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));
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
