using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class ReplacerBase<TPopulation, TIndividual> :
        IReplacer<TPopulation, TIndividual>
        where TIndividual : IIndividual
        where TPopulation : IPopulation<TIndividual>
    {
        public abstract TPopulation Replace(TPopulation population, List<TIndividual> individuals, IFitnessCalculator<TIndividual> fitnessCalculator);

        private protected class FitnessComparer : Comparer<TIndividual>
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

}
