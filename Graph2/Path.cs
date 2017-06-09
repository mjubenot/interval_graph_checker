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
        Node current;
        CycleList cycles;
        List<Path> childPath;
        public Path(Node start,Node current,List<Node> memory=null,bool isOrigin=false)
        {
            this.start = start;
            cycles = new CycleList();
            childPath = new List<Path>();
            this.current = current;
            if (memory == null)
            {

                this.memory = new List<Node>();
            } else
            {
                this.memory = memory;
            }
            

            if (!isOrigin)
            {

                this.memory.Add(current);
            }
            string outString = "Start of " + current + ". Memory is composed of ";
            foreach (Node node in this.memory)
            {
                outString += node.Name + ", ";
            }
            Console.Out.WriteLine(outString);

            //Console.Out.WriteLine(ToString());

            foreach (Node neighbor in current.Neighbors)
            {
                if (!this.memory.Contains(neighbor))
                {
                    if(neighbor==start )
                    {
                        if (!(this.memory.Count <= 1))
                        {
                            cycles.Add(new Cycle(start, neighbor, this.memory));
                        }
                    } else
                    {
                        childPath.Add(new Path(start, neighbor, this.memory));
                    }
                    
                }
            }
            this.memory.Remove(current);
            outString = "End of " + current + ". Memory is composed of ";
            foreach (Node node in this.memory)
            {
                outString += node.Name + ", ";
            }
            Console.Out.WriteLine(outString);
        }

        public CycleList GetAllCycle(ref CycleList cycles)
        {
            foreach(Path path in childPath)
            {
                path.GetAllCycle(ref cycles);
            }
            foreach(Cycle cycle in this.cycles)
            {
                cycles.Add(cycle);
            }
            return cycles;
        }

        public override string ToString()
        {
            string outString = "Le path d'origine " + start.Name + " et qui est au " + current.Name + " et qui est passer par ";
            foreach(Node node in memory)
            {
                outString+=node.Name+", ";
            }
            outString += "viens d'être créer";
            return outString;
        }
    }
}
