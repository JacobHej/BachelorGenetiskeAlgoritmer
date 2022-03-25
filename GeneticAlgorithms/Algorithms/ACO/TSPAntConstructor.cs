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
    public class TSPAntConstructor : AntConstructorBase<TravelingSalesPersonPopulation, TravelingSalesPersonIndividual>
    {
        private CoordinateGraph graph;
        private Random random;

        private double alpha;
        private double beta;

        public TSPAntConstructor(CoordinateGraph graph, double alpha, double beta)
        {
            this.graph = graph;
            this.random = new Random();
            this.alpha = alpha;
            this.beta = beta;
        }

        public override TravelingSalesPersonPopulation ConstructAnst(Dictionary<string, double> pheramones, int amount)
        {
            List<TravelingSalesPersonIndividual> individuals = new List<TravelingSalesPersonIndividual>();

            for(int i = 0; i < amount; i++) {
                individuals.Add(ConstructAnt(pheramones));
            }

            return new TravelingSalesPersonPopulation(graph, individuals);
        }

        public override TravelingSalesPersonIndividual ConstructAnt(Dictionary<string, double> pheramones)
        {
            int amountOfCities = graph.Verticies.Length;
            int[] solution = new int[amountOfCities];
            List<double> moves = Enumerable.Range(0, amountOfCities).Select(i => (double)i).ToList();

            int randomStart = random.Next(moves.Count);
            moves.Remove(randomStart);
            int currentcity = randomStart;
            solution[0] = randomStart;

            for (int i = 1; i < amountOfCities; i++)
            {
                double[] weights = new double[moves.Count];

                //double summedProbabilities = moves.Aggregate((sum, move) =>
                //{
                //    int distance = graph.GetDistance(currentcity, (int)move);
                //    double visibility = 1d / distance;

                //    double pheramoneIntensity;
                //    pheramones.TryGetValue(Math.Min(currentcity, move).ToString() + "," + Math.Max(currentcity, move).ToString(), out pheramoneIntensity);

                //    return sum + Math.Pow(visibility, beta) * Math.Pow(pheramoneIntensity, alpha);
                //});

                for (int j = 0; j < moves.Count; j++)
                {                
                    int movej = (int)moves[j];
                    int distance = graph.GetDistance(currentcity, movej);
                    double visibility = 1d / distance;

                    double pheramoneIntensity;
                    pheramones.TryGetValue(Math.Min(currentcity, movej).ToString() + "," + Math.Max(currentcity, movej).ToString(), out pheramoneIntensity);

                    double probability = Math.Pow(visibility, beta) * Math.Pow(pheramoneIntensity, alpha);

                    weights[j] = probability; /// summedProbabilities;
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

                double move = moves[index];
                moves.RemoveAt(index);
                currentcity = (int)move;
                solution[i] = (int)move;
            }

            return new TravelingSalesPersonIndividual(solution,graph);
        }
    }
}
