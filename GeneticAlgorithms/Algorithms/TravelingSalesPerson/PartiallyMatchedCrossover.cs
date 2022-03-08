using Algorithms.Infrastructure.BaseImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.TravelingSalesPerson
{
    public class PartiallyMatchedCrossover : CrossoverBase<TravelingSalesPersonIndividual>
    {
        /// <summary>
        /// https://stackoverflow.com/questions/1544055/crossover-operation-in-genetic-algorithm-for-tsp -- 
        /// https://user.ceng.metu.edu.tr/~ucoluk/research/publications/tsp.pdf
        /// </summary>
        /// <param name="individual1"></param>
        /// <param name="individual2"></param>
        /// <returns></returns>
        public override TravelingSalesPersonIndividual Crossover(TravelingSalesPersonIndividual individual1, TravelingSalesPersonIndividual individual2)
        {
            TravelingSalesPersonIndividual newIndividual = 
                new TravelingSalesPersonIndividual(individual1.Solution, individual1.Problem);
            
            // Select CrossoverPoints
            Random random = new Random();

            int cp1 = 0;
            int cp2 = 0;

            while(cp1 == cp2)
            {
                cp1 = random.Next(1, individual1.Solution.Length - 2); 
                cp2 = random.Next(1, individual1.Solution.Length - 2);
            }

            (cp1, cp2) = cp2 < cp1 ? (cp2, cp1) : (cp1, cp2); // swap such that cp1 is smallest

            // a lookup table storing at position 4 the index of 4 in newIndividual
            int[] positionLookUp = new int[individual1.Solution.Length + 1];

            // build the lookup
            for (int i = 0; i < newIndividual.Solution.Length; i++) 
            {
                positionLookUp[newIndividual.Solution[i]] = i;
            }
            
            for (int i = cp1; i <= cp2; i++) 
            {
                int value = individual2.Solution[i];
                int index = positionLookUp[value];

                // swap values in newIndividual
                int t = newIndividual.Solution[index]; 
                newIndividual.Solution[index] = newIndividual.Solution[i];
                newIndividual.Solution[i] = t;

                // update the lookup
                t = positionLookUp[newIndividual.Solution[index]];
                positionLookUp[newIndividual.Solution[index]] = positionLookUp[newIndividual.Solution[i]];
                positionLookUp[newIndividual.Solution[i]] = t;
            }

            return newIndividual;
        }
    }
}
