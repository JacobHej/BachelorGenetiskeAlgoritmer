﻿using Algorithms.Infrastructure.BaseImplementations;
using Algorithms.Infrastructure.Interfaces;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.TravelingSalesPerson
{
    public class TravelingSalesPersonIndividual : IndividualBase
    {
        public CoordinateGraph Problem;
        public int[] Solution;

        public TravelingSalesPersonIndividual(CoordinateGraph problem, bool random = true)
        {
            this.Solution = 
                random 
                ? Enumerable.Range(0, problem.Verticies.Length).OrderBy(item => new Random().Next()).ToArray() 
                : Enumerable.Range(0, problem.Verticies.Length).ToArray();

            this.Problem = problem;
        }

        public TravelingSalesPersonIndividual(int[] solution, CoordinateGraph problem)
        {
            this.Solution = solution;
            this.Problem = problem;
        }

        public override IIndividual Copy()
        {
            int[] newArray = new int[Solution.Length];
            Solution.CopyTo(newArray, 0);

            return new TravelingSalesPersonIndividual(newArray, this.Problem);
        }

        public override string ToString()
        {
            return string.Join("", Solution.Select(i => i.ToString()));
        }
    }
}
