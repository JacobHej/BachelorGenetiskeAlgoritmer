using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class RandomBitStringSelector : SelectorBase<BitStringIndividual>
    {
        public override BitStringIndividual Select(IPopulation<BitStringIndividual> population)
        {
            Random random = new Random();
            int index = random.Next(population.PopulationSize);

            return population.Individuals[index];
        }
    }
}
