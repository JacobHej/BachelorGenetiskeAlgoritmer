using Algorithms.ACO;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.OnePlusOneEA;
using Algorithms.TravelingSalesPerson;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.TSPMMAS
{
    public class TSPMMASModel : SimpleTSPAlgorithmModel
    {

        public void createAlgorithm(CoordinateGraph graph, double alpha, double beta, double p, double min, double max, double initialPheromone)
        {
            if (graph == null)
            {
                return;
            }


            var fitnessCalc = new TravelingSalesPersonFitnessCalculator();
            var pherCon = new MinMaxTSPPheramoneConstructor(p, fitnessCalc, min, max);
            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            {
                return new MMASAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
                    fitnessCalc,
                    pherCon,
                    new TSPAntConstructor(graph, alpha, beta),
                    new LoggerBase<TravelingSalesPersonIndividual>(),
                    pherCon.InitializePheromones(graph, initialPheromone));
            });

            this.graph = graph;
            algorithm = algorithmFactory();
        }
    }
}
