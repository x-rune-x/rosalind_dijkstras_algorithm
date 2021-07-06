using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Edge
    {
        public string v1;
        public string v2;
        public int distance;

        public Edge(string vertex1, string vertex2, int edgeDistance)
        {
            v1 = vertex1;
            v2 = vertex2;
            distance = edgeDistance;
        }
    }
}
