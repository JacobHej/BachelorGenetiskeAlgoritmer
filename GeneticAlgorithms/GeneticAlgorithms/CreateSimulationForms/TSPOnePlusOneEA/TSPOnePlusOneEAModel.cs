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
                    mutator,
                    new TravelingSalesPersonFitnessCalculator(),
                    new LoggerBase<TravelingSalesPersonIndividual>(),
                    new TravelingSalesPersonIndividual(graph)
                    );

            });

            this.graph = graph;
            algorithm = algorithmFactory();
        }
    }
}
