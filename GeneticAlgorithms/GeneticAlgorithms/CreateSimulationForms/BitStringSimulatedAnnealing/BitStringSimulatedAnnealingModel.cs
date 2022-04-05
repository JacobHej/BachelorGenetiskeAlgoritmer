using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Algorithms.SimulatedAnnealing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms.CreateSimulationForms.BitStringSimulatedAnnealing
{
    public class BitStringSimulatedAnnealingModel : SimpleBitStringAlgorithmModel
    {
        public void createAlgorithm(IFitnessCalculator<BitStringIndividual> problem, Func<BitStringIndividual> bitStringCreator, double initialTemp, double alpha)
        {

            population = 1;
            bitLength = bitStringCreator().Solution.Bits.Length;

            algorithmFactory = new Func<GeneticAlgorithmBase<BitStringIndividual>>(() => {
                return new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                    new OneOverNXBitStringMutation(),
                    problem,
                    new ExpOneOverTCooldownFunction(),
                    new AlphaTemperatureFunction(initialTemp, alpha),
                    new LoggerBase<BitStringIndividual>(),
                    bitStringCreator()
                );

            });
            algorithm = algorithmFactory();
        }
    }
}
