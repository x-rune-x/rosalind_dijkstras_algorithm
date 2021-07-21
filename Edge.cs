using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Edge
    {
        public Vertex vertex1;
        public Vertex vertex2;
        public int distance;

        public Edge(Vertex v1, Vertex v2, int edgeDistance)
        {
            vertex1 = v1;
            vertex2 = v2;
            distance = edgeDistance;
        }
    }
}
