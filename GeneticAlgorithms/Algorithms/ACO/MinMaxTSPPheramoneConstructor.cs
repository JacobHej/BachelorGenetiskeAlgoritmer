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
    public class MinMaxTSPPheramoneConstructor : PheramoneConstructorBase<TravelingSalesPersonIndividual>
    {
        private double p;
        private double min;
        private double max;
        private IFitnessCalculator<TravelingSalesPersonIndividual> fitnessCalculator;
        public MinMaxTSPPheramoneConstructor(double p, IFitnessCalculator<TravelingSalesPersonIndividual> fitnessCalculator, double min, double max)
        {
            this.p = p;
            this.fitnessCalculator = fitnessCalculator;
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Initialize all pheromones with some value
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="iniitalPheromone"></param>
        /// <returns></returns>
        public Dictionary<string, double> InitializePheromones(CoordinateGraph graph, double iniitalPheromone)
        {
            Dictionary<string, double> initialPheromones = new Dictionary<string, double>();
            PointF[] verticies = graph.Verticies;

            for(int i = 0; i < verticies.Length; i++)
            {
                for(int j = 0; j < verticies.Length; j++)
                {
                    string key = Math.Min(i, j) + "," + Math.Max(i, j);

                    if (verticies[i].Equals(verticies[j]) || initialPheromones.ContainsKey(key)) continue;

                    initialPheromones.Add(key, iniitalPheromone);
                }
            }

            return initialPheromones;
        }

        public override Dictionary<string, double> ConstructPheramones(Dictionary<string, double> previousPheramones, List<TravelingSalesPersonIndividual> individuals)
        {
            int xBestForPheramones = individuals.Count;
            Dictionary<string, double> newPheramones = new Dictionary<string, double>();

            // evaporate old pheromones
            foreach(KeyValuePair<string, double> pheromone in previousPheramones)
            {
                newPheramones.Add(pheromone.Key, Math.Max(pheromone.Value * (1d - p), min));
            }

            for (int i = 0; i < xBestForPheramones; i++)
            {
                TravelingSalesPersonIndividual ind = individuals[i];
                double value = p;

                int from = ind.Solution[0];
                int to;
                String key;
                double val;

                for (int j = 1; j<ind.Solution.Length; j++)
                {
                    to = ind.Solution[j];
                    key = Math.Min(from, to) + "," + Math.Max(from,to);
                    from = to; 

                    if (newPheramones.TryGetValue(key, out val))
                    {
                        newPheramones.Remove(key);
                        newPheramones.Add(key, Math.Min((1d - p) * val + value, max));
                    }
                }

                from = ind.Solution[0];
                to = ind.Solution[ind.Solution.Count() - 1];
                key = Math.Min(from, to) + "," + Math.Max(from, to);

                if (newPheramones.TryGetValue(key, out val))
                {
                    newPheramones.Remove(key);
                    newPheramones.Add(key, Math.Min((1d - p) * val + value, max));
                }
            }

            return newPheramones;
        }
    }
}
