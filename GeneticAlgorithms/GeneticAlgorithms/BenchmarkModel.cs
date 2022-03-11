using Algorithms;
using Algorithms.Benchmark;
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

        #region MuPlusLambda
        public async Task MuPlusLambdaRegressionToOnePLusOneEATSP(CoordinateGraph g)
        {
            BenchmarkSummary<TravelingSalesPersonIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                            new Func<MuPlusLambdaEaAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>>(() =>
                                new MuPlusLambdaEaAlgorithm<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(
                                    new PartiallyMatchedCrossover(),
                                    new PoissonTwoOptMutator(2),
                                    new TravelingSalesPersonFitnessCalculator(),
                                    new RandomSelector<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(),
                                    new BenchmarkLogger<TravelingSalesPersonIndividual>(),
                                    new ReplaceWorstReplacer<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>(),
                                    new TravelingSalesPersonPopulation(1, g),
                                    1,
                                    0
                                )
                                ),
                            new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                            {
                                return algorithm.Iterations > 50000;
                            }),
                            10
                            );
        }

        public async Task MuPlusLambdaRegressionToOnePLusOneEAOneMax(int length)
        {
            BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkParallelAsync<BitStringIndividual>(
                            new Func<MuPlusLambdaEaAlgorithm<BitStringPopulation, BitStringIndividual>>(() =>
                                new MuPlusLambdaEaAlgorithm<BitStringPopulation, BitStringIndividual>(
                                    new RandomSelectionBitStringCrossover(),
                                    new OneOverNXBitStringMutation(),
                                    new OneMaxFitnessCalculator(),
                                    new RandomSelector<BitStringPopulation, BitStringIndividual>(),
                                    new BenchmarkLogger<BitStringIndividual>(),
                                    new ReplaceWorstReplacer<BitStringPopulation, BitStringIndividual>(),
                                    new BitStringPopulation(1, length),
                                    1,
                                    0)),
                            new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                            {
                                if (algorithm.Logger?.History.Count < 1) return false;
                                return algorithm?.Logger?.History?.Last()?.HighestFitness >= length;
                            }),
                            10
                            );
        }

        public async Task Benchmark_MuPlusLambdaEA_OneMax_OneOverN(int bitStringLength, int maxIterations, int minFitnessValue, int tests)
        {

            var populations = new List<int> { 2 };
            var crossProbs = new List<double> { 0.3 };
            List<BenchmarkSummary<BitStringIndividual>> results = new List<BenchmarkSummary<BitStringIndividual>>();
            foreach (int population in populations)
            {
                foreach (double cross in crossProbs)
                {
                    for (int mu = 1; mu < population; mu += 2)
                    {
                        BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkParallelAsync<BitStringIndividual>(
                            new Func<MuPlusLambdaEaAlgorithm<BitStringPopulation, BitStringIndividual>>(() =>
                                new MuPlusLambdaEaAlgorithm<BitStringPopulation, BitStringIndividual>(
                                    new RandomSelectionBitStringCrossover(),
                                    new OneOverNXBitStringMutation(),
                                    new OneMaxSquaredFitnessCalculator(),
                                    new RandomSelector<BitStringPopulation, BitStringIndividual>(),
                                    new BenchmarkLogger<BitStringIndividual>(),
                                    new ReplaceWorstReplacer<BitStringPopulation, BitStringIndividual>(),
                                    new BitStringPopulation(population, bitStringLength),
                                    mu,
                                    cross)),
                            new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                            {
                                if (algorithm.Iterations > maxIterations) return true;
                                if (algorithm.Logger?.History.Count < 1) return false;
                                return algorithm?.Logger?.History?.Last()?.HighestFitness >= minFitnessValue;
                            }),
                            tests
                            );

                        results.Add(result);
                    }
                }
            }

            List<TestRes> testress = new List<TestRes>();

            foreach (var result in results)
            {
                var algo = (MuPlusLambdaEaAlgorithm<BitStringPopulation, BitStringIndividual>)result.Algorithms.FirstOrDefault();
                testress.Add(
                    new TestRes
                    {
                        mu = algo.Mu,
                        crossProb = algo.CrossoverProbability,
                        meanOpTime = result.MeanOptimizationTime,
                        iterations = (int)Math.Round((double)result.Algorithms.Select(a => a.Iterations).Sum() / (double)result.Algorithms.Count()),
                        highestFit = algo.Logger?.History.Last()?.HighestFitness,
                        populationSize = algo.Logger.History.Last()?.population.Individuals.Count()
                    });
            }

            TestRes best = testress.FirstOrDefault();

            testress.ForEach(t =>
            {
                if (t.iterations < best.iterations)
                {
                    best = t;
                }
            });
        }

        private sealed class TestRes
        {
            public int mu;
            public double crossProb;
            public double meanOpTime;
            public int iterations;
            public int? highestFit;
            public int? populationSize;
        }

        #endregion

        #region OnePlusOneEA

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
                     return algorithm?.Logger?.History?.Last()?.HighestFitness >= minFitnessValue;
                 }),
                 tests
                 );

                await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                    result,
                    $"(1+1)EA with poisson two opt mutation on TSP",
                    $"{nameof(BenchMark_OnePlusOneEA_TSP_PoissonTwoOpt)}_Lambda{lambda[i]}");
            }
        }

        #endregion

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
