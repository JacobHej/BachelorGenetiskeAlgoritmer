﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Infrastructure.BaseImplementations;
using MathNet.Numerics;

namespace Algorithms.SimulatedAnnealing
{
    public class AlphaTemperatureFunction : TemperatureFunctionBase
    {
        private readonly double initialTemperature;
        private readonly double alpha;

        public AlphaTemperatureFunction(double initialTemp, double alpha)
        {
            this.initialTemperature = initialTemp;
            this.alpha = alpha;
        }

        public override double Measure(int t) => Math.Pow(alpha, t) * initialTemperature;
    }
}
