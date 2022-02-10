using Algorithms.Infrastructure.BaseImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class BitStringPopulation : PopulationBase<BitStringIndividual>
    {
        public BitStringPopulation(int populationSize, int bitStringLength) : base(populationSize)
        {
            Individuals = new List<BitStringIndividual>();

            for (int i = 0; i < populationSize; i++)
            {
                Individuals.Add(new BitStringIndividual(bitStringLength));
            }
        }
    }
}
