using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public class Generation<TIndividual> where TIndividual : IIndividual
    {
        public readonly IPopulation<TIndividual> population;
        public readonly Dictionary<Guid, int> IndividualFitness;
        public readonly int HighestFitness;
        public readonly TIndividual HighestFitnessIndividual;
        public readonly int TotalFitness;
        public readonly int Iteration;

        public Generation(IPopulation<TIndividual> population, IFitnessCalculator<TIndividual> fitnessCalculator, int iteration)
        {
            this.Iteration = iteration;
            this.population = population;
            IndividualFitness = new Dictionary<Guid, int>();
            
            foreach (TIndividual individual in this.population.Individuals)
            {
                int fitness = fitnessCalculator.CalculateFitness(individual);
                IndividualFitness.Add(individual.ID, fitness);
                TotalFitness += fitness;

                if(fitness > HighestFitness)
                {
                    HighestFitness = fitness;
                    HighestFitnessIndividual = individual;
                }
            }
        }
    }
}
