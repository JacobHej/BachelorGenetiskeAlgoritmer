using Algorithms.Infrastructure.BaseImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.SimulatedAnnealing
{
    public class LinearTemperatureFunction : TemperatureFunctionBase
    {
        private readonly double initialTemperature;
        private readonly double constant;

        public LinearTemperatureFunction(double initialTemp, double constant)
        {
            this.initialTemperature = initialTemp;
            this.constant = constant;
        }

        public override double Measure(int t) => initialTemperature - constant * t;
    }
}
