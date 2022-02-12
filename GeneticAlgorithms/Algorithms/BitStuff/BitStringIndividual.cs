using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BitStringIndividual : IndividualBase
    {
        public BitString Solution { get; protected set; }

        public BitStringIndividual(int size)
        {
            Solution = new BitString(size);
        }

        public BitStringIndividual(BitString sol)
        {
            Solution = sol;
        }

        public override IIndividual Copy()
        {
            return new BitStringIndividual(Solution.Copy());
        }
    }
}
