using Algorithms;
using Common;
using IOParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms
{
    public class MainFormModel
    {
        private RandomWalk algorithm;

        public int TimesEvaluated { get; private set; } = 0;
        public Graph EvaluatedGraph { get; private set; }
        public Dictionary<string, string> Files { get; private set; }

        public MainFormModel()
        {
            Files = ResourceManager.Resources;
        }

        public void LoadGraph(string path)
        {
            Files.TryGetValue(path, out string fullPath);
            algorithm = new RandomWalk(Parser.LoadXmlGraph(fullPath ?? path));
        }

        public void EvaluateGraph()
        {
            EvaluatedGraph = algorithm.Evaluate();
            TimesEvaluated++;
        }

        public void Clear()
        {
            EvaluatedGraph = null;
        }
    }
}
