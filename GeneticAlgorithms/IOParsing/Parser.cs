using Common;
using System.Xml;

namespace IOParsing
{
    public class Parser
    {
        public Graph LoadGraph()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("C:\\Workspaces\\BacehelorProject\\BachelorGenetiskeAlgoritmer\\a280.xml");

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
    }
}