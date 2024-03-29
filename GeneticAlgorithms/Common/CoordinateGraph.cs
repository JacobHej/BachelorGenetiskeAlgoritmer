﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CoordinateGraph
    {
        private Dictionary<string, int> distances;

        public PointF[] Verticies;

        public int[] OptimalSolution;
        public int[] OptimalSolutionLookUp;

        public CoordinateGraph(PointF[] verticies, int[] optimalSolution = null)
        {
            this.Verticies = verticies;
            this.OptimalSolution = optimalSolution;
            this.distances = new Dictionary<string, int>();
        }

        public int GetDistance(int p1, int p2)
        {
            lock (this)
            {
                (p1, p2) = p2 < p1 ? (p2, p1) : (p1, p2);

                if (!distances.ContainsKey(p1.ToString() + p2.ToString()))
                {
                    PointF point1 = Verticies[p1];
                    PointF point2 = Verticies[p2];

                    PointF relativePoint = new PointF(point1.X - point2.X, point1.Y - point2.Y);

                    int distance = (int)Math.Round(Math.Sqrt(Math.Pow(relativePoint.X, 2) + Math.Pow(relativePoint.Y, 2)));
                    distances.Add(p1.ToString() + p2.ToString(), distance);
                }

                distances.TryGetValue(p1.ToString() + p2.ToString(), out int value);
                return value;
            }
        }
    } 
}
