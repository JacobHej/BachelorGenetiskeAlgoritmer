﻿using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.TravelingSalesPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ACO
{
    public class RankBasedACOAlgorithm<TPopulation, TIndividual> : 
        GeneticAlgorithmBase<TIndividual> 
        where TIndividual : IIndividual 
        where TPopulation : IPopulation<TIndividual>
    {
        private Dictionary<string, double> Pheramones;
        private int populationSize;
        private int xBestForPheramones;
        private int bestSoFar = int.MinValue;

        protected IAntConstructor<TPopulation, TIndividual> AntConstructor;
        protected ISelector<TPopulation, TIndividual> Selector;
        protected IPheramoneConstructor<TIndividual> PheramoneConstructor;
        protected IFitnessCalculator<TIndividual> FitnessCalculator;

        public List<Dictionary<string, double>> PheramoneHistory;

        public RankBasedACOAlgorithm(
            IFitnessCalculator<TIndividual> FitnessCalculator,
            IPheramoneConstructor<TIndividual> pheramoneConstructor,
            ISelector<TPopulation, TIndividual> selector,
            IAntConstructor<TPopulation, TIndividual> antConstructor, 
            ILogger<TIndividual> logger,
            Dictionary<string, double> initialPheromones,
            int populationSize, int xBestForPheramones)
        {
            this.Logger = logger;
            this.FitnessCalculator = FitnessCalculator;
            this.AntConstructor = antConstructor;
            this.Selector = selector;
            this.PheramoneConstructor = pheramoneConstructor;
            this.Pheramones = initialPheromones;
            this.PheramoneHistory = new List<Dictionary<string, double>>();
            this.populationSize = populationSize;
            this.xBestForPheramones = xBestForPheramones;
        }

        public override ILogger<TIndividual> Logger { get; set; }

        public override Task Evolve()
        {
            return Task.Run(() =>
            {
                lock (this)
                {
                    Iterations++;

                    TPopulation newPopulation = AntConstructor.ConstructAnst(Pheramones, populationSize);

                    (TPopulation rest, List<TIndividual> selectedIndividuals) = Selector.SelectMultiple(newPopulation, xBestForPheramones);

                    PheramoneHistory.Add(Pheramones);
                    Pheramones = PheramoneConstructor.ConstructPheramones(Pheramones, selectedIndividuals);


                    TIndividual bestIndividual = default(TIndividual);
                    bool flag = false;
                    newPopulation.Individuals.ForEach(individual =>
                    {
                        int fitness = FitnessCalculator.CalculateFitness(individual);
                        if (bestSoFar < fitness)
                        { 
                            bestIndividual = individual; 
                            flag = true;
                            bestSoFar = fitness; 
                        }
                    });

                    if (flag)
                    {
                        PopulationBase<TIndividual> pop = new PopulationBase<TIndividual>(1);
                        pop.Individuals.Add(bestIndividual);
                        Logger.LogGeneration(pop, FitnessCalculator, Iterations);
                    }
                }
                //Logger.LogGeneration(newPopulation, FitnessCalculator, Iterations);               
            });
        }
    }
}