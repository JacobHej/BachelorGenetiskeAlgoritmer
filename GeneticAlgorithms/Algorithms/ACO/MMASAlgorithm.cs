using Algorithms.Infrastructure;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.TravelingSalesPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ACO
{
    public class MMASAlgorithm<TPopulation, TIndividual> :
        GeneticAlgorithmBase<TIndividual>
        where TIndividual : IIndividual
        where TPopulation : IPopulation<TIndividual>
    {
        private Dictionary<string, double> Pheramones;
        private TIndividual bestSoFar;
        private int bestSoFarFitness;

        protected IAntConstructor<TPopulation, TIndividual> AntConstructor;
        protected IPheramoneConstructor<TIndividual> PheramoneConstructor;
        protected IFitnessCalculator<TIndividual> FitnessCalculator;

        public List<Dictionary<string, double>> PheramoneHistory;

        public MMASAlgorithm(
            IFitnessCalculator<TIndividual> FitnessCalculator,
            IPheramoneConstructor<TIndividual> pheramoneConstructor,
            IAntConstructor<TPopulation, TIndividual> antConstructor,
            ILogger<TIndividual> logger,
            Dictionary<string, double> initialPheromones)
        {
            this.Logger = logger;
            this.FitnessCalculator = FitnessCalculator;
            this.AntConstructor = antConstructor;
            this.PheramoneConstructor = pheramoneConstructor;
            this.Pheramones = initialPheromones;
            this.PheramoneHistory = new List<Dictionary<string, double>>();

            bestSoFar = AntConstructor.ConstructAnt(Pheramones);
            bestSoFarFitness = FitnessCalculator.CalculateFitness(bestSoFar);

            PheramoneHistory.Add(Pheramones);
            Pheramones = PheramoneConstructor.ConstructPheramones(Pheramones, new List<TIndividual> { bestSoFar });

            PopulationBase<TIndividual> pop = new PopulationBase<TIndividual>(1);
            pop.Individuals.Add(bestSoFar);
            Logger.LogGeneration(pop, FitnessCalculator, Iterations);
        }

        public override ILogger<TIndividual> Logger { get; set; }

        public override Task Evolve()
        {
            return Task.Run(() =>
            {
                lock (this)
                {
                    Iterations++;

                    var newIndividual = AntConstructor.ConstructAnt(Pheramones);

                    int newFitness;
                    if (bestSoFarFitness < (newFitness = FitnessCalculator.CalculateFitness(newIndividual)))
                    {
                        bestSoFarFitness = newFitness;
                        bestSoFar = newIndividual;

                        PopulationBase<TIndividual> pop = new PopulationBase<TIndividual>(1);
                        pop.Individuals.Add(newIndividual);
                        Logger.LogGeneration(pop, FitnessCalculator, Iterations);
                    }

                    PheramoneHistory.Add(Pheramones);
                    Pheramones = PheramoneConstructor.ConstructPheramones(Pheramones, new List<TIndividual> { bestSoFar });
                }
            });
        }
    }
}



