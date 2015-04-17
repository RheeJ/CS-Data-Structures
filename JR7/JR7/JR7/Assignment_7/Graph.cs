//Assignment 7 for EECS 214
//Out: May 30rd, 2014
//Due: June 6th, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Assignment_7
{
    public class GraphNode : IComparable<GraphNode>
    {
        public GraphNode(int key)
        {
            val = key;
            neighbors = new List<GraphNode>();
            weights = new List<int>();
        }

        public GraphNode(Point point, String city)
        {
            position = point;
            name = city;
            neighbors = new List<GraphNode>();
            weights = new List<int>();
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
        public int val
        {
            get;
            set;
        }
        public List<int> weights
        {
            get;
            set;
        }
        public GraphNode predecessor
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
        private int cost;
        public int costSet
        {
            get { return cost; }
            set { cost = value; }
        }
        public int CompareTo(GraphNode other)
        {
            if (this.cost < other.cost) return -1;
            else if (this.cost > other.cost) return 1;
            else return 0;
        }
    }
    public class Graph
    {
        private List<GraphNode> nodes = new List<GraphNode>();
        private List<GraphNode> shortestPath = new List<GraphNode>();
        private List<GraphNode> Visited = new List<GraphNode>();
        private List<GraphNode> Final = new List<GraphNode>();

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

        public bool Contains(int key)
        {
            foreach (GraphNode node in nodes)
            {
                if (node.val == key)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int key)
        {
            GraphNode nodeWithValue = null;

            foreach (GraphNode node in nodes)
            {
                if (node.val == key)
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
                if (index != null)
                {
                    node.weights.RemoveAt(index);
                    node.neighbors.Remove(nodeWithValue);
                }
            }
            return true;
        }

        public void FindShortestPath(String from, String to)
        {
            shortestPath = new List<GraphNode>();
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
            start.distance = 0;
            start.predecessor = null;
            visited.Add(start);
            while (q.Count != 0)
            {
                GraphNode node = q.Dequeue();
                if (node == end)
                {
                    GraphNode current = node;
                    while (node != start)
                    {
                        shortestPath.Add(node);
                        node = node.predecessor;
                    }
                    shortestPath.Add(start);
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
                            neighbor.predecessor = node;
                        }
                        counter++;
                    }
                }
            }
        }


        public void HGraph()
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
            GraphNode twelve = new GraphNode(12);

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
            AddNode(twelve);

            AddUndirectedEdge(one, two, 1);
            AddUndirectedEdge(four, seven, 1);
            AddUndirectedEdge(two, one, 1);
            AddUndirectedEdge(two, four, 1);
            AddUndirectedEdge(three, one, 1);
            AddUndirectedEdge(nine, eight, 1);
            AddUndirectedEdge(eight, twelve, 1);
            AddUndirectedEdge(eleven, twelve, 1);
            AddUndirectedEdge(seven, eleven, 1);
            AddUndirectedEdge(five, eleven, 1);
        }

        public void LCC()
        {
            int component = 0;
            Visited = new List<GraphNode>();
            foreach (GraphNode node in nodes)
            {
                if (!Visited.Contains(node))
                {
                    Visit(node, component);
                    component++;
                }
            }
        }
        public void Visit(GraphNode node, int c)
        {
            Visited.Add(node);
            node.component = 0;
            foreach (GraphNode neighbor in node.neighbors)
            {
                if (!Visited.Contains(neighbor))
                {
                    Visit(neighbor, c);
                }
            }
        }

        public static void Main2()
        {
            Graph testgraph = new Graph();
            testgraph.HGraph();
            testgraph.LCC();
            foreach (GraphNode node in testgraph.nodes)
            {
                Console.WriteLine("Node %d: Component %d", node.val, node.component);
            }
        }

        public List<GraphNode> Nodes
        {
            get
            {
                return nodes;
            }
        }

        public List<GraphNode> ShortestPath
        {
            get
            {
                return shortestPath;
            }
        }

        public int Count
        {
            get
            {
                return nodes.Count;
            }
        }

        public List<GraphNode> DijkstraShortestPath
        {
            get
            {
                return Final;
            }
        }

        public List<GraphNode> DijkstraShortestAlg(string start, string finish)
        {
            Final = new List<GraphNode>();
            PriorityQueue<GraphNode> PQ = new PriorityQueue<GraphNode>();
            GraphNode begin = null;
            foreach (GraphNode node in nodes)
            {
                if (node.name == start)
                {
                    begin = node;
                }
            }
            foreach (GraphNode node in nodes)
            {
                node.costSet = 999999999;
            }
            begin.costSet = 0;

            foreach (GraphNode node in nodes)
            {
                PQ.Insert(node);
            }
            while (PQ.Count() > 0)
            {
                GraphNode n = PQ.ExtractMin();
                if (n.name == finish)
                {
                    while (n.name != start)
                    {
                        Final.Add(n);
                        n = n.predecessor;
                    }
                    Final.Add(n);
                    return Final;
                }
                else
                {

                    foreach (GraphNode neighbor in n.neighbors)
                    {
                        if (PQ.Data.Contains(neighbor))
                        {
                            int index = n.neighbors.IndexOf(neighbor);
                            int w = n.weights[index];
                            int newCost = n.costSet + w;
                            if (newCost < neighbor.costSet)
                            {
                                neighbor.costSet = newCost;
                                PQ.DecreaseKey(PQ.Data.IndexOf(neighbor));
                                neighbor.predecessor = n;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return Final;
            
        }
    }
}