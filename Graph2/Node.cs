using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intervalGraphChecker
{
    class Node
    {
        List<Node> neighbors;
        String name;

        internal List<Node> Neighbors { get => neighbors; set => neighbors = value; }
        public string Name { get => name; set => name = value; }

        public Node(string name="Not named")
        {
            InitializeNode(name);
        }

        public Node(List<Node> neighbors,string name = "Not named")
        {
            InitializeNode(name);
            this.Neighbors = neighbors;
        }

    private void InitializeNode(string name)
    {
            this.Name = name;
            Neighbors = new List<Node>();
    }

        public void AddNeighbor(Node neighbor, bool callOther = true)
        {
            Neighbors.Add(neighbor);
            if (callOther) {
                neighbor.AddNeighbor(this,false);
            }
        }

        public void AddNeighbors(params Node[] neighbors)
        {
            foreach(Node neighbor in neighbors) {
                AddNeighbor(neighbor);
            }
        }

        public override string ToString()
        {
            /*string outString= "My name is " + Name + " and my neighborhood is composed of ";
            foreach(Node neighbor in neighbors)
            {
                outString += neighbor.Name + ", ";
            }
            return outString;*/
            return name;
        }

        public bool IsNeighborWith(Node neighbor)
        {
            return neighbors.Contains(neighbor);
        }

        /// <summary>
        /// Take a list of node and return how many this node is connected with
        /// </summary>
        /// <param name="nodes"> The list of node you want to check connections with</param>
        /// <returns> The return of node this node is connected with</returns>
        public int NumberOfConnectionsWith(List<Node> nodes)
        {
            int numberOfNode = 0;
            foreach(Node node in nodes)
            {
                if (IsNeighborWith(node))
                {
                    numberOfNode++;
                }
            }
            return numberOfNode;
        }
    }
}
