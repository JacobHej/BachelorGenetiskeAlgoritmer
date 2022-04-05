using Algorithms;
using Algorithms.BitStuff;
using Algorithms.TravelingSalesPerson;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.ACO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using IOParsing;

namespace GeneticAlgorithms.TestModels
{
    public class TSPTestModel : SimpleTSPAlgorithmModel
    {

        public void createAlgorithm()
        {
            ResourceManager.tspFiles.TryGetValue("berlin52", out String[] tspFilePaths);
            CoordinateGraph g;
            if (tspFilePaths.Length <= 1)
            {
                g = Parser.LoadTSPGraph(tspFilePaths[0]);
            }
            else
            {
                g = Parser.LoadTspGraphWithOpt(tspFilePaths[0], tspFilePaths[1]);
            }

            double n = g.Verticies.Length;
            var fitnessCalc = new TravelingSalesPersonFitnessCalculator();
            var pherCon = new TSPPheramoneConstructor(0.5, 100, fitnessCalc);

            algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            {
                return new RankBasedACOAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
                    fitnessCalc,
                    pherCon,
                    new SelectXBestSelector<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(fitnessCalc),
                    new TSPAntConstructor(g, 1, 5),
                    new LoggerBase<TravelingSalesPersonIndividual>(),
                    pherCon.InitializePheromones(g, 1),
                    (int)Math.Round(Math.Log10(n)), 1);
            });

            //var fitnessCalc = new TravelingSalesPersonFitnessCalculator();
            //var pherCon = new MinMaxTSPPheramoneConstructor(0.2, fitnessCalc, 1d / (Math.Pow(n, 2)), 1d - (1d / n));
            //algorithmFactory = new Func<GeneticAlgorithmBase<TravelingSalesPersonIndividual>>(() =>
            //{
            //    return new MMASAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
            //        fitnessCalc,
            //        pherCon,
            //        new TSPAntConstructor(g, 1, 5),
            //        new LoggerBase<TravelingSalesPersonIndividual>(),
            //        pherCon.InitializePheromones(g, 1));
            //});

            this.graph = g;
            algorithm = algorithmFactory();
        }
    }
}
