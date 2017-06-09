using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intervalGraphChecker
{
    class Program
    {
        static void Main(string[] args)
        {
             Node ann = new Node("Ann");
             Node betty = new Node("Betty");
             Node cynthia = new Node("Cynthia");
             Node diana = new Node("Diana");
             Node emily = new Node("Emily");
             Node felicia = new Node("Felicia");
             Node helen = new Node("Helen");
             Node georgia = new Node("Georgia");


            // -- graphe irréguliers
            ann.AddNeighbors(betty,cynthia,emily,felicia,georgia);
            betty.AddNeighbors(cynthia, helen);
            cynthia.AddNeighbors(diana, emily, helen);
            diana.AddNeighbors(emily);
            emily.AddNeighbors(felicia);
            helen.AddNeighbors(georgia);





            // - graphes réguliers
            /* ann.AddNeighbors(betty);
             betty.AddNeighbors(diana,cynthia,emily);
             cynthia.AddNeighbors( emily, georgia);
             diana.AddNeighbors(emily,felicia);
             emily.AddNeighbors(felicia,georgia);
             felicia.AddNeighbors(georgia);*/


           /* ann.AddNeighbors(betty,cynthia,diana);
            betty.AddNeighbors(diana, cynthia, emily);
            cynthia.AddNeighbors(emily, georgia);
            diana.AddNeighbors(emily, felicia);
            emily.AddNeighbors(felicia, georgia);
            felicia.AddNeighbors(georgia);
            A.AddArcs(B, C, D);
            B.AddArcs(A, C);
            C.AddArcs(B, A, D, F, E);
            D.AddArcs(A, C, F, E);
            E.AddArcs(C, D);
            F.AddArcs(D, C, G);
            G.AddArcs(F);*/




            List<Node> everyone = new List<Node>();
            everyone.Add(ann);
            everyone.Add(betty);
            everyone.Add(cynthia);
            everyone.Add(diana);
            everyone.Add(emily);
            everyone.Add(felicia);
            everyone.Add(helen);
            everyone.Add(georgia);


            foreach (Node person in everyone)
            {
                Console.Out.WriteLine(person.ToString());
            }

            Path annToAnnPath = new Path(ann, ann, null, true);

            CycleList cycles = new CycleList();

            annToAnnPath.GetAllCycle(ref cycles);

            foreach (Cycle cycle in cycles)
            {
                Console.Out.WriteLine(cycle.ToString());

            }

            Console.Out.WriteLine();
            Console.Out.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.Out.WriteLine("-------------------------------------CYCLES IRREGULIERS------------------------------------------------");
            Console.Out.WriteLine("-------------------------------------------------------------------------------------------------------");

            foreach(Cycle cycle in cycles.GetAllIrregularCycle())
            {
              Console.Out.WriteLine(cycle.ToString());
            }

            Console.Out.WriteLine();


            Console.ReadLine();
        }
    }
}
