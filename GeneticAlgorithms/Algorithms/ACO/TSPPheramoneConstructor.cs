using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.TravelingSalesPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ACO
{
    public class TSPPheramoneConstructor : PheramoneConstructorBase<TravelingSalesPersonIndividual>
    {
        public override Dictionary<string, double> ConstructPheramones(Dictionary<string, double> previousPheramones, List<TravelingSalesPersonIndividual> individuals)
        {
            int xBestForPheramones = individuals.Count;
            Dictionary<string, double> newPheramones = new Dictionary<string, double>();

            for (int i = 0; i < xBestForPheramones; i++)
            {
                TravelingSalesPersonIndividual ind = individuals[i];
                double value = Math.Pow(1d / 2d, i);
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
