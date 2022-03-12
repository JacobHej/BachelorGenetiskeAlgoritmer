using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;

namespace Algorithms.SimulatedAnnealing
{
    public class SimulatedAnnealingAlgorithm<TIndividual> : GeneticAlgorithmBase<TIndividual> where TIndividual : IIndividual
    {
        protected IFitnessCalculator<TIndividual> fitnessCalculator;
        protected IMutator<TIndividual> mutator;
        protected TIndividual individual;
        protected ICooldownFunction cooldownFunction;
        protected ITemperatureFunction temperatureFunction;

        protected Random random;

        public SimulatedAnnealingAlgorithm(
            IMutator<TIndividual> mutator,
            IFitnessCalculator<TIndividual> fitnessCalculator,
            ICooldownFunction cooldownFunction,
            ITemperatureFunction temperatureFunction,
            ILogger<TIndividual> logger,
            TIndividual individual)
        {
            this.mutator = mutator;
            this.fitnessCalculator = fitnessCalculator;
            this.cooldownFunction = cooldownFunction;
            this.temperatureFunction = temperatureFunction;
            this.Logger = logger;
            this.individual = individual;
            this.random = new Random();
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
                    int fitnessY = fitnessCalculator.CalculateFitness(nextIndividual);
                    int fitnessX = fitnessCalculator.CalculateFitness(individual);

                    double T = temperatureFunction.Measure(iterations);
                    int P = (int)Math.Round(Math.Min(1d, cooldownFunction.Evaluate(fitnessX, fitnessY, T)) * 100);

                    if (random.Next(100) < P)
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
