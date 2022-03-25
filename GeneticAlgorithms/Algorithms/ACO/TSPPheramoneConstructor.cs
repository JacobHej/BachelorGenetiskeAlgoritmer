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
    public class TSPPheramoneConstructor : PheramoneConstructorBase<TravelingSalesPersonIndividual>
    {
        private double p;
        private double q;
        private IFitnessCalculator<TravelingSalesPersonIndividual> fitnessCalculator;
        public TSPPheramoneConstructor(double p, double q, IFitnessCalculator<TravelingSalesPersonIndividual> fitnessCalculator)
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
        public override Dictionary<string, double> InitializePheromones(CoordinateGraph graph, double iniitalPheromone)
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
                newPheramones.Add(pheromone.Key, pheromone.Value * p);
            }

            for (int i = 0; i < xBestForPheramones; i++)
            {
                TravelingSalesPersonIndividual ind = individuals[i];
                double value = q / (-1 * fitnessCalculator.CalculateFitness(ind));

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
                        newPheramones.Add(key, val + value);
                    }
                    else
                    {
                        newPheramones.Add(key, value);
                    }
                }

                from = ind.Solution[0];
                to = ind.Solution[ind.Solution.Count() - 1];
                key = Math.Min(from, to) + "," + Math.Max(from, to);

                if (newPheramones.TryGetValue(key, out val))
                {
                    newPheramones.Remove(key);
                    newPheramones.Add(key, val + value);
                }
                else
                {
                    newPheramones.Add(key, value);
                }
            }

            return newPheramones;
        }
    }
}
