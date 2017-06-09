using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intervalGraphChecker
{

    class CycleList : List<Cycle>
    {
        int maxMemoryCycle = 0;
        int minMemoryCycle = int.MaxValue;
        public new void Add(Cycle cycleToAdd)
        {
            foreach (Cycle cycle in this)
            {
                if (cycle.IsSameCycleAs(cycleToAdd))
                {
                    return;
                }
            }

            if (cycleToAdd.Memory.Count < minMemoryCycle)
            {
                minMemoryCycle = cycleToAdd.GetAllNode().Count;
            }

            if (cycleToAdd.Memory.Count > maxMemoryCycle)
            {
                maxMemoryCycle = cycleToAdd.GetAllNode().Count;
            }

            base.Add(cycleToAdd);
        }

        public CycleList GetAllIrregularCycle()
        {
            CycleList outCycleListComplete = new CycleList();
            foreach (Cycle cycle in this)
            {
                if (cycle.IsIrregular())
                {
                    outCycleListComplete.Add(cycle);
                }
            }
            
            return outCycleListComplete.EliminateImplicitIrregularities();
        }

        public CycleList EliminateImplicitIrregularities()
        {

            CycleList outCycleList = new CycleList();
            for (int i = minMemoryCycle; i < maxMemoryCycle; i++)
            {
                var cycleListToCheck = this.Where(Cycle => Cycle.GetAllNode().Count == i);

                foreach (Cycle cycleToCheck in cycleListToCheck)
                {
                    int numberOfNodes = cycleToCheck.GetAllNode().Count;
                    bool isSubCycleSameAsSmallerCycle = false;
                    for (int j = 0; j < numberOfNodes; j++)
                    {
                        for (int subCircleSize = 4; subCircleSize < numberOfNodes; subCircleSize++)
                        {
                            List<Node> subMemory = new List<Node>();
                            for(int k=1;k< subCircleSize; k++)
                            {
                                subMemory.Add(cycleToCheck.GetAllNode().ElementAt((j + k) % numberOfNodes));
                            }
                            Cycle subCycle = new Cycle(cycleToCheck.GetAllNode().ElementAt(j), cycleToCheck.GetAllNode().ElementAt(j), subMemory);
                            foreach (Cycle smallerCycle in outCycleList)
                            {
                                if (subCycle.IsSameCycleAs(smallerCycle))
                                {
                                    isSubCycleSameAsSmallerCycle = true;
                                }
                            }
                        }
                        
                    }
                    if (!isSubCycleSameAsSmallerCycle)
                    {
                        outCycleList.Add(cycleToCheck);
                    }
                }
            }

            return outCycleList;

        }
    }
}
