using Algorithms.Infrastructure.Interfaces;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BitStringIndividual : IIndividual
    {
        public BitString Solution { get; }

        public BitStringIndividual(int size)
        {
            Solution = new BitString(size);
        }
    }
}
