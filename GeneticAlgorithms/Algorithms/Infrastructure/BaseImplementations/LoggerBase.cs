﻿using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public class LoggerBase<TIndividual> : ILogger<TIndividual> where TIndividual : IIndividual
    {
        public virtual List<Generation<TIndividual>> History { get; private set; }

        public virtual int AmountOfGenerations { get { return History.Count; } protected set { } }

        public LoggerBase()
        {
            History = new List<Generation<TIndividual>>();
        }

        public virtual void LogGeneration(IPopulation<TIndividual> population, IFitnessCalculator<TIndividual> fitnessCalculator, int iteration)
        {
            History.Add(new Generation<TIndividual>(population, fitnessCalculator, iteration));
            generationLogged?.Invoke(null, History.Last());
        }

        public void AttachOnLogGenerationEvent(EventHandler<Generation<TIndividual>> eventHandler)
        {
            generationLogged += eventHandler;
        }

        protected EventHandler<Generation<TIndividual>> generationLogged;
    }
}
