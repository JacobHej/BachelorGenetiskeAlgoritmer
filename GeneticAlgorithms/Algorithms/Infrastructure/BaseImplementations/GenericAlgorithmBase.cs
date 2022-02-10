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
        private ICrossover<TIndividual> crossover;
        private IMutator<TIndividual> mutator;
        private IFitnessCalculator<TIndividual> fitnessCalculator;
        private IPopulation<TIndividual> population;
        private ISelector<TIndividual> selector;
        private int fitness = int.MinValue;

        public int maxAttempts = 1000;
        public ILogger<TIndividual> Logger {get; private set;}

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

                //Task[] tasks = new Task[population.PopulationSize];

                for (int i = 0; i < newPopulation.PopulationSize; i++)
                {
                    //tasks[i] = Task.Run(() =>
                    //{
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
                   // });
                }

                //await Task.WhenAll(tasks);

                int newFitness = 0;
                newPopulation.Individuals.ForEach(i => newFitness += fitnessCalculator.CalculateFitness(i));

                if (newFitness > fitness)
                {
                    population = newPopulation;
                    fitness = newFitness;
                    Logger.LogGeneration(newPopulation, fitnessCalculator);
                    return;
                }
            }
        }

        public virtual void Optimize(Predicate<GenericAlgorithmBase<TIndividual>> stoppingCriteria)
        {
            while (!stoppingCriteria.Invoke(this))
            {
                Evolve();
            }
        }
    }
}
