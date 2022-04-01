using Algorithms;
using Algorithms.BitStuff;
using Algorithms.TravelingSalesPerson;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.OnePlusOneEA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.SimulatedAnnealing;
using Common;
using Algorithms.ACO;

namespace GeneticAlgorithms.CreateSimulationForms.TSPOnePlusOneEA
{
    public class TSPOnePlusOneEAModel : SimpleTSPAlgorithmModel
    {

        public void createAlgorithm(CoordinateGraph graph, MutatorBase<TravelingSalesPersonIndividual> mutator)
        {
            if (graph == null)
            {
                return;
            }
            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() => {
                return new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                    new PoissonTwoOptMutator(2),
                    new TravelingSalesPersonFitnessCalculator(),
                    new LoggerBase<TravelingSalesPersonIndividual>(),
                    pheromoneConstructor.InitializePheromones(graph, 100),
                    52, 52); ;

            });

            this.graph = graph;
            algorithm = algorithmFactory();
        }
    }
}
