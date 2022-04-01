using Algorithms.BitStuff;
using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.TravelingSalesPerson;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ACO
{
    public class BitStringAntConstructor : AntConstructorBase<BitStringPopulation, BitStringIndividual>
    {
        private Random random;
        private int bitStringLength;

        public BitStringAntConstructor(int bitStringLength)
        {
            this.random = new Random();
            this.bitStringLength = bitStringLength; 
        }

        public override BitStringPopulation ConstructAnst(Dictionary<string, double> pheramones, int amount)
        {
            List<BitStringIndividual> individuals = new List<BitStringIndividual>();

            for(int i = 0; i < amount; i++) {
                individuals.Add(ConstructAnt(pheramones));
            }

            return new BitStringPopulation(individuals, bitStringLength);
        }

        public override BitStringIndividual ConstructAnt(Dictionary<string, double> pheramones)
        {
            char[] solution = new char[bitStringLength];

            for (int i = 0; i < bitStringLength; i++)
            {
                double[] weights = new double[2];

                for (int j = 0; j < 2; j++)
                {                
                    double probability;
                    pheramones.TryGetValue(i + "," + j, out probability);

                    weights[j] = probability;
                }

                double sum = weights.Sum();
                double selectedDouble = random.NextDouble() * sum;
                double count = 0;
                int index = -1;

                do
                {
                    index++;
                    count+= weights[index];
                }while (count < selectedDouble);

                solution[i] = Char.Parse(index.ToString());
            }

            return new BitStringIndividual(new BitString(solution));
        }
    }
}
