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
        protected IPopulation<TIndividual> population;
        protected ISelector<TPopulation, TIndividual> selector;
        protected int fitness = int.MinValue;
        protected int mu;
        protected int lambda;

        public int maxAttempts = 1000;

        public MuPlusLambdaEaAlgorithm(
            ICrossover<TIndividual> crossover,
            IMutator<TIndividual> mutator,
            IFitnessCalculator<TIndividual> fitnessCalculator,
            IPopulation<TIndividual> population,
            ISelector<TPopulation, TIndividual> selector,
            ILogger<TIndividual> logger,
            int mu,
            int lambda)
        {
            this.crossover = crossover;
            this.mutator = mutator;
            this.fitnessCalculator = fitnessCalculator;
            this.population = population;
            this.selector = selector;
            this.Logger = logger;
            this.mu = mu;
            this.lambda = lambda;
        }

        public override ILogger<TIndividual> Logger { get; set; }

        public override Task Evolve()
        {
            return Task.Run(() =>
            {
                int count = 0;
                object lockobj = new object();

                while (count++ < maxAttempts)
                {
                    IPopulation<TIndividual> newPopulation = new PopulationBase<TIndividual>(population.PopulationSize);

                    

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
            });
        }
    }
}
