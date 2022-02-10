using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class OneOverNBitStringMutation : MutatorBase<BitStringIndividual>
    {
        public override void Mutate(BitStringIndividual individual)
        {
            Random random = new Random();
            int N = individual.Solution.Bits.Length;

            for (int i = 0; i < N; i++)
            {
                if(random.Next(N) == 0)
                {
                    individual.Solution.FlipBitAt(i);
                }
            }
        }
    }
}
