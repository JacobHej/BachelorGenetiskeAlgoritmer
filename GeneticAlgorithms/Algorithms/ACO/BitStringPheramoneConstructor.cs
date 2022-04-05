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
    public class BitStringPheramoneConstructor : PheramoneConstructorBase<BitStringIndividual>
    {
        private double p;
        private double q;
        private IFitnessCalculator<BitStringIndividual> fitnessCalculator;

        public BitStringPheramoneConstructor(double p, double q, IFitnessCalculator<BitStringIndividual> fitnessCalculator)
        {
            this.p = p;
            this.q = q;
            this.fitnessCalculator = fitnessCalculator;
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
                newPheramones.Add(pheromone.Key, pheromone.Value * p);
            }

            for (int i = 0; i < individuals.Count; i++)
            {
                BitStringIndividual ind = individuals[i];
                double value = fitnessCalculator.CalculateFitness(ind) / q;
                for (int j = 0; j < ind.Solution.Bits.Length; j++)
                {
                    string key = j + "," + ind.Solution.Bits[j];

                    if (previousPheramones.TryGetValue(key, out double val))
                    {
                        newPheramones.Remove(key);
                        newPheramones.Add(key, p * val + value);
                    }                    
                }
            }

            return newPheramones;
        }
    }
}
