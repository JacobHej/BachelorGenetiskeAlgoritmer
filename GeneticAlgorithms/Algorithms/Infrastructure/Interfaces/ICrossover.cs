using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface ICrossover<TIndividual> where TIndividual : IIndividual
    {
        public TIndividual Crossover(TIndividual individual1, TIndividual individual2);
    }
}
