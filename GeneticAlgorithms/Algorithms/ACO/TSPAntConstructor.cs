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

        public TSPAntConstructor(CoordinateGraph graph)
        {
            this.graph = graph;
            this.random = new Random();
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
            int n = graph.Verticies.Length;
            int[] solution = new int[n];
            List<int> moves = Enumerable.Range(0, n).ToList();
            moves.Remove(0);
            int currentcity = 0;
            solution[0] = 0;

            for (int i = 1; i < n; i++)
            {
                double[] weights = moves.Select(move =>
                {
                    int distance = graph.GetDistance(currentcity, move);
                    double weight = 1d / distance;
                    double pheramone;

                    if (pheramones.TryGetValue(Math.Min(currentcity, move).ToString() + "," + Math.Max(currentcity, move).ToString(), out pheramone))
                    {
                        weight += pheramone;
                    }

                    return weight;
                }).ToArray();

                double sum = weights.Sum();

                double selectedint = random.NextDouble() * sum;

                double count = 0;
                int index = 0;
                
                while(count < selectedint)
                {
                    count += weights[index++];
                }

                int move = moves[--index];
                moves.RemoveAt(index);

                currentcity = move;

                solution[i] = move;
            }

            return new TravelingSalesPersonIndividual(solution,graph);
        }
    }
}
