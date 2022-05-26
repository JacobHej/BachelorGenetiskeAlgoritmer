using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System.Diagnostics;

namespace Benchmarking
{
    public static class Benchmarker
    {

        public static async Task<BenchmarkSummary<TIndividual>> BenchmarkParallelAsync<TIndividual>(
            Func<IGeneticAlgorithm<TIndividual>> algorithmFactory,
            Predicate<IGeneticAlgorithm<TIndividual>> stoppingCriteria,
            int amountOfTests = 100, int testTimeout = int.MaxValue)
            where TIndividual : IIndividual
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            Predicate<IGeneticAlgorithm<TIndividual>> timedStoppingCriteria =
                (algorithm) => { return stoppingCriteria(algorithm) || cancellationToken.IsCancellationRequested; };

            Task<BenchmarkSummary<TIndividual>.IterationSummary<TIndividual>>[] tasks 
                = new Task<BenchmarkSummary<TIndividual>.IterationSummary<TIndividual>>[amountOfTests];

            for (int i = 0; i < amountOfTests; i++)
            {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
                tasks[i] = Task<BenchmarkSummary<TIndividual>.IterationSummary<TIndividual>>.Run(async () =>
                {
                    IGeneticAlgorithm<TIndividual> algorithm = algorithmFactory();
                    BenchmarkSummary<TIndividual>.IterationSummary<TIndividual> iteration 
                        = new BenchmarkSummary<TIndividual>.IterationSummary<TIndividual>();

                    await algorithm.Optimize(timedStoppingCriteria);

                    iteration.Generations = algorithm.Logger.AmountOfGenerations;
                    iteration.OptimizationTime = int.MaxValue; // ignore individual op times for parallel run
                    iteration.Algorithm = algorithm;

                    return iteration;
                });
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
            }
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Task task;
            if (await Task.WhenAny(task = Task.WhenAll(tasks), Task.Delay(testTimeout)) != task)
                return null;

            stopWatch.Stop();

            var results = tasks.Select(t => t.Result);

            double count = 0;

            double minOpTime = int.MaxValue;
            double maxOpTime = int.MinValue;

            int minGen = int.MaxValue;
            int maxGen = int.MinValue;
            double meanGen = 0;

            int minItr = int.MaxValue;
            int maxItr = int.MinValue;
            double meanItr = 0;

            foreach (var result in results)
            {
                if (result == null) continue;
                minGen = Math.Min(minGen, result.Generations);
                maxGen = Math.Max(maxGen, result.Generations);
                meanGen += result.Generations;

                minItr = Math.Min(minItr, result.Algorithm.Iterations);
                maxItr = Math.Max(maxItr, result.Algorithm.Iterations);
                meanItr += result.Algorithm.Iterations;
                count++;
            }

            return new BenchmarkSummary<TIndividual>(
                stopWatch.ElapsedMilliseconds / count,
                maxOpTime,
                minOpTime,
                (int)Math.Round(meanGen / count),
                minGen,
                maxGen,
                (int)Math.Round(meanItr / count),
                minItr,
                maxItr,
                results.ToList());
        }

        public static async Task<BenchmarkSummary<TIndividual>> BenchmarkSynchronousAsync<TIndividual>(
           Func<IGeneticAlgorithm<TIndividual>> algorithmFactory,
           Predicate<IGeneticAlgorithm<TIndividual>> stoppingCriteria,
           int amountOfTests = 100, int testTimeout = int.MaxValue)
           where TIndividual : IIndividual
        {
            List<BenchmarkSummary<TIndividual>.IterationSummary<TIndividual>> summeries 
                = new List<BenchmarkSummary<TIndividual>.IterationSummary<TIndividual>>();

            for (int i = 0; i < amountOfTests; i++)
            {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
                IGeneticAlgorithm<TIndividual> algorithm = algorithmFactory();
                BenchmarkSummary<TIndividual>.IterationSummary<TIndividual> iteration 
                    = new BenchmarkSummary<TIndividual>.IterationSummary<TIndividual>();

                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellationTokenSource.Token;
                Predicate<IGeneticAlgorithm<TIndividual>> timedStoppingCriteria =
                    (algorithm) => { return stoppingCriteria(algorithm) || cancellationToken.IsCancellationRequested; };

                Stopwatch stopWatch = new Stopwatch();

                algorithm.Logger.AttachOnLogGenerationEvent(
                    (sender, generation) => iteration.GenerationTimeStamps.Add(stopWatch.ElapsedMilliseconds));

                stopWatch.Start();

                Task task;
                if (await Task.WhenAny(task = algorithm.Optimize(timedStoppingCriteria), Task.Delay(testTimeout)) != task)
                {
                    cancellationTokenSource.Cancel(); 
                    iteration.TaskTimedOut = true; 
                    await task;
                }

                stopWatch.Stop();

                iteration.Generations = algorithm.Logger.AmountOfGenerations;
                iteration.OptimizationTime = stopWatch.ElapsedMilliseconds;
                iteration.Algorithm = algorithm;

                summeries.Add(iteration);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
            }

            double count = 0;

            double minOpTime = int.MaxValue;
            double maxOpTime = int.MinValue;
            double meanOpTime = 0;

            int minGen = int.MaxValue;
            int maxGen = int.MinValue;
            double meanGen = 0;

            int minItr = int.MaxValue;
            int maxItr = int.MinValue;
            double meanItr = 0;

            foreach (var result in summeries)
            {
                if (result == null) continue;

                minOpTime = Math.Min(minOpTime, result.OptimizationTime);
                maxOpTime = Math.Max(maxOpTime, result.OptimizationTime);
                meanOpTime += result.OptimizationTime;

                minGen = Math.Min(minGen, result.Generations);
                maxGen = Math.Max(maxGen, result.Generations);
                meanGen += result.Generations;

                minItr = Math.Min(minItr, result.Algorithm.Iterations);
                maxItr = Math.Max(maxItr, result.Algorithm.Iterations);
                meanItr += result.Algorithm.Iterations;
                count++;
            }

            return new BenchmarkSummary<TIndividual>(
                meanOpTime / count,
                maxOpTime,
                minOpTime,
                (int)Math.Round(meanGen / count),
                minGen,
                maxGen,
                (int)Math.Round(meanItr / count),
                minItr,
                maxItr,
                summeries);
        }
    }
}