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
        public void createAlgorithm(IFitnessCalculator<BitStringIndividual> problem, Func<BitStringIndividual> bitStringCreator)
        {
            population = 1;
            bitLength = bitStringCreator().Solution.Bits.Length;
            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() =>
            {
                return new OnePlusOneEaAlgorithm<BitStringIndividual>(
                    new OneOverNXBitStringMutation(),
                    problem,
                    new LoggerBase<BitStringIndividual>(),
                    bitStringCreator()
                );
            });

            algorithm = algorithmFactory();
        }
    }
}
