using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.OnePlusOneEA
{
    public class OnePlusOneEaAlgorithm <TIndividual> : GeneticAlgorithmBase<TIndividual> where TIndividual : IIndividual
    {
        protected IFitnessCalculator<TIndividual> fitnessCalculator;
        protected IMutator<TIndividual> mutator;
        protected TIndividual individual;

        public OnePlusOneEaAlgorithm(
            IMutator<TIndividual> mutator,
            IFitnessCalculator<TIndividual> fitnessCalculator,
            ILogger<TIndividual> logger,
            TIndividual individual)
        {
            this.mutator = mutator;
            this.fitnessCalculator = fitnessCalculator;
            this.Logger = logger;
            this.individual = individual;
        }

        public override ILogger<TIndividual> Logger { get; set; }

        public override Task Evolve()
        {
            return Task.Run(() =>
            {
                int count = 0;
                int maxAttempts = 100;
                while (count++ < maxAttempts)
                {
                    Iterations++;

                    TIndividual nextIndividual = mutator.Mutate(individual);

                    if (fitnessCalculator.CalculateFitness(nextIndividual) > fitnessCalculator.CalculateFitness(individual))
                    {
                        individual = nextIndividual;

                        PopulationBase<TIndividual> population = new PopulationBase<TIndividual>(1);
                        population.Individuals.Add(individual);
                        Logger.LogGeneration(population, fitnessCalculator, Iterations);

                        return;
                    }
                }
            });
        }
    }
}
