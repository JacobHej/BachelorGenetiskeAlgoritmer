using Algorithms.Infrastructure.BaseImplementations;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.TravelingSalesPerson
{
    public class PoissonTwoOptMutator : MutatorBase<TravelingSalesPersonIndividual>
    {
        private double lambda;

        public PoissonTwoOptMutator(double lambda)
        {
            this.lambda = lambda;
        }

        public override TravelingSalesPersonIndividual Mutate(TravelingSalesPersonIndividual individual)
        {
            TravelingSalesPersonIndividual newIndividual = (TravelingSalesPersonIndividual)individual.Copy();
            int twoOptCount = Poisson.Sample(lambda);
            Random random = new Random();

            for (int j = 0; j < twoOptCount; j++)
            {
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
            }

            return newIndividual;
        }
    }
}
