using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Algorithms.TravelingSalesPerson;
using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ACO
{
    public class MinMaxBitStringPheramoneConstructor : PheramoneConstructorBase<BitStringIndividual>
    {
        private double p;
        private double min;
        private double max;

        public MinMaxBitStringPheramoneConstructor(double p, double min, double max)
        {
            this.p = p;
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Initialize all pheromones with some value
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="iniitalPheromone"></param>
        /// <returns></returns>
        public Dictionary<string, double> InitializePheromones(int bitStringLength, double iniitalPheromone)
        {
            Dictionary<string, double> initialPheromones = new Dictionary<string, double>();

            for(int i = 0; i < bitStringLength; i++)
            {
                initialPheromones.Add(i + "," + 0, iniitalPheromone);
                initialPheromones.Add(i + "," + 1, iniitalPheromone);
            }

            return initialPheromones;
        }

        public override Dictionary<string, double> ConstructPheramones(Dictionary<string, double> previousPheramones, List<BitStringIndividual> individuals)
        {
            double n = individuals.FirstOrDefault().Solution.Bits.Length;
            Dictionary<string, double> newPheramones = new Dictionary<string, double>();

            // evaporate old pheromones
            foreach(KeyValuePair<string, double> pheromone in previousPheramones)
            {
                newPheramones.Add(pheromone.Key, Math.Max(pheromone.Value * (1d - p), min));
            }

            for (int i = 0; i < individuals.Count; i++)
            {
                BitStringIndividual ind = individuals[i];
                double value = p;
                for (int j = 0; j < ind.Solution.Bits.Length; j++)
                {
                    string key = j + "," + ind.Solution.Bits[j];

                    if (previousPheramones.TryGetValue(key, out double val))
                    {
                        newPheramones.Remove(key);
                        newPheramones.Add(key, Math.Min((1d - p) * val + value, max));
                    }                    
                }
            }

            return newPheramones;
        }
    }
}
