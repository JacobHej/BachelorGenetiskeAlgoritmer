using Algorithms.Infrastructure;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.OnePlusOneEA
{
    public class ReplaceWorstReplacer<TPopulation, TIndividual> : 
        ReplacerBase<TPopulation, TIndividual>
        where TIndividual : IIndividual
        where TPopulation : IPopulation<TIndividual>
    {
        public override TPopulation Replace(TPopulation population, List<TIndividual> individuals, IFitnessCalculator<TIndividual> fitnessCalculator)
        {
            TPopulation newPopulation = (TPopulation) population.Copy();

            IComparer<TIndividual> comparer = new FitnessComparer<TIndividual>(fitnessCalculator);

            newPopulation.Individuals.Sort(comparer);
            individuals.Sort(comparer);

            int j = individuals.Count - 1; 

            for(int i = 0; i < newPopulation.Individuals.Count; i++)
            {
                newPopulation.Individuals[i] = individuals[j--];
            }

            return newPopulation;
        }
    }
}
