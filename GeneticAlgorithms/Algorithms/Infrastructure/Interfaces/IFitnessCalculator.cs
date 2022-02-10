using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface IFitnessCalculator
    {
        public int CalculateFitness(IPopulation population);
    }
}
