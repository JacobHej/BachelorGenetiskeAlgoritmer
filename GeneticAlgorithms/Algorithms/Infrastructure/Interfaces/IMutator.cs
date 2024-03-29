﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface IMutator<TIndividual> where TIndividual : IIndividual
    {
        public TIndividual Mutate(TIndividual individual);
    }
}
