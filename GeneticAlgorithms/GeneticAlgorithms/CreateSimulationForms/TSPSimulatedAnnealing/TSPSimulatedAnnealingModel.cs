using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Algorithms.SimulatedAnnealing;
using Algorithms.TravelingSalesPerson;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.TSPSimulatedAnnealing
{
    public class TSPSimulatedAnnealingModel : SimpleTSPAlgorithmModel
    {
        public void createAlgorithm(CoordinateGraph graph, MutatorBase<TravelingSalesPersonIndividual> mutator, double initialTemp, double alpha)
        {

            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() => {
                return new SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>(
                    mutator,
                    new TravelingSalesPersonFitnessCalculator(),
                    new ExpOneOverTCooldownFunction(),
                    new AlphaTemperatureFunction(initialTemp, alpha),
                    new LoggerBase<TravelingSalesPersonIndividual>(),
                    new TravelingSalesPersonIndividual(graph)
                );

            });
            this.graph = graph;
            algorithm = algorithmFactory();
        }
    }
}
