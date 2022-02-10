using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface ICrossover
    {
        public IIndividual Crossover(IIndividual individual1, IIndividual individual2);
    }
}
