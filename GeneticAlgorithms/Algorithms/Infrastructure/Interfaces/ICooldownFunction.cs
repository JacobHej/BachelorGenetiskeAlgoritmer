using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Infrastructure.Interfaces
{
    public interface ICooldownFunction
    {
        public double Evaluate(int fitnessX, int fitnessY, double temperature);
    }
}
