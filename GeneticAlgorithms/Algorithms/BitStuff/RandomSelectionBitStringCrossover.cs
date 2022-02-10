using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class RandomSelectionBitStringCrossover : CrossoverBase<BitStringIndividual>
    {
        public override BitStringIndividual Crossover(BitStringIndividual individual1, BitStringIndividual individual2)
        {
            BitStringIndividual newBitStringIndividual = new BitStringIndividual(individual1.Solution.Bits.Length);

            Random random = new Random();

            for (int i = 0; i < newBitStringIndividual.Solution.Bits.Length; i++)
            {
                int r = random.Next(1);

                if(r == 0)
                {
                    newBitStringIndividual.Solution.SetBitAt(i, individual1.Solution.Bits[i]);
                }
                else
                {
                    newBitStringIndividual.Solution.SetBitAt(i, individual2.Solution.Bits[i]);
                }
            }

            return newBitStringIndividual;
        }
    }
}
