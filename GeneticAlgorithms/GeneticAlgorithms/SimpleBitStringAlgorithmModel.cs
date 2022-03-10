using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualization;

namespace GeneticAlgorithms
{
    public class SimpleBitStringAlgorithmModel
    {
        public TimedEvent EvolutionSimulation;

        public Generation<BitStringIndividual> SelectedGeneration;
        public int SelectedgenerationNumber => algorithm.Logger.History.IndexOf(SelectedGeneration);

        public int population = 10;
        public int bitLength = 100;
        public bool UseProbabilitySelector = false;

        public Func<GeneticAlgorithmBase<BitStringIndividual>> algorithmFactory;
        public GeneticAlgorithmBase<BitStringIndividual> algorithm;


        public async Task Evolve()
        {
            await algorithm.Evolve();
            SelectedGeneration = algorithm.Logger.History.Last();
        }

        public async Task Optimize(int maxItrTotal, int maxItrNoImprovement, int maxFitness)
        {
            int startIterations = algorithm.Iterations;
            await algorithm.Optimize(new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
            {
                
                if (algorithm.Logger?.History.Count < 1)
                {
                    return false;//Just started nothing to stop
                }

                //Max fitness check
                if (algorithm.Logger?.History?.Last()?.HighestFitness >= maxFitness)
                {
                    return true;
                }

                //Max Total iterations check
                if (algorithm.Iterations-startIterations >= maxItrTotal)
                {
                    return true;
                }

                int? highestFitnessSoFar = null;
                int prevIterations = startIterations;
                if (highestFitnessSoFar == null)
                {
                    highestFitnessSoFar = algorithm.Logger?.History?.Last()?.HighestFitness;
                    prevIterations = algorithm.Iterations;
                    return false;//Havent found a highest fitness
                }
                if (algorithm.Logger?.History?.Last()?.HighestFitness > highestFitnessSoFar)
                {
                    
                    prevIterations = algorithm.Iterations;
                    highestFitnessSoFar = algorithm.Logger?.History?.Last()?.HighestFitness;
                    return false;
                }
                if (algorithm.Iterations - prevIterations > maxItrNoImprovement)
                {
                    return true;
                }
                return false;
            }));

            SelectedGeneration = algorithm.Logger.History.Last();
        }

        public void SelectPreviousGeneration()
        {
            int index = algorithm.Logger.History.IndexOf(SelectedGeneration);

            if (index - 1 < 0) return;

            SelectedGeneration = algorithm.Logger.History[index - 1];
        }

        public void SelectNextGeneration()
        {
            int index = algorithm.Logger.History.IndexOf(SelectedGeneration);

            if (index + 1 >= algorithm.Logger.History.Count) return;

            SelectedGeneration = algorithm.Logger.History[index + 1];
        }

        public void restartAlgorithm()
        {
            algorithm = algorithmFactory();
        }

        public List<KeyValuePair<int, int>> GetWeights()
        {
            List<KeyValuePair<int, int>> weights = new List<KeyValuePair<int, int>>();

            List<BitString> bitStrings = 
                algorithm?.Logger?.History?.Select(x => x.HighestFitnessIndividual.Solution)?.ToList() ?? new List<BitString>();

            bitStrings.ForEach(x => weights.Add(GetWeight(x.Bits)));

            return weights;
        }

        private KeyValuePair<int, int> GetWeight(char[] bits)
        {
            int sum = 0;
            int count = 0;

            // count from middle and down
            int startIndex = (bits.Length / 2) - 1;
            for (int i = 0; i <= (bits.Length / 2) - 1; i++)
            {
                bool wasOne = bits[i].Equals('1');
                sum -= wasOne ? startIndex - i  + 1: 0;
                count += wasOne ? 1 : 0;
            }

            // count from middle and up
            startIndex = (bits.Length / 2) + ((bits.Length % 2) == 0 ? 0 : 1);
            for (int i = startIndex; i < bits.Length; i++)
            {
                bool wasOne = bits[i].Equals('1');
                sum += wasOne ? i - startIndex + 1 : 0;
                count += wasOne ? 1 : 0;
            }

            return new KeyValuePair<int, int>(sum, count);
        }
    }
}
