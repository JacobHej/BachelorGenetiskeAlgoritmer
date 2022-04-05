using Algorithms;
using Algorithms.ACO;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Algorithms.TravelingSalesPerson;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.BitStringACO
{
    public class BitStringACOModel : SimpleBitStringAlgorithmModel
    {

        public void createAlgorithm(IFitnessCalculator<BitStringIndividual> fitnessCalculator, Func<BitStringIndividual> bitStringCreator, double pheromoneStrength, double lengthStrength, double evaporateFactor, double pheromonePlacementFactor, double initialPheromone, int populationSize, int xNrOfRanks)
        {
            if (graph == null)
            {
                return;
            }


            var pheromoneConstructor = new TSPPheramoneConstructor(evaporateFactor, pheromonePlacementFactor, fitnessCalculator);

            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new RankBasedACOAlgorithm<BitStringIndividual, BitStringIndividual>(
                    fitnessCalculator,
                    pheromoneConstructor,
                    new SelectXBestSelector<BitStringIndividual, BitStringIndividual>(
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
