using Algorithms.Infrastructure.BaseImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.TravelingSalesPerson
{
    public class TwoOptMutator : MutatorBase<TravelingSalesPersonIndividual>
    {
        public override TravelingSalesPersonIndividual Mutate(TravelingSalesPersonIndividual individual)
        {
            TravelingSalesPersonIndividual newIndividual = (TravelingSalesPersonIndividual) individual.Copy();
            Random random = new Random();

            int r1 = 0;
            int r2 = 0;

            while (r1 == r2)
            {
                r1 = random.Next(0, newIndividual.Solution.Length);
                r2 = random.Next(0, newIndividual.Solution.Length);
            }

            int seqLength = Math.Abs(r1 - r2);
            int startIndex = Math.Min(r1, r2);

            for (int i = startIndex; i < startIndex + ((seqLength + 1) / 2); i++)
            {
                int inverseIndex = startIndex + seqLength - (i - startIndex);

                int temp = newIndividual.Solution[i];
                newIndividual.Solution[i] = newIndividual.Solution[inverseIndex];
                newIndividual.Solution[inverseIndex] = temp;
            }

            return newIndividual;
        }
    }
}
