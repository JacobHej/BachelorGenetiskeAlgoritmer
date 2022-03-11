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

        public BitStringPopulation(List<BitStringIndividual> individuals, int bitStringLength) : base(individuals.Count)
        {
            this.bitStringLength = bitStringLength;
            Individuals = individuals;
        }

        public override IPopulation<BitStringIndividual> Copy() 
            => new BitStringPopulation(Individuals.Select(i => (BitStringIndividual) i.Copy()).ToList(), bitStringLength);
    }
}
