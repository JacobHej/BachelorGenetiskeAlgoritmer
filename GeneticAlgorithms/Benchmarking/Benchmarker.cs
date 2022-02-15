using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System.Diagnostics;

namespace Benchmarking
{
    public static class Benchmarker
    {

        public static async Task<BenchmarkSummary<TIndividual>> Benchmark<TIndividual>(Func<IGeneticAlgorithm<TIndividual>> algorithmFactory, Predicate<IGeneticAlgorithm<TIndividual>> stoppingCriteria, int amountOfIterations = 100, int timeout = 1000000) where TIndividual : IIndividual
        {
            Task<IterationSummary<TIndividual>>[] tasks = new Task<IterationSummary<TIndividual>>[amountOfIterations];

            for (int i = 0; i < amountOfIterations; i++)
            {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
                tasks[i] = Task<IterationSummary<TIndividual>>.Run(async () =>
                {
                    IGeneticAlgorithm<TIndividual> algorithm = algorithmFactory();

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    Task task = algorithm.Optimize(stoppingCriteria);
                    if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                    {
                        stopWatch.Stop();

                        var iteration = new IterationSummary<TIndividual>();
                        iteration.Generations = algorithm.Logger.AmountOfGenerations;
                        iteration.OptimizationTime = stopWatch.ElapsedMilliseconds;
                        iteration.Algorithm = algorithm;

                        return iteration;
                    }
                    else
                    {
                        stopWatch.Stop();
                        return null;
                    }

                });
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
            }

            await Task.WhenAll(tasks);

            var results = tasks.Select(t => t.Result);

            double count = 0;

            double minOpTime = int.MaxValue;
            double maxOpTime = int.MinValue;
            double meanOpTime = 0;

            int minGen = int.MaxValue;
            int maxGen = int.MinValue;
            double meanGen = 0;

            List<IGeneticAlgorithm<TIndividual>> algorithms = new List<IGeneticAlgorithm<TIndividual>>();

            foreach (var result in results)
            {
                if (result == null) continue;

                minOpTime = Math.Min(minOpTime, result.OptimizationTime);
                maxOpTime = Math.Max(maxOpTime, result.OptimizationTime);
                meanOpTime += result.OptimizationTime;

                minGen = Math.Min(minGen, result.Generations);
                maxGen = Math.Max(maxGen, result.Generations);
                meanGen += result.Generations;

                algorithms.Add(result.Algorithm);
                count++;
            }

            return new BenchmarkSummary<TIndividual>(
                meanOpTime / count,
                maxOpTime,
                minOpTime,
                (int)Math.Round(meanGen / count),
                minGen,
                maxGen,
                algorithms);
        }   
        
        private sealed class IterationSummary<TIndividual> where TIndividual : IIndividual
        {
            public int Generations;
            public double OptimizationTime;
            public IGeneticAlgorithm<TIndividual> Algorithm;
        }
    }
}