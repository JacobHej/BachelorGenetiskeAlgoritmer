using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Benchmark
{
    public class BenchmarkLogger<TIndividual> : LoggerBase<TIndividual> where TIndividual : IIndividual
    {
        private int amountOfGenerations;
        public override int AmountOfGenerations { get { return amountOfGenerations; } protected set { amountOfGenerations = value; } }


        public BenchmarkLogger() : base()
        {
            History.Add(null);
        }

        public override void LogGeneration(IPopulation<TIndividual> population, IFitnessCalculator<TIndividual> fitnessCalculator) 
        {
            AmountOfGenerations++;
            History[0] = new Generation<TIndividual>(population, fitnessCalculator);
        }
    }
}
