using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Vertex
    {
        public string name;
        public double shortestDistanceToVertex = double.PositiveInfinity;
        public string precedingVertexInShortestPath;

        public Vertex(string vertexName)
        {
            name = vertexName;
        }
    }
}
