using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public class GenericAlgorithmBase : IGeneticAlgorithm
    {
        private ICrossover crossover;
        private IMutator mutator;
        private IFitnessCalculator fitnessCalculator;
        private IPopulation population;
        
        public GenericAlgorithmBase(ICrossover crossover, IMutator mutator, IFitnessCalculator fitnessCalculator, IPopulation population)
        {
            this.crossover = crossover;
            this.mutator = mutator;
            this.fitnessCalculator = fitnessCalculator;
            this.population = population;
        }

        public void Evolve()
        {
            throw new NotImplementedException();
        }

        public void Optimize()
        {
            throw new NotImplementedException();
        }
    }
}
