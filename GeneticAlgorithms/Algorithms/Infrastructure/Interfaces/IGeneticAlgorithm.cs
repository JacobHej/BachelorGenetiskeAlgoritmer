﻿using Algorithms.Infrastructure.BaseImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface IGeneticAlgorithm<TIndividual> where TIndividual : IIndividual
    {
        public Task Evolve();
        public void Optimize(Predicate<GenericAlgorithmBase<TIndividual>> p);

        public ILogger<TIndividual> Logger { get; }
    }
}
