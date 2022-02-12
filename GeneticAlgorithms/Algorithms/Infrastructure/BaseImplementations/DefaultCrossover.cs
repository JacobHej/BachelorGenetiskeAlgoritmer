using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public class DefaultCrossover<TIndividual> : ICrossover<TIndividual> where TIndividual : IIndividual
    {
        public TIndividual Crossover(TIndividual individual1, TIndividual individual2)
        {
            throw new NotImplementedException();
        }
    }
}
