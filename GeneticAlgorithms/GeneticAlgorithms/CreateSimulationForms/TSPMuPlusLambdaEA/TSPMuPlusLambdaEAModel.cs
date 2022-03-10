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
using Common;

namespace GeneticAlgorithms.CreateSimulationForms.TSPMuPlusLambdaEA
{
    public class TSPMuPlusLambdaEAModel : SimpleTSPAlgorithmModel
    {

        public void createAlgorithm(CoordinateGraph graph, int population = 10, int mu = 5, double crossChance = 50)
        {
            if (graph == null)
            {
                return;
            }
            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() => {
                return new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                    new TwoOptMutator(),
                    new TravelingSalesPersonFitnessCalculator(),
                    new LoggerBase<TravelingSalesPersonIndividual>(),
                    new TravelingSalesPersonIndividual(graph)
                );

            });
            /*
            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            {
                return new MuPlusLambdaEaAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
                    new RandomSelectionTravelingSalespersonCrossover(),
                    new OneOverNXBitStringMutation(),
                    new LeadingOnesFitnessCalculator(),
                    new RandomSelector<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(),
                    new LoggerBase<TravelingSalesPersonIndividual>(),
                    new ReplaceWorstReplacer<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(),
                    new TravelingSalesPersonPopulation(population, graph),
                    mu,
                crossChance);
            });
            */

            this.graph = graph;
            algorithm = algorithmFactory();
        }
    }
}
