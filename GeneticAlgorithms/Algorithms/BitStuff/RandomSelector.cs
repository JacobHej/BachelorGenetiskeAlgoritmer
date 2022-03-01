using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class RandomSelector<TPopulation, TIndividual> : 
        SelectorBase<TPopulation, TIndividual> 
        where TPopulation : IPopulation<TIndividual>
        where TIndividual : IIndividual
    {
        public override TIndividual Select(TPopulation population)
        {
            Random random = new Random();
            int index = random.Next(population.PopulationSize);

            return population.Individuals[index];
        }

        public override (TPopulation, List<TIndividual>) SelectMultiple(TPopulation population, int selectionSize)
        {
            if (selectionSize > population.PopulationSize) return (default(TPopulation), default(List<TIndividual>));

            Random random = new Random();
            HashSet<int> set = new HashSet<int>();
            List<int> indexes = new List<int>();

            while (indexes.Count < selectionSize)
            {
                int num;

                do { num = random.Next(population.PopulationSize); } while (set.Contains(num));

                set.Add(num);
                indexes.Add(num);
            }

            TPopulation newPopulation = (TPopulation)population.Copy();
            List<TIndividual> individuals = new List<TIndividual>();
            
            indexes.ForEach(i => { 
                individuals.Add(population.Individuals[i]);
                newPopulation.Individuals.RemoveAt(i);
            });

            return (population, individuals);
        }
    }
}
