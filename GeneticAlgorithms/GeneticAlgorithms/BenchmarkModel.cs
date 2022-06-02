using Algorithms;
using Algorithms.Benchmark;
using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.OnePlusOneEA;
using Algorithms.SimulatedAnnealing;
using Algorithms.TravelingSalesPerson;
using Benchmarking;
using Common;
using IOParsing;
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

        public async Task ErikTest()
        {

            ResourceManager.tspFiles.TryGetValue("berlin52", out String[] tspFilePaths);
            CoordinateGraph g = Parser.LoadTSPGraph(tspFilePaths[0]);

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

        private async Task MuPlusLambdaRegressionToOnePLusOneEATSP(CoordinateGraph g)
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

        private async Task MuPlusLambdaRegressionToOnePLusOneEAOneMax(int length)
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

        private async Task Benchmark_MuPlusLambdaEA_OneMax_OneOverN(int bitStringLength, int maxIterations, int minFitnessValue, int tests)
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
                var algo = (MuPlusLambdaEaAlgorithm<BitStringPopulation, BitStringIndividual>)result.Summaries.FirstOrDefault()?.Algorithm;
                testress.Add(
                    new TestRes
                    {
                        mu = algo.Lambda,
                        crossProb = algo.CrossoverProbability,
                        meanOpTime = result.MeanOptimizationTime,
                        iterations = (int)Math.Round((double)result.Summaries.Select(a => a.Algorithm.Iterations).Sum() / (double)result.Summaries.Count()),
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

        public async Task OnePlusOneEA_OneMax_OneOverN()
        {
            string description = @"Here we run 1+1 EA using mutation probability 1/n on bitstrings 
                                   of different lengths to compare the runtime complexite compared to the 
                                   theoretical expectation. FOr each bit string length 40 tests were run.
                                   The stopping criteria was finding the optimal solution with no timeout";

            int[] bitLengths = { 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 650, 700, 750, 800, 850, 900, 950, 1000 };

            foreach (int bitLength in bitLengths)
            {
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(),
                        new OneMaxFitnessCalculator(),
                        new LoggerBase<BitStringIndividual>(),
                        new BitStringIndividual(bitLength))),
                new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                }),
                40
                );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, description, $"OnePlusOne_OneMax_OneOverN_{bitLength}", bitLength);
            }
        }

        public async Task OnePlusOneEA_OneMax_OneOverNX()
        {
            string description = @"
Here we run 1+1 EA on a bitstring of lngth 100 using mutation probability 1/xn on bitstrings 
of different x values in increments of 0.1 in the interval 0.4..1.6 to compare the runtime complexite compared to the 
theoretical expectation. FOr each values 100 tests were run.
The stopping criteria was finding the optimal solution with no timeout";

            double[] factors = { 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6 };
            int bitLength = 100;

            for (int i = 0; i < factors.Length; i++)
            {
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(factors[i]),
                        new OneMaxFitnessCalculator(),
                        new LoggerBase<BitStringIndividual>(),
                        new BitStringIndividual(bitLength))),
                new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                }),
                100
                );

                await ParseAndWriteBenchmark<BitStringIndividual>(
                    result,
                    description,
                    $"OnePLusOneEQ_OneMax_OneOverNX_{factors[i]}", bitLength);
            }
        }
       
        public async Task OnePlusOneEA_LeadingOnes_OneOverN()
        {
            string description = @"Here we run 1+1 EA using mutation probability 1/n on bitstrings 
                                   of different lengths to compare the runtime complexite compared to the 
                                   theoretical expectation. FOr each bit string length 40 tests were run.
                                   The stopping criteria was finding the optimal solution with no timeout";

            int[] bitLengths = { 100, 125, 150, 175, 200, 225, 250, 275, 300};

            foreach (int bitLength in bitLengths)
            {
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(),
                        new LeadingOnesFitnessCalculator(),
                        new LoggerBase<BitStringIndividual>(),
                        new BitStringIndividual(bitLength))),
                new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                }),
                40
                );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, description, $"OnePlusOne_LeadingOnes_OneOverN_{bitLength}", bitLength);
            }
        }

        public async Task OnePlusOneEA_LeadingOnes_OneOverNX()
        {
            string description = @"
Here we run 1+1 EA on a bitstring of lngth 100 using mutation probability 1/xn on bitstrings 
of different x values in increments of 0.1 in the interval 0.4..1.6 to compare the runtime complexite compared to the 
theoretical expectation. FOr each values 50 tests were run.
The stopping criteria was finding the optimal solution with no timeout";

            double[] factors = { 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6 };
            int bitLength = 100;

            for (int i = 0; i < factors.Length; i++)
            {
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(factors[i]),
                        new LeadingOnesFitnessCalculator(),
                        new LoggerBase<BitStringIndividual>(),
                        new BitStringIndividual(bitLength))),
                new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                }),
                50
                );

                await ParseAndWriteBenchmark<BitStringIndividual>(
                    result,
                    description,
                    $"OnePLusOneEA_LeadingOnes_OneOverNX_{factors[i]}", bitLength);
            }
        }

        public async Task OnePlusOneEA_BinVal_OneOverN()
        {
            string description = @"Here we run 1+1 EA using mutation probability 1/n on bitstrings 
                                   of different lengths to compare the runtime complexite compared to the 
                                   theoretical expectation. FOr each bit string length 40 tests were run.
                                   The stopping criteria was finding the optimal solution with no timeout";

            int[] bitLengths = { 5,10,15,20,25,30 };

            foreach (int bitLength in bitLengths)
            {
                int maxFit = 0;

                for (int i = 0; i < bitLength; i++) maxFit |= (1 << i);

                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(),
                        new BinValFitnessCalculator(),
                        new LoggerBase<BitStringIndividual>(),
                        new BitStringIndividual(bitLength))),
                new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= maxFit;
                }),
                40
                );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, description, $"OnePlusOne_BinVal_OneOverN_{bitLength}", bitLength);
            }
        }

        //not run
        public async Task OnePlusOneEA_BinVal_OneOverNX()
        {
            string description = @"
Here we run 1+1 EA on a bitstring of lngth 30 using mutation probability 1/xn on bitstrings 
of different x values in increments of 0.1 in the interval 0.4..1.6 to compare the runtime complexite compared to the 
theoretical expectation. FOr each values 100 tests were run.
The stopping criteria was finding the optimal solution with no timeout";

            double[] factors = { 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6 };
            int bitLength = 30;

            for (int i = 0; i < factors.Length; i++)
            {
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(factors[i]),
                        new LeadingOnesFitnessCalculator(),
                        new LoggerBase<BitStringIndividual>(),
                        new BitStringIndividual(bitLength))),
                new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                }),
                100
                );

                await ParseAndWriteBenchmark<BitStringIndividual>(
                    result,
                    description,
                    $"OnePLusOneEA_BinVal_OneOverNX_{factors[i]}", bitLength);
            }
        }

        public async Task OnePlusOneEA_TSP_TwoOptPoisson2()
        {
            ResourceManager.tspFiles.TryGetValue("berlin52", out String[] tspFilePaths);
            CoordinateGraph graph = Parser.LoadTSPGraph(tspFilePaths[0]);            

            BenchmarkSummary<TravelingSalesPersonIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                new Func<OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                        new PoissonTwoOptMutator(2),
                        new TravelingSalesPersonFitnessCalculator(),
                        new LoggerBase<TravelingSalesPersonIndividual>(),
                        new TravelingSalesPersonIndividual(graph))),
                new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                {
                    return algorithm.Iterations >= 50000;
                }),
                100
                );

            await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                result,
                $"(1+1)EA with poisson distributed two opt mutation on TSP with lambda of 2",
                "OnePlusOneEA_TSP_TwoOptPoisson2_50kItr",
                100);
        }

        public async Task OnePlusOneEA_TSP_TwoOptPoisson2_1And5MilIterations()
        {
            ResourceManager.tspFiles.TryGetValue("berlin52", out String[] tspFilePaths);
            CoordinateGraph graph = Parser.LoadTSPGraph(tspFilePaths[0]);

            BenchmarkSummary<TravelingSalesPersonIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                new Func<OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                        new PoissonTwoOptMutator(2),
                        new TravelingSalesPersonFitnessCalculator(),
                        new LoggerBase<TravelingSalesPersonIndividual>(),
                        new TravelingSalesPersonIndividual(graph))),
                new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                {
                    return algorithm.Iterations >= 1000000;
                }),
                100
                );

            await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                result,
                $"(1+1)EA with poisson distributed two opt mutation on TSP with lambda of 2 with 1 mil iterations avg over 100 runs",
                "OnePlusOneEA_TSP_TwoOptPoisson2_1MilItr",
                100);

            result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                new Func<OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                        new PoissonTwoOptMutator(2),
                        new TravelingSalesPersonFitnessCalculator(),
                        new LoggerBase<TravelingSalesPersonIndividual>(),
                        new TravelingSalesPersonIndividual(graph))),
                new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                {
                    return algorithm.Iterations >= 5000000;
                }),
                100
                );

            await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                result,
                $"(1+1)EA with poisson distributed two opt mutation on TSP with lambda of 2 with 5 mil iterations avg over 100 runs",
                "OnePlusOneEA_TSP_TwoOptPoisson2_5MilItr",
                100);
        }

        public async Task OnePlusOneEA_TSP_TwoOpt()
        {
            ResourceManager.tspFiles.TryGetValue("berlin52", out String[] tspFilePaths);
            CoordinateGraph graph = Parser.LoadTSPGraph(tspFilePaths[0]);

            BenchmarkSummary<TravelingSalesPersonIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                new Func<OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<TravelingSalesPersonIndividual>(
                        new TwoOptMutator(),
                        new TravelingSalesPersonFitnessCalculator(),
                        new LoggerBase<TravelingSalesPersonIndividual>(),
                        new TravelingSalesPersonIndividual(graph))),
                new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                {
                    return algorithm.Iterations >= 20000;
                }),
                100
                );

            await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                result,
                $"(1+1)EA with two opt mutation on TSP",
                "OnePlusOneEA_TSP_TwoOpt_20kItr",
                100);
        }

        private async Task OnePlusOneEA_TSP_PoissonTwoOpt()
        {
            ResourceManager.tspFiles.TryGetValue("berlin52", out String[] tspFilePaths);
            CoordinateGraph graph = Parser.LoadTSPGraph(tspFilePaths[0]);

            double[] lambda = { 0.75, 1, 1.25, 1.5, 1.75, 2, 2.25, 2.5 };

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
                     return algorithm.Iterations >= 50000;
                 }),
                 50
                 );

                await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                    result,
                    $"(1+1)EA with poisson two opt mutation on TSP",
                    $"OnePLusOneEA_TSP_PoissonTwoOpt_{lambda[i]}", 100);
            }
        }

        #endregion

        #region Simulated Annealing

        //One Max
        // eksponential cooling scheme        
        // See that temp doesnt help så low start temp is better

        public async Task SimulatedAnnealing_OneMax_ALL()
        {
            /* We try a few setting leading to the conclusion that RLS is best*/

            int[] bitLengths = { 50, 100, 150, 200, 250, 300, 350, 400, 450, 500 };

            foreach (int bitLength in bitLengths)
            {

                // Eks cooling start temp 1
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new OneMaxFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(1d, 1d - (1d / bitLength)),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   100
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, $"EXP Cooling, alpha 1-1/n, start temp 1, bitlength {bitLength}", $"SimulatedAnnealing_OneMax_EXP_T1_{bitLength}", 20);

                // eks cooling start n
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new OneMaxFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(bitLength, 1d - (1d / bitLength)),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   100
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "EXP Cooling, alpha 1-1/n, start temp n, bitlength 500", $"SimulatedAnnealing_OneMax_EXP_Tn_{bitLength}", 20);

                // start temp 0
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new OneMaxFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(0, 1d - (1d / bitLength)),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   100
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "EXP Cooling, alpha 1-1/n, start temp 0, bitlength 500", $"SimulatedAnnealing_OneMax_EXP_T0_{bitLength}", 20);

                // MA start temp n Fixed temp
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new OneMaxFitnessCalculator(),
                           new MACooldownFunction(),
                           new LinearTemperatureFunction(bitLength, 0),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   100
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "fixed temp, start temp n, bitlength 500", $"SimulatedAnnealing_OneMax_MA_Tn_{bitLength}", 20);

                // MA temp = 0.5n
                // MA start temp n Fixed temp
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new OneMaxFitnessCalculator(),
                           new MACooldownFunction(),
                           new LinearTemperatureFunction(bitLength / 2d, 0),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   100
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "fixed temp, start temp 0.5n, bitlength 500", $"SimulatedAnnealing_OneMax_MA_TnHalf_{bitLength}", 20);
            }
        }

        public async Task SimulatedAnnealing_LeadingOnes_ALL()
        {
            /* We try a few setting leading to the conclusion that RLS is best*/

            int[] bitLengths = { 50, 100, 150, 200, 250, 300, 350, 400, 450 };

            foreach (int bitLength in bitLengths)
            {

                // Eks cooling start temp 1
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new LeadingOnesFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(1d, 1d - (1d / bitLength)),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "EXP Cooling, alpha 1-1/n, start temp 1, bitlength 500", $"SimulatedAnnealing_LeadingOnes_EXP_T1_{bitLength}", 20);

                // eks cooling start n
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new LeadingOnesFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(bitLength, 1d - (1d / bitLength)),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "EXP Cooling, alpha 1-1/n, start temp n, bitlength 500", $"SimulatedAnnealing_LeadingOnes_EXP_Tn_{bitLength}", 20);

                // start temp 0
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new LeadingOnesFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(0, 1d - (1d / bitLength)),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "EXP Cooling, alpha 1-1/n, start temp 0, bitlength 500", $"SimulatedAnnealing_LeadingOnes_EXP_T0_{bitLength}", 20);

                // MA start temp n Fixed temp
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new LeadingOnesFitnessCalculator(),
                           new MACooldownFunction(),
                           new LinearTemperatureFunction(bitLength, 0),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "fixed temp, start temp n, bitlength 500", $"SimulatedAnnealing_LeadingOnesx_MA_Tn_{bitLength}", 20);

                // MA temp = 0.5n
                // MA start temp n Fixed temp
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new LeadingOnesFitnessCalculator(),
                           new MACooldownFunction(),
                           new LinearTemperatureFunction(bitLength / 2d, 0),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "fixed temp, start temp 0.5n, bitlength 500", $"SimulatedAnnealing_LeadingOnes_MA_TnHalf_{bitLength}", 20);
            }
        }

        public async Task SimulatedAnnealing_BinVal_ALL()
        {
            /* We try a few setting leading to the conclusion that RLS is best*/

            int[] bitLengths = { 5, 10, 15, 20, 25, 30 };

            foreach (int bitLength in bitLengths)
            {

                // Eks cooling start temp 1
                BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new BinValFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(1d, 1d - (1d / bitLength)),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "EXP Cooling, alpha 1-1/n, start temp 1, bitlength 500", $"SimulatedAnnealing_BinVal_EXP_T1_{bitLength}", bitLength/2);

                // eks cooling start n
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new BinValFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(bitLength, 1d - (1d / bitLength)),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "EXP Cooling, alpha 1-1/n, start temp n, bitlength 500", $"SimulatedAnnealing_BinVal_EXP_Tn_{bitLength}", bitLength / 2);

                // start temp 0
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new BinValFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(0, 1d - (1d / bitLength)),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "EXP Cooling, alpha 1-1/n, start temp 0, bitlength 500", $"SimulatedAnnealing_BinVal_EXP_T0_{bitLength}", bitLength / 2);

                // MA start temp n Fixed temp
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new BinValFitnessCalculator(),
                           new MACooldownFunction(),
                           new LinearTemperatureFunction(bitLength, 0),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "fixed temp, start temp n, bitlength 500", $"SimulatedAnnealing_BinVal_MA_Tn_{bitLength}", bitLength / 2);

                // MA temp = 0.5n
                // MA start temp n Fixed temp
                result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<BitStringIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<BitStringIndividual>(
                           new OneOverNXBitStringMutation(),
                           new BinValFitnessCalculator(),
                           new MACooldownFunction(),
                           new LinearTemperatureFunction(bitLength / 2d, 0),
                           new LoggerBase<BitStringIndividual>(),
                           new BitStringIndividual(bitLength))),
                   new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                   {
                       if (algorithm.Logger?.History.Count < 1) return false;
                       return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                   }),
                   50
                   );

                await ParseAndWriteBenchmark<BitStringIndividual>(result, "fixed temp, start temp 0.5n, bitlength 500", $"SimulatedAnnealing_BinVal_MA_TnHalf_{bitLength}", bitLength / 2);
            }
        }

        //TSP 
        // start temp = n^3 and alpha
            // 1 - 1/cn^2 c=> 1, 1,5, 2, 2.5
            // 1 - 1/n 
        // start temp = n and aplha
            // 1 - 1/cn^2 c=> 2, 4, 6, 10, 20
            // 1 - 1/n 
        // T = 0
        // MA T => 1, n

        public async Task SimulatedAnnealing_TSP_ALL()
        {
            //TSP 
            // start temp = n^3 and alpha
                // 1 - 1/cn^2 c=> 1, 1,5, 2, 2.5
                // 1 - 1/n 
            // start temp = n and aplha
                // 1 - 1/cn^2 c=> 2, 4, 6, 10, 20
                // 1 - 1/n 
            // T = 0
            // MA T => 1, n

            ResourceManager.tspFiles.TryGetValue("berlin52", out String[] tspFilePaths);
            CoordinateGraph graph = Parser.LoadTSPGraph(tspFilePaths[0]);

            int n = graph.Verticies.Count();

            // Experiments wiht starting temp n^3 using aplha cooldown where alpha is 1 - 1/cn^2 for all c = 1, 1,5, 2, 2.5
            // and a lot faster cooldown 1-1/n

            BenchmarkSummary<TravelingSalesPersonIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                  new Func<SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>>(() =>
                      new SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>(
                          new PoissonTwoOptMutator(2),
                          new TravelingSalesPersonFitnessCalculator(),
                          new ExpOneOverTCooldownFunction(),
                          new AlphaTemperatureFunction(Math.Pow(n, 3), 1d - (1d / n)),
                          new LoggerBase<TravelingSalesPersonIndividual>(),
                          new TravelingSalesPersonIndividual(graph))),
                  new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                  {
                      return algorithm.Iterations >= 50000;
                  }),
                  100
                  );

            await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                result, "EXP Cooling, alpha 1-1/n, start temp n^3, Berlin52", $"SimulatedAnnealing_TSP_EXP_n3", 100);

            double[] cs = { 1, 1.5, 2, 2.5 };

            foreach (double c in cs)
            {
                result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                  new Func<SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>>(() =>
                      new SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>(
                          new PoissonTwoOptMutator(2),
                          new TravelingSalesPersonFitnessCalculator(),
                          new ExpOneOverTCooldownFunction(),
                          new AlphaTemperatureFunction(Math.Pow(n, 3), 1d - (1d / (c * Math.Pow(n, 2)))),
                          new LoggerBase<TravelingSalesPersonIndividual>(),
                          new TravelingSalesPersonIndividual(graph))),
                  new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                  {
                      return algorithm.Iterations >= 50000;
                  }),
                  100
                  );

                await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                    result, "EXP Cooling, alpha 1-1/cn^2, start temp n^3, Berlin52", $"SimulatedAnnealing_TSP_EXP_n3_C{c}", 100);
            }

            // Experiments wiht starting temp n using aplha cooldown where alpha is 1 - 1/cn^2 for all c = 2, 4, 6, 10, 20
            // and a lot faster cooldown 1-1/n

            result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                  new Func<SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>>(() =>
                      new SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>(
                          new PoissonTwoOptMutator(2),
                          new TravelingSalesPersonFitnessCalculator(),
                          new ExpOneOverTCooldownFunction(),
                          new AlphaTemperatureFunction(n, 1d - (1d / n)),
                          new LoggerBase<TravelingSalesPersonIndividual>(),
                          new TravelingSalesPersonIndividual(graph))),
                  new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                  {
                      return algorithm.Iterations >= 50000;
                  }),
                  100
                  );

            await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                result, "EXP Cooling, alpha 1-1/n, start temp n, Berlin52", $"SimulatedAnnealing_TSP_EXP_n", 100);

            cs = new double[] { 2, 4, 6, 10, 20 };

            foreach (double c in cs)
            {
                result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                  new Func<SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>>(() =>
                      new SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>(
                          new PoissonTwoOptMutator(2),
                          new TravelingSalesPersonFitnessCalculator(),
                          new ExpOneOverTCooldownFunction(),
                          new AlphaTemperatureFunction(n, 1d - (1d / (c * Math.Pow(n, 2)))),
                          new LoggerBase<TravelingSalesPersonIndividual>(),
                          new TravelingSalesPersonIndividual(graph))),
                  new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                  {
                      return algorithm.Iterations >= 50000;
                  }),
                  100
                  );

                await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                    result, "EXP Cooling, alpha 1-1/cn^2, start temp n, Berlin52", $"SimulatedAnnealing_TSP_EXP_n_C{c}", 100);
            }

            // MA start temp n Fixed temp
            result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                  new Func<SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>>(() =>
                      new SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>(
                          new PoissonTwoOptMutator(2),
                          new TravelingSalesPersonFitnessCalculator(),
                          new MACooldownFunction(),
                          new LinearTemperatureFunction(n, 0),
                          new LoggerBase<TravelingSalesPersonIndividual>(),
                          new TravelingSalesPersonIndividual(graph))),
                  new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                  {
                      return algorithm.Iterations >= 50000;
                  }),
                  100
                  );

            await ParseAndWriteBenchmark(result, "fixed temp, start temp n, berlin52", $"SimulatedAnnealing_TSP_MA_Tn", 100);

            // MA start temp 1 Fixed temp
            result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                  new Func<SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>>(() =>
                      new SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>(
                          new PoissonTwoOptMutator(2),
                          new TravelingSalesPersonFitnessCalculator(),
                          new MACooldownFunction(),
                          new LinearTemperatureFunction(1, 0),
                          new LoggerBase<TravelingSalesPersonIndividual>(),
                          new TravelingSalesPersonIndividual(graph))),
                  new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                  {
                      return algorithm.Iterations >= 50000;
                  }),
                  100
                  );

            await ParseAndWriteBenchmark(result, "fixed temp, start temp 1, berlin52", $"SimulatedAnnealing_TSP_MA_T1", 100);


            // Start temp 0
            result = await Benchmarker.BenchmarkSynchronousAsync<TravelingSalesPersonIndividual>(
                   new Func<SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>>(() =>
                       new SimulatedAnnealingAlgorithm<TravelingSalesPersonIndividual>(
                           new PoissonTwoOptMutator(2),
                           new TravelingSalesPersonFitnessCalculator(),
                           new ExpOneOverTCooldownFunction(),
                           new AlphaTemperatureFunction(0, 1),
                           new LoggerBase<TravelingSalesPersonIndividual>(),
                           new TravelingSalesPersonIndividual(graph))),
                   new Predicate<IGeneticAlgorithm<TravelingSalesPersonIndividual>>((algorithm) =>
                   {
                       return algorithm.Iterations >= 50000;
                   }),
                   100
                   );

            await ParseAndWriteBenchmark<TravelingSalesPersonIndividual>(
                result, "start temp 0, Berlin52", $"SimulatedAnnealing_TSP_T0", 100);

        }

        // Performance table Berlin and Bier

        #endregion

        public async Task Test()
        {
            int bitLength = 100;
            BenchmarkSummary<BitStringIndividual> result = await Benchmarker.BenchmarkSynchronousAsync<BitStringIndividual>(
                new Func<OnePlusOneEaAlgorithm<BitStringIndividual>>(() =>
                    new OnePlusOneEaAlgorithm<BitStringIndividual>(
                        new OneOverNXBitStringMutation(),
                        new OneMaxFitnessCalculator(),
                        new LoggerBase<BitStringIndividual>(),
                        new BitStringIndividual(bitLength))),
                new Predicate<IGeneticAlgorithm<BitStringIndividual>>((algorithm) =>
                {
                    if (algorithm.Logger?.History.Count < 1) return false;
                    return algorithm?.Logger?.History?.Last()?.HighestFitness >= bitLength;
                }),
                200
                );

            await ParseAndWriteBenchmark<BitStringIndividual>(result, "Test", "Test", bitLength);
        }

        private async Task ParseAndWriteBenchmark<TIndividual>(BenchmarkSummary<TIndividual> result, string benchmarkInformation, string name, int intervals) where TIndividual : IIndividual
        {
            var amountOfGenerations = result.Summaries.Select(algorithm => algorithm.Algorithm.Logger.AmountOfGenerations);

            var amountOfIterations = result.Summaries.Select(algorithm => algorithm.Algorithm.Iterations);

            var graphsOverIterationPerGeneration = result.Summaries.Select(
                algorithm => {
                    List<int> numbers = new List<int>();
                    algorithm.Algorithm.Logger.History.ForEach(generation => numbers.Add(generation.Iteration));
                    return numbers;
                });
           
            var graphsOverHighestFitness = result.Summaries.Select(
                algorithm => {
                    List<int> numbers = new List<int>();
                    algorithm.Algorithm.Logger.History.ForEach(generation => numbers.Add(generation.HighestFitness));
                    return numbers;
                });

            //int amountOfIntervals = intervals;
            //int maxItr = amountOfIterations.Max();
            //int itrInterval = maxItr / amountOfIntervals;
            //Dictionary<int, List<int>> graphFitnessOverIterations = new();

            //var iterationAndFitness = graphsOverIterationPerGeneration.Zip(graphsOverHighestFitness);
            //foreach((var itrLst, var fitLst) in iterationAndFitness)
            //{
            //    for (int i = 0; i < itrLst.Count; i++)
            //    {
            //        int iteration = itrLst[i];
            //        int fit = fitLst[i];
            //        int interval = iteration / itrInterval;

            //        if(graphFitnessOverIterations.TryGetValue(interval, out List<int> list))
            //            list.Add(fit);
            //        else
            //            graphFitnessOverIterations.Add(interval, new List<int> { fit });
            //    }
            //}

            //Erik ny kode
            int amountOfIntervals = intervals;
            int maxItr = amountOfIterations.Max();
            int itrInterval = maxItr / amountOfIntervals;
            var iterationAndFitness = graphsOverIterationPerGeneration.Zip(graphsOverHighestFitness);

            List<int[]> graphFit = new();
            foreach ((var itrLst, var fitLst) in iterationAndFitness)
            {
                int generationCounter = 0;
                int prevFitness = fitLst[0];
                int[] internalResult = new int[amountOfIntervals];
                for(int intervalCounter = 1; intervalCounter<amountOfIntervals; intervalCounter++)
                {
                    while(generationCounter < itrLst.Count && itrLst[generationCounter] <= intervalCounter * itrInterval)
                    {
                        prevFitness = fitLst[generationCounter];
                        generationCounter++;
                    }

                    internalResult[intervalCounter] = prevFitness;
                }
                graphFit.Add(internalResult);
            }

            int[] TempRes = new int[amountOfIntervals];

            for(int i = 0; i < amountOfIntervals; i++)
            {
                int sum = 0;
                foreach(var arr in graphFit) { sum += arr[i]; }
                TempRes[i] = sum / graphFit.Count();
            }
            int[] TempInterval = Enumerable.Range(1, amountOfIntervals).Select(i => i * itrInterval).ToArray();



            //List<int> intervalMids = new();
            //List<int> fitness = new();
            //foreach(var elm in graphFitnessOverIterations)
            //{
            //    intervalMids.Add(itrInterval * elm.Key + (itrInterval / 2));
            //    fitness.Add((int)Math.Round(elm.Value.Average()));
            //}

            var allIndividual = result.Summaries.Select(
                algorithm => {
                    List<string> numbers = new List<string>();
                    algorithm.Algorithm.Logger.History.ForEach(generation => numbers.Add(generation.HighestFitnessIndividual.ToString()));
                    return numbers;
                });

            var generationTimeStamps = result.Summaries.Select(algorithm => algorithm.GenerationTimeStamps);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(benchmarkInformation);
            sb.AppendLine();
            sb.AppendLine("---Summery--");
            sb.AppendLine($"Iterations Best/Mean/Worst: {result.BestAmountOfIterations}, {result.MeanAmountOfIterations}, {result.WorstAmountOfIterations}");
            sb.AppendLine($"Generations Best/Mean/Worst: {result.BestAmountOfGenerations}, {result.MeanAmountOfGenerations}, {result.WorstAmountOfGenerations}");
            sb.AppendLine($"BROKEN OptimizationTime Best/Mean/Worst: {result.BestOptimizationTIme}, {result.MeanOptimizationTime}, {result.WorstOptimizationTIme}");
            sb.AppendLine();

            sb.AppendLine("---Middle of intervals and avg fitness eg. interval [0..100] => 50 and fit{1,3,2} => 2---");
            sb.AppendLine("IntervalMids: " + string.Join(", ", TempInterval));
            sb.AppendLine("Fitness: " + string.Join(", ", TempRes));

            sb.AppendLine($"---IterationsPerGeneration---");
            int count = 0;
            foreach (var graph in graphsOverIterationPerGeneration)
            {
                sb.AppendLine($"{count++}: {string.Join(", ", graph)}");
            }

            sb.AppendLine();
            sb.AppendLine($"---GenerationTimeStamps---");
            count = 0;
            foreach (var timeStamps in generationTimeStamps)
            {
                sb.AppendLine($"{count++}: {string.Join(", ", timeStamps)}");
            }

            sb.AppendLine();
            sb.AppendLine($"---Total Generatins for each run---");
            sb.AppendLine($"{string.Join(", ", amountOfGenerations)}");

            sb.AppendLine();
            sb.AppendLine($"---Total Iterations for each run---");
            sb.AppendLine($"{string.Join(", ", amountOfIterations)}");

            sb.AppendLine();
            sb.AppendLine($"---GraphsOverHighestFitnessPerGeneration---");
            count = 0;
            foreach (var graph in graphsOverHighestFitness)
            {
                sb.AppendLine($"{count++}: {string.Join(", ", graph)}");
            }

            //sb.AppendLine();
            //sb.AppendLine($"---Individuals---");
            //count = 0;
            //foreach (var graph in allIndividual)
            //{
            //    sb.AppendLine($"{count++}: {string.Join(", ", graph)}");
            //}

            string s = sb.ToString();

            await WriteToTarget(s, name);
        }

        private async Task WriteToTarget(string text, string folderName)
        {
            await File.WriteAllTextAsync(Path.Combine(path, folderName), text);
        }
    }
}
