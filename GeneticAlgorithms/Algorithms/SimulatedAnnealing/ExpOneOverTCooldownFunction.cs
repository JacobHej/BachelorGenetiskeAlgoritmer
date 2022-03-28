using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Infrastructure.BaseImplementations;

namespace Algorithms.SimulatedAnnealing
{
    public class ExpOneOverTCooldownFunction : CooldownFunctionBase
    {
        public override double Evaluate(int fitnessX, int fitnessY, double temperature) => Math.Exp((fitnessY - fitnessX) / temperature);
    }
}
