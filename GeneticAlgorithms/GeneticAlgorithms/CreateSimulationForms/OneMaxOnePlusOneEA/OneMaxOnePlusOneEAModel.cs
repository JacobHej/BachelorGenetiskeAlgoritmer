using Algorithms;
using Algorithms.ACO;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.OnePlusOneEA;
using Algorithms.TravelingSalesPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.OneMaxOnePlusOneEA
{
    public class OneMaxOnePlusOneEAModel : SimpleBitStringAlgorithmModel
    {
        public void createAlgorithm(int bitLengthIn)
        {
            population = 1;
            bitLength = bitLengthIn;

            //algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            //{
            //    return new OnePlusOneEaAlgorithm<BitStringIndividual>(
            //        new OneOverNXBitStringMutation(),
            //        new OneMaxFitnessCalculator(),
            //        new LoggerBase<BitStringIndividual>(),
            //        new BitStringIndividual(bitLength)
            //    );
            //});

            var p = 1d;

            var fitnessCalculator = new OneMaxFitnessCalculator();
            var pheromoneConstructor = new BitStringPheramoneConstructor(p, 2000, fitnessCalculator);

            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new RankBasedACOAlgorithm<BitStringPopulation, BitStringIndividual>(
                    fitnessCalculator,
                    pheromoneConstructor,
                    new SelectXBestSelector<BitStringPopulation, BitStringIndividual>(
                        fitnessCalculator),
                    new BitStringAntConstructor(bitLength),
                    new LoggerBase<BitStringIndividual>(),
                    pheromoneConstructor.InitializePheromones(bitLength, 1),
                    bitLength, bitLength); ;

            });

            //var p = 0.2d;
            //var fitnessCalculator = new OneMaxFitnessCalculator();
            //var pheromoneConstructor = new MinMaxBitStringPheramoneConstructor(p, 1d/bitLength, 1d - (1d / bitLength));

            //algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            //{
            //    return new MMASAlgorithm<BitStringPopulation, BitStringIndividual>(
            //        fitnessCalculator,
            //        pheromoneConstructor,
            //        new BitStringAntConstructor(bitLength),
            //        new LoggerBase<BitStringIndividual>(),
            //        pheromoneConstructor.InitializePheromones(bitLength, 1d));

            //});

            algorithm = algorithmFactory();
        }
    }
}
