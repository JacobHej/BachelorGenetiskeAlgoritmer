using Algorithms;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Algorithms.TravelingSalesPerson;
using Benchmarking;
using Common;
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

        public async Task BenchmarkOnePLusOneEA(CoordinateGraph g)
        {
            var bitStringLength = 100;
            var maxIterations = 10000;
            var maxFitnessValue = 100;
            var tests = 100;

            await Benchmark_OnePlusOneEA_OneMax_OneOverN(bitStringLength, maxIterations, maxFitnessValue, tests);
            //await Benchmark_OnePlusOneEA_OneMax_OneOverNX(new double[] { 0.3, 0.4, 0.5, 0.6, 0.7, 0.8 }, bitStringLength, maxIterations, maxFitnessValue, tests);

            //await BenchMark_OnePlusOneEA_BinVal_OneOverN(bitStringLength, maxIterations, maxFitnessValue, tests);
            //await Benchmark_OnePlusOneEA_BinVal_OneOverNX(new double[] { 0.3, 0.4, 0.5, 0.6, 0.7, 0.8 }, bitStringLength, maxIterations, maxFitnessValue, tests);

            //await BenchMark_OnePlusOneEA_LeadingOnes_OneOverN(bitStringLength, maxIterations, maxFitnessValue, tests);
            //await Benchmark_OnePlusOneEA_LeadingOnes_OneOverNX(new double[] { 0.3, 0.4, 0.5, 0.6, 0.7, 0.8 }, bitStringLength, maxIterations, maxFitnessValue, tests);

            //await BenchMark_OnePlusOneEA_TSP_TwoOpt(g, 50000, 0, 10);
            //await BenchMark_OnePlusOneEA_TSP_PoissonTwoOpt(new double[] { 1, 1.25, 1.5, 1.75, 2, 2.25, 2.5, 2.75}, g, 50000, 0, 10);
        }

        public async Task Benchmark_OnePlusOneEA_OneMax_OneOverN(int bitStringLength, int maxIterations, int minFitnessValue, int tests)
        {
            BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
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
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkParallelAsync<BitStringIndividual>(
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

        private async Task BenchMark_OnePlusOneEA_BinVal_OneOverN(int bitStringLength, int maxIterations, int minFitnessValue, int tests)
        {
            BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkParallelAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(),
                        new BinValFitnessCalculator(),
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
                $"(1+1)EA with one over n mutation and bitstring length {bitStringLength} on BinVal",
                nameof(BenchMark_OnePlusOneEA_BinVal_OneOverN));
        }

        public async Task Benchmark_OnePlusOneEA_BinVal_OneOverNX(double[] factors, int bitStringLength, int maxIterations, int minFitnessValue, int tests)
        {
            for (int i = 0; i < factors.Length; i++)
            {
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkParallelAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(factors[i]),
                        new BinValFitnessCalculator(),
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
                    $"(1+1)EA with one over n*{factors[i]} mutation and bitstring length {bitStringLength} on BinVal",
                    $"{nameof(Benchmark_OnePlusOneEA_BinVal_OneOverNX)}_Factor{factors[i]}");
            }
        }

        private async Task BenchMark_OnePlusOneEA_LeadingOnes_OneOverN(int bitStringLength, int maxIterations, int minFitnessValue, int tests)
        {
            BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkParallelAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(),
                        new LeadingOnesFitnessCalculator(),
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
                $"(1+1)EA with one over n mutation and bitstring length {bitStringLength} on LeadingOnes",
                nameof(BenchMark_OnePlusOneEA_LeadingOnes_OneOverN));
        }

        public async Task Benchmark_OnePlusOneEA_LeadingOnes_OneOverNX(double[] factors, int bitStringLength, int maxIterations, int minFitnessValue, int tests)
        {
            for (int i = 0; i < factors.Length; i++)
            {
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkParallelAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(factors[i]),
                        new LeadingOnesFitnessCalculator(),
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
                    $"(1+1)EA with one over n*{factors[i]} mutation and bitstring length {bitStringLength} on LeadingOnes",
                    $"{nameof(Benchmark_OnePlusOneEA_LeadingOnes_OneOverNX)}_Factor{factors[i]}");
            }
        }

        private async Task BenchMark_OnePlusOneEA_TSP_TwoOpt(CoordinateGraph graph, int maxIterations, int minFitnessValue, int tests)
        {
            BenchmarkSummary<TravelingSalesPersonIndividual> result = await Benchmarker.BenchmarkParallelAsync<TravelingSalesPersonIndividual>(
                new Func<OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                        new TwoOptMutator(),
                        new TravelingSalesPersonFitnessCalculator(),
                        new LoggerBase<TravelingSalesPersonIndividual>(),
                        new TravelingSalesPersonIndividual(graph))),
                new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                {
                    if (algorithm.Iterations > maxIterations) return true;
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= int.MaxValue - minFitnessValue;
                }),
                tests
                );

            await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                result,
                $"(1+1)EA with two opt mutation on TSP",
                nameof(BenchMark_OnePlusOneEA_TSP_TwoOpt));
        }

        private async Task BenchMark_OnePlusOneEA_TSP_PoissonTwoOpt(double[] lambda, CoordinateGraph graph, int maxIterations, int minFitnessValue, int tests)
        {
            for (int i = 0; i < lambda.Length; i++)
            {
                BenchmarkSummary<TravelingSalesPersonIndividual> result = await Benchmarker.BenchmarkParallelAsync<TravelingSalesPersonIndividual>(
                 new Func<OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>>(() =>
                     new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                         new TwoOptMutator(),
                         new TravelingSalesPersonFitnessCalculator(),
                         new LoggerBase<TravelingSalesPersonIndividual>(),
                         new TravelingSalesPersonIndividual(graph))),
                 new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                 {
                     if (algorithm.Iterations > maxIterations) return true;
                     if (algorithm.Logger?.History.Count < 1) return false;
                     return algorithm?.Logger?.History?.Last()?.HighestFitness >= int.MaxValue - minFitnessValue;
                 }),
                 tests
                 );

                await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                    result,
                    $"(1+1)EA with poisson two opt mutation on TSP",
                    $"{nameof(BenchMark_OnePlusOneEA_TSP_PoissonTwoOpt)}_Lambda{lambda[i]}");
            }
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
