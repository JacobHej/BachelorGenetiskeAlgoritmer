using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms
{
    public static class ResourceManager
    {
        public static Dictionary<string, string> Resources { get; private set; } = new Dictionary<string, string>();


        public static Dictionary<string, string[]> tspFiles { get; private set; } = new Dictionary<string, string[]>();
        public static void ScanRescources()
        {
            string[] files = Directory.GetFiles("..\\..\\..\\Rescources");

            string[] usableFileNames = files.Select(file => file.Split('\\').Last()).ToArray();

            foreach (string file in files)
            {
                String UsableFileName = file.Split('\\').Last();
                Resources.Add(UsableFileName, file);

                if (file.EndsWith(".tsp"))
                {

                    string name = UsableFileName.Split(".").First();
                    string optTour = null;
                    if (usableFileNames.Contains(name+".opt.tour"))
                    {
                        optTour = files.Where(x => x.Split('\\').Last().Equals(name+".opt.tour")).First();
                    }
                    

                    List<String> tsp = new List<String>();

                    tsp.Add(file);

                    if (optTour!=null)
                    {
                        tsp.Add(optTour);
                    }

                    tspFiles.Add(name, tsp.ToArray());

                }

            }
        }
    }
}
