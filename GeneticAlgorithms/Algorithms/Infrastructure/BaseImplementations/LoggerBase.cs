using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public class LoggerBase<TIndividual> : ILogger<TIndividual> where TIndividual : IIndividual
    {
        public List<Generation<TIndividual>> History { get; private set; }

        public LoggerBase()
        {
            History = new List<Generation<TIndividual>>();
        }

        public void LogGeneration(IPopulation<TIndividual> population, IFitnessCalculator<TIndividual> fitnessCalculator)
        {
            History.Add(new Generation<TIndividual>(population, fitnessCalculator));
        }
    }
}
