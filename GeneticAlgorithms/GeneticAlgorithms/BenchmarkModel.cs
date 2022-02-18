using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Algorithms.TravelingSalesPerson;
using Benchmarking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms
{
    public class BenchmarkModel
    {
        private string path;

        public BenchmarkModel(string path)
        {
            this.path = path;
        }

        public async Task BenchmarkOnePLusOneEA(int range, double interval, int bitStringLength, int maxIterations, int maxFitnessValue, int tests)
        {
            await Benchmark_OnePlusOneEA_OneMax_OneOverN(bitStringLength, maxIterations, maxFitnessValue, tests);
        }

        public async Task Benchmark_OnePlusOneEA_OneMax_OneOverN(int bitStringLength, int maxIterations, int minFitnessValue, int tests)
        {
            BenchmarkSummary<BitStringIndividual> result = await Benchmarker.Benchmark<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(),
                        new OneMaxFitnessCalculator(),
                        new LoggerBase<BitStringIndividual>(),
                        new BitStringIndividual(bitStringLength))),
                new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Iterations > maxIterations) return true;
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= minFitnessValue;
                }),
                tests
                );

            await ParseAndWriteBenchmark<BitStringIndividual>(
                result, 
                $"(1+1)EA with one over n mutation and bitstring length {bitStringLength} on OneMax", 
                nameof(Benchmark_OnePlusOneEA_OneMax_OneOverN) );
        }

        public async Task Benchmark_OnePlusOneEA_OneMax_OneOverNX(double[] factors, int bitStringLength, int maxIterations, int minFitnessValue, int tests)
        {
            for (int i = 0; i < factors.Length; i++)
            {
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.Benchmark<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(factors[i]),
                        new OneMaxFitnessCalculator(),
                        new LoggerBase<BitStringIndividual>(),
                        new BitStringIndividual(bitStringLength))),
                new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Iterations > maxIterations) return true;
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= minFitnessValue;
                }),
                tests
                );

                await ParseAndWriteBenchmark<BitStringIndividual>(
                    result, 
                    $"(1+1)EA with one over n*{factors[i]} mutation and bitstring length {bitStringLength} on OneMax", 
                    $"{nameof(Benchmark_OnePlusOneEA_OneMax_OneOverNX)}_Factor{factors[i]}");
            }
        }        

        private void BenchMark_OnePlusOneEA_BinVal_OneOverN()
        {

        }

        private void BenchMark_OnePlusOneEA_BinVal_OneOverNX(int range, double interval)
        {

        }

        private void BenchMark_OnePlusOneEA_LeadingOnes_OneOverN()
        {

        }

        private void BenchMark_OnePlusOneEA_LeadingOnes_OneOverNX(int range, double interval)
        {

        }

        private void BenchMark_OnePlusOneEA_TSP_TwoOpt()
        {

        }

        private void BenchMark_OnePlusOneEA_TSP_PoissonTwoOpt(int range, double interval)
        {

        }



        private async Task ParseAndWriteBenchmark<TIndividual>(BenchmarkSummary<TIndividual> result, string benchmarkInformation, string name) where TIndividual : IIndividual
        {
            var amountOfGenerations = result.Algorithms.Select(algorithm => algorithm.Logger.AmountOfGenerations);
            var graphsOverIterationPerGeneration = result.Algorithms.Select(
                algorithm => {
                    List<int> numbers = new List<int>();
                    algorithm.Logger.History.ForEach(generation => numbers.Add(generation.Iteration));
                    return numbers;
                });
            var graphsOverHighestFitness = result.Algorithms.Select(
                algorithm => {
                    List<int> numbers = new List<int>();
                    algorithm.Logger.History.ForEach(generation => numbers.Add(generation.HighestFitness));
                    return numbers;
                });
            var allIndividual = result.Algorithms.Select(
                algorithm =>
                {
                    List<string> numbers = new List<string>();
                    algorithm.Logger.History.ForEach(generation => numbers.Add(generation.HighestFitnessIndividual.ToString()));
                    return numbers;
                });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(benchmarkInformation);
            sb.AppendLine();
            sb.AppendLine("---Summery--");
            sb.AppendLine($"Generations Best/Mean/Worst: {result.BestAmountOfGenerations}, {result.MeanAmountOfGenerations}, {result.WorstAmountOfGenerations}");
            sb.AppendLine($"BROKEN OptimizationTime Best/Mean/Worst: {result.BestOptimizationTIme}, {result.MeanOptimizationTime}, {result.WorstOptimizationTIme}");
            sb.AppendLine();

            sb.AppendLine($"---IterationsPerGeneration---");
            int count = 0;
            foreach (var graph in graphsOverIterationPerGeneration)
            {
                sb.AppendLine($"{count++}: {string.Join(", ", graph)}");
            }

            sb.AppendLine();
            sb.AppendLine($"---Generations---");
            sb.AppendLine($"{string.Join(", ", amountOfGenerations)}");

            sb.AppendLine();
            sb.AppendLine($"---GraphsOverHighestFitnessPerGeneration---");
            count = 0;
            foreach (var graph in graphsOverHighestFitness)
            {
                sb.AppendLine($"{count++}: {string.Join(", ", graph)}");
            }

            sb.AppendLine();
            sb.AppendLine($"---Individuals---");
            count = 0;
            foreach (var graph in allIndividual)
            {
                sb.AppendLine($"{count++}: {string.Join(", ", graph)}");
            }

            string s = sb.ToString();

            await WriteToTarget(s, name);
        }

        private async Task WriteToTarget(string text, string folderName)
        {
            await File.WriteAllTextAsync(Path.Combine(path, folderName), text);
        }
    }
}
