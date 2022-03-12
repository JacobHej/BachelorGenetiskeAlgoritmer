using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Infrastructure.Interfaces;

namespace Algorithms.Infrastructure.BaseImplementations
{
    public abstract class CooldownFunctionBase : ICooldownFunction
    {
        public abstract double Evaluate(int fitnessX, int fitnessY, double temperature);
    }
}
