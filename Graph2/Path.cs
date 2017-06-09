using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intervalGraphChecker
{
    class Path
    {
        Node start;
        List<Node> memory;
        Node end;

        public Path(Node start, Node end, List<Node> memory = null)
        {
            this.start = start;
            this.memory = new List<Node>(memory);
            this.end = end;
        }


        public override string ToString()
        {
            string outString = "Le chemin correspondant est : " + start + ", ";
            foreach (Node node in memory)
            {
                outString += node.Name + ", ";
            }
            outString += end.Name;
            return outString;
        }
    }
}
