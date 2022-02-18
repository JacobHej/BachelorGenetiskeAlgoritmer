using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public class GenericAlgorithmBase<TIndividual> : IGeneticAlgorithm<TIndividual> where TIndividual : IIndividual
    {
        protected ICrossover<TIndividual> crossover;
        protected IMutator<TIndividual> mutator;
        protected IFitnessCalculator<TIndividual> fitnessCalculator;
        protected IPopulation<TIndividual> population;
        protected ISelector<TIndividual> selector;
        protected int fitness = int.MinValue;

        public int maxAttempts = 1000;
        public ILogger<TIndividual> Logger {get; set;}

        private int iterations;
        public int Iterations { get => iterations; set => iterations = value; }

        public GenericAlgorithmBase(
            ICrossover<TIndividual> crossover, 
            IMutator<TIndividual> mutator, 
            IFitnessCalculator<TIndividual> fitnessCalculator, 
            IPopulation<TIndividual> population, 
            ISelector<TIndividual> selector, 
            ILogger<TIndividual> logger)
        {
            this.crossover = crossover;
            this.mutator = mutator;
            this.fitnessCalculator = fitnessCalculator;
            this.population = population;
            this.selector = selector;
            this.Logger = logger;
        }


        public virtual async Task Evolve()
        {
            int count = 0;
            object lockobj = new object();

            while (count++ < maxAttempts)
            {
                IPopulation<TIndividual> newPopulation = new PopulationBase<TIndividual>(population.PopulationSize);

                for (int i = 0; i < newPopulation.PopulationSize; i++)
                {
                    TIndividual individual1 = selector.Select(population);
                    TIndividual individual2 = selector.Select(population);

                    while (individual1.Equals(individual2))
                    {
                        individual1 = selector.Select(population);
                        individual2 = selector.Select(population);
                    }

                    TIndividual newIndividual = crossover.Crossover(individual1, individual2);

                    mutator.Mutate(newIndividual);

                    lock (lockobj)
                    {
                        newPopulation.Individuals.Add(newIndividual);
                    }
                }

                int newFitness = 0;
                newPopulation.Individuals.ForEach(i => newFitness += fitnessCalculator.CalculateFitness(i));

                if (newFitness > fitness)
                {
                    population = newPopulation;
                    fitness = newFitness;
                    Logger.LogGeneration(newPopulation, fitnessCalculator, iterations);
                    return;
                }
            }
        }

        public virtual async Task Optimize(Predicate<IGeneticAlgorithm<TIndividual>> stoppingCriteria)
        {
            while (!stoppingCriteria.Invoke(this))
            {
               await Evolve();
            }
        }
    }
}
