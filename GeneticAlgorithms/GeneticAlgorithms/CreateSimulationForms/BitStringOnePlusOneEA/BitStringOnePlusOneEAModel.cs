using Algorithms;
using Algorithms.ACO;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Algorithms.TravelingSalesPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.BitStringOnePlusOneEA
{
    public class BitStringOnePlusOneEAModel : SimpleBitStringAlgorithmModel
    {
        public void createAlgorithm(IFitnessCalculator<BitStringIndividual> problem, BitStringIndividual bitString)
        {
            population = 1;
            bitLength = bitString.Solution.Bits.Length;
            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new OnePlusOneEaAlgorithm<BitStringIndividual>(
                    new OneOverNXBitStringMutation(),
                    problem,
                    new LoggerBase<BitStringIndividual>(),
                    bitString
                );
            });

            //double n = bitLength;
            //var fitnessCalc = new OneMaxFitnessCalculator();
            //var pherCon = new BitStringPheramoneConstructor(0.995, bitLength, fitnessCalc);//new MinMaxBitStringPheramoneConstructor(1, 1d / n, 1d - (1d / n));

            //algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            //{
            //    return new RankBasedACOAlgorithm<BitStringPopulation, BitStringIndividual>(
            //        fitnessCalc,
            //        pherCon,
            //        new SelectXBestSelector<BitStringPopulation, BitStringIndividual>(fitnessCalc),
            //        new BitStringAntConstructor(bitLength),
            //        new LoggerBase<BitStringIndividual>(),
            //        pherCon.InitializePheromones(bitLength, 1),
            //        (int)Math.Round(Math.Log10(n)) + 5, 1);
            //});

            //var fitnessCalc = new OneMaxFitnessCalculator();
            //var pherCon = new MinMaxBitStringPheramoneConstructor(0.2, 1d / bitLength, 1d - (1d / bitLength));
            //algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            //{
            //    return new MMASAlgorithm<BitStringPopulation, BitStringIndividual>(
            //        fitnessCalc,
            //        pherCon,
            //        new BitStringAntConstructor(bitLength),
            //        new LoggerBase<BitStringIndividual>(),
            //        pherCon.InitializePheromones(bitLength, 1));
            //});

            algorithm = algorithmFactory();
        }
    }
}
