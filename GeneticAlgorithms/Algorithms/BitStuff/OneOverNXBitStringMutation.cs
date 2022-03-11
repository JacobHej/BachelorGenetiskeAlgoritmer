using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class OneOverNXBitStringMutation : MutatorBase<BitStringIndividual>
    {
        private double factor;

        public OneOverNXBitStringMutation(double factor = 1)
        {
            this.factor = factor;
        }

        public override BitStringIndividual Mutate(BitStringIndividual individual)
        {
            BitStringIndividual newIndividual = (BitStringIndividual) individual.Copy();
            Random random = new Random();
            int N = newIndividual.Solution.Bits.Length;

            for (int i = 0; i < N; i++)
            {
                if(random.Next((int)Math.Round(factor * N)) == 0)
                {
                    newIndividual.Solution.FlipBitAt(i);
                }
            }

            return newIndividual;
        }
    }
}
