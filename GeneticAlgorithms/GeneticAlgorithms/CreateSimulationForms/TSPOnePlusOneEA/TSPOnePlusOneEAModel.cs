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

            //var fitnessCalculator = new TravelingSalesPersonFitnessCalculator();
            //var pheromoneConstructor = new MinMaxTSPPheramoneConstructor(p, fitnessCalculator, 1d / Math.Pow(graph.Verticies.Length, 2), 1d - (1d / graph.Verticies.Length));

            //algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            //{
            //    return new MMASAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
            //        fitnessCalculator,
            //        pheromoneConstructor,
            //        new TSPAntConstructor(graph, alpha, beta),
            //        new LoggerBase<TravelingSalesPersonIndividual>(),
            //        pheromoneConstructor.InitializePheromones(graph, 1d));

            //});

            this.graph = graph;
            algorithm = algorithmFactory();
        }
    }
}
