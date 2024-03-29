﻿using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class CrossoverBase<TIndividual> : ICrossover<TIndividual> where TIndividual : IIndividual
    {
        public abstract TIndividual Crossover(TIndividual individual1, TIndividual individual2);
    }
}
