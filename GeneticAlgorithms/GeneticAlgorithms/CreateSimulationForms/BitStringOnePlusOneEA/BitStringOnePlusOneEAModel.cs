﻿using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
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
            algorithm = algorithmFactory();
        }
    }
}