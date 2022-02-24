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
        CoordinateGraph graph = null;
        public void createAlgorithm(int bitLengthIn)
        {
            if (graph == null)
            {
                return;
            }
            algorithm = new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                new TwoOptMutator(),
                new TravelingSalesPersonFitnessCalculator(),
                new LoggerBase<TravelingSalesPersonIndividual>(),
                new TravelingSalesPersonIndividual(graph)
            );
        }
    }
}
