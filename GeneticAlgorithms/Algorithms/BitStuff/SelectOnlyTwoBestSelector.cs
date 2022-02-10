using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BitStuff
{
    public class SelectOnlyTwoBestSelector : SelectorBase<BitStringIndividual>
    {
        private IFitnessCalculator<BitStringIndividual> fitnessCalculator;
        public SelectOnlyTwoBestSelector(IFitnessCalculator<BitStringIndividual> fitnessCalculator)
        {
            this.fitnessCalculator = fitnessCalculator;
        }
        public override BitStringIndividual Select(IPopulation<BitStringIndividual> population)
        {
            // BROKEN!!!
            int sum = 0;
            population.Individuals.ForEach(i => sum += fitnessCalculator.CalculateFitness(i));

            Random random = new Random();
            int r = random.Next(sum);

            if(sum == 0)
            {
                return population.Individuals[random.Next(population.Individuals.Count)];
            }

            sum = 0;
            population.Individuals.Sort((a, b) => fitnessCalculator.CalculateFitness(a) - fitnessCalculator.CalculateFitness(b));
            var t = population.Individuals.SkipWhile(i => { sum += fitnessCalculator.CalculateFitness(i); return sum < r; }).First();

            return t;
        }
    }
}
