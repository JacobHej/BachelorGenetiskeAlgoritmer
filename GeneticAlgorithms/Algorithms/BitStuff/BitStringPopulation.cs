using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class BitStringPopulation : PopulationBase<BitStringIndividual>
    {
        private int bitStringLength;

        public BitStringPopulation(int populationSize, int bitStringLength) : base(populationSize)
        {
            this.bitStringLength = bitStringLength;

            Individuals = new List<BitStringIndividual>();

            for (int i = 0; i < populationSize; i++)
            {
                Individuals.Add(new BitStringIndividual(bitStringLength));
            }
        }

        public override IPopulation<BitStringIndividual> Copy()
        {
            BitStringPopulation newPopulation = new BitStringPopulation(PopulationSize, bitStringLength);

            this.Individuals.ForEach(i => newPopulation.Individuals.Add((BitStringIndividual)i.Copy()));

            return newPopulation;
        }
    }
}
