using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.TravelingSalesPerson
{
    public class TravelingSalesPersonIndividual : IndividualBase
    {
        public int[] Solution;

        public TravelingSalesPersonIndividual(int length, bool random = true)
        {
            Solution = 
                random 
                ? Enumerable.Range(0, length).OrderBy(item => new Random().Next()).ToArray() 
                : Enumerable.Range(0, length).ToArray();
        }
        public TravelingSalesPersonIndividual(int[] solution)
        {
            Solution = solution;
        }

        public override IIndividual Copy()
        {
            int[] newArray = new int[Solution.Length];
            Solution.CopyTo(newArray, 0);

            return new TravelingSalesPersonIndividual(newArray);
        }
    }
}
