//Assignment 4 for EECS 214
//Out: May 7th, 2014
//Due: May 16th, 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_5
{
    public class Graph
    {
        public class GraphNode
        {
            public int v;
            public List<GraphNode> adjacency
            {
                get;
                set;
            }
            public List<int> weights
            {
                get;
                set;
            }
            public GraphNode(int value)
            {
                v = value;
            }
            public GraphNode(int value, List<GraphNode> neighbors)
            {
                v = value;
                adjacency = neighbors;
            }
            //This class should have a value, 
            //a list of integer weights
            //and an adjacency list of neighbors (you can use the C# List class)
            //Write the properties that get or set these
        }

        public List<GraphNode> nodes;
        //the Graph class should have a list of graphnodes  
        //something like private List<GraphNode> nodes;

        /// <summary>
        /// Should add the node to the list of nodes
        /// </summary>
        public void AddNode(GraphNode node)
        {
            nodes.Add(node);
            // adds a node to the graph
        }

        /// <summary>
        /// Creates a new graphnode from an input value and adds it to the list of graph nodes
        /// </summary>
        public void AddNode(int value)
        {
            GraphNode newNode = new GraphNode(value);
            nodes.Add(newNode);
        }

        /// <summary>
        /// Adds a directed edge from one GraphNode to another. 
        /// Also insert the corresponding weight 
        /// </summary>
        public void AddDirectedEdge(GraphNode from, GraphNode to, int weight)
        {
            from.adjacency.Add(to);
            from.weights.Add(weight);
        }

        /// <summary>
        /// Adds an undirected edge from one GraphNode to another. 
        /// Remember this means that both the from and two are neighbors of each other
        /// Also insert the corresponding weight 
        /// </summary>
        public void AddUndirectedEdge(GraphNode from, GraphNode to, int cost)
        {
            from.adjacency.Add(to);
            from.weights.Add(cost);
            to.adjacency.Add(from);
            to.weights.Add(cost);
        }

        //Check if a value exists in the graph or not
        public bool Contains(int value)
        {
            GraphNode temp = new GraphNode(value);
            return nodes.Contains(temp);
        }

        /// <summary>
        /// Should remove a node and all its edges and return true if successful
        /// </summary>
        public bool Remove(int value)
        {
            GraphNode temp = new GraphNode(value);
            if (nodes.Contains(temp))
            {
                nodes.Remove(temp);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Is a property and returns the list of nodes, should be a one-liner
        /// </summary>
        public List<GraphNode> Nodes
        {
            get
            {
                return nodes;
            }
            //fill this up, otherwise it'll generate a property/indexer error
        }

        /// <summary>
        /// Is a property and returns the number of nodes in the graph, should be one-liner
        /// </summary>
        public int Count
        {
            get
            {
                return nodes.Count;
            }
            //fill this up, otherwise it'll generate a property/indexer error 
        }
    }
}
