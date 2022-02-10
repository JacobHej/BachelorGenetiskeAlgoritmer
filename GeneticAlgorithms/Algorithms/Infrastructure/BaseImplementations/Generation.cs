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
        public readonly Dictionary<IIndividual, int> IndividualFitness;
        public readonly int HighestFitness;
        public readonly TIndividual HighestFitnessIndividual;
        public readonly int TotalFitness;

        public Generation(IPopulation<TIndividual> population, IFitnessCalculator<TIndividual> fitnessCalculator)
        {
            this.population = population;
            IndividualFitness = new Dictionary<IIndividual, int>();
            
            foreach (TIndividual individual in this.population.Individuals)
            {
                int fitness = fitnessCalculator.CalculateFitness(individual);
                IndividualFitness.Add(individual, fitness);
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
