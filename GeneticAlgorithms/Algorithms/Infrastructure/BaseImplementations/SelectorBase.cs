﻿using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class SelectorBase<TIndividual> : ISelector<TIndividual> where TIndividual : IIndividual
    {
        public abstract TIndividual Select(IPopulation<TIndividual> population);
    }
}