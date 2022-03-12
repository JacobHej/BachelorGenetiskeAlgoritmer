using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Infrastructure.Interfaces;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class TemperatureFunctionBase : ITemperatureFunction
    {
        public abstract double Measure(int t);
    }
}
