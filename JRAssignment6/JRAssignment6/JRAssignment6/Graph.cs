//Assignment 6 for EECS 214
//Out: May 23rd, 2014
//Due: May 30th, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Assignment_6
{

    public class GraphNode
    {
        //Other than the fields you included in the earlier asignment
        //Add these two fields (basically to use them in the visualizer)
        //Point position and String name
        //Consider writing properties or constructors to get/set these
        public GraphNode(int v)
        {
            value = v;
            neighbors = new List<GraphNode>();
            weights = new List<int>();
        }

        public GraphNode(Point p, String c)
        {
            position = p;
            name = c;
            neighbors = new List<GraphNode>();
            weights = new List<int>();
        }

        public int value
        {
            get;
            set;
        }

        public List<int> weights
        {
            get;
            set;
        }

        public List<GraphNode> neighbors
        {
            get;
            set;
        }

        public Point position
        {
            get;
            set;
        }

        public String name
        {
            get;
            set;
        }

        public GraphNode before
        {
            get;
            set;
        }

        public int distance
        {
            get;
            set;
        }

        public int component
        {
            get;
            set;
        }
    }
    public class Graph
    {

        private List<GraphNode> nodes = new List<GraphNode>();
        private List<GraphNode> shortestpath = new List<GraphNode>();
        private List<GraphNode> visited = new List<GraphNode>();

        public void AddNode(GraphNode node)
        {
            nodes.Add(node);
        }

          public void AddNode(Point pos, String city) 
          {
            GraphNode temp = new GraphNode(pos, city);
            nodes.Add(temp);
          }


        public void AddNode(int value)
        {
          GraphNode temp = new GraphNode(value);
          nodes.Add(temp);
        }


        public void AddDirectedEdge(GraphNode from, GraphNode to, int weight)
        {
          from.neighbors.Add(to);
          from.weights.Add(weight);
        }

        public void AddUndirectedEdge(GraphNode from, GraphNode to, int cost)
        {
          from.neighbors.Add(to);
          to.neighbors.Add(from);
          from.weights.Add(cost);
          to.weights.Add(cost);
        }

        public bool Contains(int val)
        {
          foreach (GraphNode node in nodes) 
          {
            if (node.value == val) 
            {
              return true;
            }
          }
          return false;
        }


        public bool Remove(int val)
        {
          GraphNode nodeWithValue = null;

            foreach (GraphNode node in nodes) 
            {
              if (node.value == val) 
              {
                nodeWithValue = node;
              }
            }

            if (nodeWithValue == null) 
            {
                return false;
            }

            nodes.Remove(nodeWithValue);
            foreach (GraphNode node in nodes) 
            {
              int index = node.neighbors.IndexOf(nodeWithValue);
              if (index != 0) 
              {
                node.weights.RemoveAt(index);
                node.neighbors.Remove(nodeWithValue);
              }
            }
            return true;
          }

          public void FindShortestPath(String from, String to) 
          {
            
              shortestpath = new List<GraphNode>();
              Queue<GraphNode> q = new Queue<GraphNode>();
              List<GraphNode> visited = new List<GraphNode>();
              GraphNode start = null; 
              GraphNode end = null;
            
              foreach (GraphNode node in nodes) 
              {
                  if (node.name == from)               
                  {     
                      start = node;
                  }
                  else if (node.name == to) 
                  {
                      end = node;
                  }
            }
            q.Enqueue(start);
            start.distance =  0;
            start.before = null;
            visited.Add(start);
            while (q.Count != 0) 
            {
              GraphNode node = q.Dequeue();
              if (node == end) 
              {
                GraphNode current = node;
                while (node != start) 
                {
                  shortestpath.Add(node);
                  node = node.before;
                }
                shortestpath.Add(start);
                q.Clear();
              }
              else 
              {
                int counter = 0;
                foreach (GraphNode neighbor in node.neighbors) 
                {
                    if (visited.Contains(neighbor))
                    {
                    }
                    else
                    {
                        q.Enqueue(neighbor);
                        neighbor.distance = node.distance + node.weights[counter];
                        neighbor.before = node;
                    }
                  counter++;
                }
              }
            }
          }


          public void Draw()
          {
              GraphNode one = new GraphNode(1);
              GraphNode two = new GraphNode(2);
              GraphNode three = new GraphNode(3);
              GraphNode four = new GraphNode(4);
              GraphNode five = new GraphNode(5);
              GraphNode six = new GraphNode(6);
              GraphNode seven = new GraphNode(7);
              GraphNode eight = new GraphNode(8);
              GraphNode nine = new GraphNode(9);
              GraphNode ten = new GraphNode(10);
              GraphNode eleven = new GraphNode(11);

              AddNode(one);
              AddNode(two);
              AddNode(three);
              AddNode(four);
              AddNode(five);
              AddNode(six);
              AddNode(seven);
              AddNode(eight);
              AddNode(nine);
              AddNode(ten);
              AddNode(eleven);

              AddUndirectedEdge(one, two, 1);
              AddUndirectedEdge(four, five, 1);
              AddUndirectedEdge(two, one, 1);
              AddUndirectedEdge(two, seven, 1);
              AddUndirectedEdge(three, four, 1);
              AddUndirectedEdge(nine, eleven, 1);
              AddUndirectedEdge(eight, two, 1);
              AddUndirectedEdge(eleven, one, 1);
              AddUndirectedEdge(six, seven, 1);
              AddUndirectedEdge(five, nine, 1);
              AddUndirectedEdge(eight, seven, 1);
          }

          public void Label()
          {
              int component = 0;
              visited = new List<GraphNode>();
              foreach (GraphNode node in nodes) 
              {
                  if (!visited.Contains(node))
                  {
                      Visit(node, component);
                      component++;
                  }
              }

             
          }

          public void Visit(GraphNode node, int c)
          {
              visited.Add(node);
              node.component = 0;
              foreach (GraphNode neighbor in node.neighbors)
              {
                  if (!visited.Contains(neighbor))
                  {
                      Visit(neighbor, c);
                  }
              }
          }

          public static void Main2()
          {
              Graph G = new Graph();
              G.Draw();
              G.Label();
              foreach (GraphNode node in G.nodes)
              {
                  Console.WriteLine("Node %d: Component %d", node.value, node.component);
              }
          }

        public List<GraphNode> Nodes
        {
            get 
            {
              return nodes;
            }
          }

          public List<GraphNode> ShortestPath {
            get 
            {
              return shortestpath;
            }
          }

        public int Count
        {
            //fill this up, otherwise it'll generate a property/indexer error 
            get 
            {
              return nodes.Count;
            }
          }
        }


      }
    
