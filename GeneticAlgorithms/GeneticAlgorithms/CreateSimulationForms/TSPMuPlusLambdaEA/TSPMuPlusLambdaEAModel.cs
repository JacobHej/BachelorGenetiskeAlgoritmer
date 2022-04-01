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

        public void createAlgorithm(CoordinateGraph graph, MutatorBase<TravelingSalesPersonIndividual> mutator,  int mu = 10, int lambda = 5, double crossChance = 50)
        {
            if (graph == null)
            {
                return;
            }
            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            {
                return new MuPlusLambdaEaAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
                                        new PartiallyMatchedCrossover(),
                                        mutator,
                                        new TravelingSalesPersonFitnessCalculator(),
                                        new RandomSelector<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(),
                                        new LoggerBase<TravelingSalesPersonIndividual>(),
                                        new ReplaceWorstReplacer<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(),
                                        new TravelingSalesPersonPopulation(mu, graph),
                                        lambda,
                                    crossChance);
            });

            this.graph = graph;
            algorithm = algorithmFactory();
        }
    }
}
