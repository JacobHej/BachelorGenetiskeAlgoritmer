using Common;
using System.Drawing;
using System.Globalization;
using System.Xml;

namespace IOParsing
{
    public static class Parser
    {

        public static Graph LoadXmlGraph(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);

            var vertex = xml.ChildNodes[1].ChildNodes[5].ChildNodes;

            var temp = xml.InnerText.Split(' ');

            Graph tsp = new Graph();

            foreach (XmlNode node in vertex)
            {
                var xmlEdges = node.ChildNodes;

                List<Edge> edges = new List<Edge>();

                foreach (XmlNode edge in xmlEdges)
                {
                    if (edge == null) continue;

                    XmlNode? xmlCost = edge.Attributes?.GetNamedItem("cost");
                    double weight = double.Parse(xmlCost?.InnerText ?? "0");
                    int vertexId = int.Parse(edge.InnerText);

                    edges.Add(new Edge() { Vertex = vertexId, Weight = weight });
                }

                tsp.Verticies.Add(new Vertex { Edges = edges });
            }

            return tsp;
        }

        public static CoordinateGraph LoadTspGraphWithOpt(string tspPath, string optPath)
        {
            CoordinateGraph graph = LoadTSPGraph(tspPath);

            String[] lines = File.ReadAllLines(optPath);
            int i = 0;
            while (i < lines.Length)
            {
                String line = lines[i];
                i++;
                String[] parts = line.Replace(" :", ":").Replace(": ", ":").Split(':');
                String attribute = parts[0];
                String value;
                //NAME: berlin52.opt.tour
                //TYPE : TOUR
                //DIMENSION : 52
                //TOUR_SECTION

                String name;
                String type;
                String size;

                switch (attribute)
                {

                    case "NAME":
                        value = parts[1];
                        name = value;
                        break;
                    case "TYPE":
                        value = parts[1];
                        type = value;
                        break;
                    case "DIMENSION":
                        value = parts[1];
                        size = value;
                        break;
                    case "TOUR_SECTION":
                        List<int> optTour = new List<int>();
                        while (i < lines.Length)
                        {//Loop through points till end of file
                            line = lines[i];
                            int index;
                            try
                            {
                                index = int.Parse(line);
                                i++;
                                if (index == -1)
                                {
                                    break;
                                }
                                
                                optTour.Add(index - 1);
                            }
                            catch (FormatException e)
                            {
                                if (e.Message == "Input string was not in a correct format.")
                                {
                                    break;
                                }
                            }
                        }

                        int[] optimalTour = optTour.ToArray();
                        int[] optimalTourLookUp = new int[optimalTour.Length];

                        for (int j = 0; j<optimalTour.Length; j++)
                        {
                            int val = optimalTour[j];
                            optimalTourLookUp[val] = j;
                        }

                        graph.OptimalSolution = optimalTour;
                        graph.OptimalSolutionLookUp = optimalTourLookUp;
                        break;
                }
            }
            return graph;
        }

        public static CoordinateGraph LoadTSPGraph(string path)
        {
            String[] lines = File.ReadAllLines(path);

            String name;
            String type;
            String comment;
            String size;
            String edgeWeightType;
            CoordinateGraph graph = null;


            int i = 0;
            while (i < lines.Length) { 
                String line = lines[i];
                i++;
                String[] parts = line.Replace(" :", ":").Replace(": ", ":").Split(':');
                String attribute = parts[0];
                String value;
                
                switch (attribute)
                {
                    case "NAME":
                        value = parts[1];
                        name = value;
                        break;
                    case "TYPE":
                        value = parts[1];
                        type = value;
                        break;
                    case "COMMENT":
                        value = parts[1];
                        comment = value;
                        break;
                    case "DIMENSION":
                        value = parts[1];
                        size = value;
                        break;
                    case "EDGE_WEIGHT_TYPE":
                        value = parts[1];
                        edgeWeightType = value;
                        break;
                    case "NODE_COORD_SECTION":
                        List<PointF> points = new List<PointF>();
                        while (i < lines.Length)
                        {//Loop through points till end of file
                            line = lines[i];
                            line = line.TrimStart();
                            String[] numberStrings = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            float[] values = null;
                            try 
                            {
                                values = numberStrings.ToList().Select(v => float.Parse(v, CultureInfo.InvariantCulture)).ToArray();
                            }catch (FormatException e)
                            {
                                if (e.Message == "Input string was not in a correct format.")
                                {
                                    break;
                                }
                            }
                            i++;
                            points.Add(new PointF(values[1], values[2]));
                        }
                        graph = new CoordinateGraph(points.ToArray());
                        break;
                    default:

                        break;

                }
                
            }
            return graph;
            
        }
    }

}