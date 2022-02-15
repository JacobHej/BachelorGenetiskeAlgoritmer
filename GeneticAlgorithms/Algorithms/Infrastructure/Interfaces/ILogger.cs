using Algorithms.Infrastructure.BaseImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface ILogger<TIndividual> where TIndividual : IIndividual
    {
        public void LogGeneration(IPopulation<TIndividual> population, IFitnessCalculator<TIndividual> fitnessCalculator) ;

        public List<Generation<TIndividual>> History { get; }
        public int AmountOfGenerations { get; }
    }
}
