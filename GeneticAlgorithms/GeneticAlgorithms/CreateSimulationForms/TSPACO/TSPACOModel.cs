using Algorithms.ACO;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.OnePlusOneEA;
using Algorithms.TravelingSalesPerson;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.TSPACO
{
    public class TSPACOModel : SimpleTSPAlgorithmModel
    {

        public void createAlgorithm(CoordinateGraph graph, double pheromoneStrength, double lengthStrength, double evaporateFactor, double pheromonePlacementFactor, double initialPheromone, int populationSize, int xNrOfRanks)
        {
            if (graph == null)
            {
                return;
            }


            var fitnessCalculator = new TravelingSalesPersonFitnessCalculator();
            var pheromoneConstructor = new TSPPheramoneConstructor(evaporateFactor, pheromonePlacementFactor, fitnessCalculator);

            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            {
                return new RankBasedACOAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
                    fitnessCalculator,
                    pheromoneConstructor,
                    new SelectXBestSelector<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
                        new TravelingSalesPersonFitnessCalculator()),
                    new TSPAntConstructor(graph, pheromoneStrength, lengthStrength),
                    new LoggerBase<TravelingSalesPersonIndividual>(),
                    pheromoneConstructor.InitializePheromones(graph, initialPheromone),
                    populationSize,
                    xNrOfRanks
                );
            });

            this.graph = graph;
            algorithm = algorithmFactory();
        }
    }
}
