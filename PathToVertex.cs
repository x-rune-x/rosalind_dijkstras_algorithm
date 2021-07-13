using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class PathToVertex
    {
        public string vertex;
        public double distance;
        public string direction;

        public PathToVertex(string vertexVisited, double distanceToVertex, string precedingVertexInShortestPath = null)
        {
            vertex = vertexVisited;
            distance = distanceToVertex;
            direction = precedingVertexInShortestPath;
        }
    }
}
