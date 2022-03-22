using Algorithms.Infrastructure;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class SelectXBestSelector<TPopulation, TIndividual> :
        SelectorBase<TPopulation, TIndividual>
        where TPopulation : IPopulation<TIndividual>
        where TIndividual : IIndividual
    {
        private IFitnessCalculator<TIndividual> fitnessCalculator;

        public SelectXBestSelector(IFitnessCalculator<TIndividual> fitnessCalculator)
        {
            this.fitnessCalculator = fitnessCalculator;
        }

        public override TIndividual Select(TPopulation population)
        {
            IComparer<TIndividual> comparer = new FitnessComparer<TIndividual>(fitnessCalculator);

            population.Individuals.Sort(comparer);

            return (TIndividual)population.Individuals[0].Copy();
        }

        public override (TPopulation, List<TIndividual>) SelectMultiple(TPopulation population, int selectionSize)
        {
            if (selectionSize > population.PopulationSize) return (default(TPopulation), default(List<TIndividual>));

            TPopulation newPopulation = (TPopulation)population.Copy();
            
            newPopulation.Individuals.Sort(new FitnessComparer<TIndividual>(fitnessCalculator));

            List<TIndividual> individuals = newPopulation.Individuals.Skip(population.PopulationSize - selectionSize).ToList();

            individuals.ForEach(individual => newPopulation.Individuals.Remove(individual));

            return (newPopulation, individuals);
        }
    }
}
