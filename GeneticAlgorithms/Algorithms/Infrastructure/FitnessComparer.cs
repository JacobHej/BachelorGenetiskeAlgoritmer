using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure
{
    public class FitnessComparer<TIndividual> : Comparer<TIndividual> where TIndividual : IIndividual
    {
        private IFitnessCalculator<TIndividual> fitnessCalculator;

        public FitnessComparer(IFitnessCalculator<TIndividual> fitnessCalculator)
        {
            this.fitnessCalculator = fitnessCalculator;
        }

        public override int Compare(TIndividual? x, TIndividual? y)
        {
            return x == null
                    ? y == null
                        ? 0
                        : 1
                    : y == null
                        ? -1
                        : fitnessCalculator.CalculateFitness(x) - fitnessCalculator.CalculateFitness(y);
        }
    }
}
