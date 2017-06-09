using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intervalGraphChecker
{
    class Cycle
    {
        Node start;
        List<Node> memory;
        public Cycle(Node start, Node current, List<Node> memory = null) 
        {
            this.start = start;
            this.Memory = new List<Node>(memory);
            if (start != current)
            {
                throw new Exception(" A cycle need to have the same start and end point");
            }
        }

        internal List<Node> Memory { get => memory; set => memory = value; }

        public override string ToString()
        {
            string outString = "Le cycle correspondant est : "+start+", ";
            foreach (Node node in Memory)
            {
                outString += node.Name + ", ";
            }
            return outString;
        }

        public bool IsIrregular()
        {
            List<Node> nodes = GetAllNode();
       
            if (nodes.Count==3 || nodes.Count-MaximumConnectionWithinCycle()==1 )
            {
                return false;
            }

            int numberOfNodes = GetAllNode().Count;

            for (int i = 0; i < numberOfNodes; i++)
            {
                bool isValid = true;
                int lastNodePosition = i;
                for(int j=2;j< numberOfNodes - 1 && isValid; j++)
                {
                    if (j % 2 == 0)
                    {
                        if (!(GetAllNode().ElementAt(lastNodePosition).IsNeighborWith(GetAllNode().ElementAt( (lastNodePosition + j) % numberOfNodes)))){
                            isValid = false;
                        }
                        lastNodePosition = (lastNodePosition + j) % numberOfNodes;
                    } else
                    {
                        if (!(GetAllNode().ElementAt(lastNodePosition).IsNeighborWith(GetAllNode().ElementAt( (lastNodePosition - j + numberOfNodes) % numberOfNodes))))
                        {
                            isValid = false;
                        }
                        lastNodePosition = (lastNodePosition - j + numberOfNodes) % numberOfNodes;
                    }
                    
                }
                if(isValid) { return false; }
            }

            for (int i = 0; i < numberOfNodes; i++)
            {
                bool isValid = true;
                int lastNodePosition = i;
                for (int j = 2; j < numberOfNodes - 1 && isValid; j++)
                {
                    if (j % 2 == 1)
                    {
                        if (!(GetAllNode().ElementAt(lastNodePosition).IsNeighborWith(GetAllNode().ElementAt((lastNodePosition + j) % numberOfNodes))))
                        {
                            isValid = false;
                        }
                        lastNodePosition = (lastNodePosition + j) % numberOfNodes;
                    }
                    else
                    {
                        if (!(GetAllNode().ElementAt(lastNodePosition).IsNeighborWith(GetAllNode().ElementAt((lastNodePosition - j + numberOfNodes) % numberOfNodes))))
                        {
                            isValid = false;
                        }
                        lastNodePosition = (lastNodePosition - j + numberOfNodes) % numberOfNodes;
                    }

                }
                if (isValid) { return false; }
            }


            return true;
            
           
        }

        public int MaximumConnectionWithinCycle()
        {
            List<Node> cycleNodes = GetAllNode();
            int maxConnection = 2;
            foreach(Node node in cycleNodes)
            {
                if (node.NumberOfConnectionsWith(cycleNodes) > maxConnection)
                {
                    maxConnection = node.NumberOfConnectionsWith(cycleNodes);
                }
            }


            return maxConnection;
        }

        public bool IsUnknown()
        {
            List<Node> nodes = GetAllNode();
            if (nodes.Count > 7)
            {
                return true;
            } else
            {
                return false;
            }
            
        }

        public List<Node> GetAllNode()
        {
            List<Node> memoryWithStart = new List<Node>(Memory);
            memoryWithStart.Add(start);
            return memoryWithStart;
        }
        
        public bool IsSameCycleAs(Cycle cycleToCompare)
        {
            if (GetAllNode().Count == cycleToCompare.GetAllNode().Count)
            {
                if (GetAllNode().All(item => cycleToCompare.GetAllNode().Contains(item)) && cycleToCompare.GetAllNode().All(item => GetAllNode().Contains(item)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
