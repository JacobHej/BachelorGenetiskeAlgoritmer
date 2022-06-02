using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.OnePlusOneEA
{
    public class MuPlusLambdaEaAlgorithm <TPopulation, TIndividual> : 
        GeneticAlgorithmBase<TIndividual> 
        where TPopulation : IPopulation<TIndividual>
        where TIndividual : IIndividual
    {
        protected ICrossover<TIndividual> crossover;
        protected IMutator<TIndividual> mutator;
        protected IFitnessCalculator<TIndividual> fitnessCalculator;
        protected ISelector<TPopulation, TIndividual> selector;
        protected IReplacer<TPopulation, TIndividual> replacer;

        protected TPopulation population;

        protected int fitness = int.MinValue;

        public int Lambda;
        public int CrossoverProbability;
        public int maxAttempts = 1000;

        public MuPlusLambdaEaAlgorithm(
            ICrossover<TIndividual> crossover,
            IMutator<TIndividual> mutator,
            IFitnessCalculator<TIndividual> fitnessCalculator,
            ISelector<TPopulation, TIndividual> selector,
            ILogger<TIndividual> logger,
            IReplacer<TPopulation, TIndividual> replacer,
            TPopulation population,
            int mu,
            double crossoverProbability)
        {
            this.crossover = crossover;
            this.mutator = mutator;
            this.fitnessCalculator = fitnessCalculator;
            this.population = population;
            this.selector = selector;
            this.Logger = logger;
            this.replacer = replacer;
            this.Lambda = mu;
            this.CrossoverProbability = (int) Math.Round((crossoverProbability * 100) % 100);
        }

        public override ILogger<TIndividual> Logger { get; set; }

        public override Task Evolve()
        {
            return Task.Run(() =>
            {
                int count = 0;

                while (count++ < maxAttempts)
                {
                    Iterations++;

                    List<TIndividual> newIndividuals = new List<TIndividual>();
                    Random random = new Random();

                    for (int i = 0; i < Lambda; i++)
                    {
                        TIndividual newIndividual;

                        if(random.Next(100) < CrossoverProbability)
                        {
                            TIndividual individual1 = selector.Select(population);
                            TIndividual individual2 = selector.Select(population);

                            while (individual1.Equals(individual2))
                            {
                                individual1 = selector.Select(population);
                                individual2 = selector.Select(population);
                            }

                            newIndividual = crossover.Crossover(individual1, individual2);
                        }
                        else
                        {
                            newIndividual = selector.Select(population);
                            newIndividual = mutator.Mutate(newIndividual);
                        }                        

                        newIndividuals.Add(newIndividual);
                    }

                    TPopulation newPopulation = replacer.Replace(population, newIndividuals.Concat(population.Individuals).ToList(), fitnessCalculator);

                    int newFitness = 0;
                    newPopulation.Individuals.ForEach(i => newFitness += fitnessCalculator.CalculateFitness(i));

                    if (newFitness > fitness)
                    {
                        population = newPopulation;
                        fitness = newFitness;
                        Logger.LogGeneration(newPopulation, fitnessCalculator, iterations);
                        return;
                    }
                    else if(newFitness<fitness)
                    {
                        int illebjerg = 10;
                    }
                }
            });
        }
    }
}
