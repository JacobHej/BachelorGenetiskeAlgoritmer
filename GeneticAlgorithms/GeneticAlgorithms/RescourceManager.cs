using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms
{
    public static class RescourceManager
    {
        public static Dictionary<string, string> Resources { get; private set; } = new Dictionary<string, string>();

        public static void ScanRescources()
        {
            string[] files = Directory.GetFiles("..\\..\\..\\Rescources");
            foreach (string file in files)
            {
                Resources.Add(file.Split('\\').Last(), file);
            }
        }
    }
}
