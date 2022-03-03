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
            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() => {
                return new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                    new TwoOptMutator(),
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
