﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface IFitnessCalculator<TIndividual> where TIndividual : IIndividual
    {
        public int CalculateFitness(TIndividual individual);
    }
}
