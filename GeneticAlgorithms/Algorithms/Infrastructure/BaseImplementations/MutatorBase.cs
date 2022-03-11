using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class MutatorBase<TIndividual> : IMutator<TIndividual> where TIndividual : IIndividual
    {
        public abstract TIndividual Mutate(TIndividual individual);
    }
}
