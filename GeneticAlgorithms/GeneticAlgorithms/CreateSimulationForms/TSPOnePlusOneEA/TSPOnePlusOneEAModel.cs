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

        public void createAlgorithm(CoordinateGraph graph)
        {
            if (graph == null)
            {
                return;
            }
            //algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            //{
            //    return new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
            //        new PoissonTwoOptMutator(2),
            //        new TravelingSalesPersonFitnessCalculator(),
            //        new LoggerBase<TravelingSalesPersonIndividual>(),
            //        new TravelingSalesPersonIndividual(graph)
            //    );

            //});

            //algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            //{
            //    return new SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>(
            //        new PoissonTwoOptMutator(2),
            //        new TravelingSalesPersonFitnessCalculator(),
            //        new ExpOneOverTCooldownFunction(),
            //        new AlphaTemperatureFunction(1, 0.9),
            //        new LoggerBase<TravelingSalesPersonIndividual>(),
            //        new TravelingSalesPersonIndividual(graph)
            //    );

            //});

            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            {
                return new RankBasedACOAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
                    new TravelingSalesPersonFitnessCalculator(),
                    new TSPPheramoneConstructor(),
                    new SelectXBestSelector<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
                        new TravelingSalesPersonFitnessCalculator()),
                    new TSPAntConstructor(graph),
                    new LoggerBase<TravelingSalesPersonIndividual>(),
                    10, 5);

            });

            this.graph = graph;
            algorithm = algorithmFactory();
        }
    }
}
