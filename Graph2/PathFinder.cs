using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intervalGraphChecker
{
    class PathFinder
    {
        Node start;
        List<Node> memory;
        Node current;
        Node end;
        CycleList cycles;
        List<PathFinder> childPath;
        List<Path> completedPath;
        public PathFinder(Node start,Node end,List<Node> memory=null,bool isOrigin=false,Node current=null)
        {
            this.start = start;
            cycles = new CycleList();
            childPath = new List<PathFinder>();
            completedPath = new List<Path>();
            this.current = (current==null)?start:current;
            this.end = end;
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

            foreach (Node neighbor in this.current.Neighbors)
            {
                if (!this.memory.Contains(neighbor))
                {
                    if(neighbor==start )
                    {
                        if (!(this.memory.Count <= 1))
                        {
                            cycles.Add(new Cycle(start, end, this.memory));
                        }
                    } else if (neighbor==end)
                    {
                        completedPath.Add(new Path(start, end, this.memory));
                        childPath.Add(new PathFinder(start, end, this.memory, false, neighbor));
                    } else
                    {
                        childPath.Add(new PathFinder(start, end, this.memory,false,neighbor));
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
            foreach(PathFinder path in childPath)
            {
                path.GetAllCycle(ref cycles);
            }
            foreach(Cycle cycle in this.cycles)
            {
                cycles.Add(cycle);
            }
            return cycles;
        }

        public List<Path> GetAllCompletedPath(ref List<Path> paths)
        {
            foreach (PathFinder pathFinder in childPath)
            {
                pathFinder.GetAllCompletedPath(ref paths);
            }
            foreach (Path path in this.completedPath)
            {
                paths.Add(path);
            }
            return paths;
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
