
namespace Dijkstra
{
    public class Vertex
    {
        public int name;
        public double shortestDistanceToVertex = double.PositiveInfinity; // All vertexes start an unknown time from vertex 1 so a value of infinity is assigned.
        public int precedingVertexInShortestPath;

        public Vertex(int vertexName)
        {
            name = vertexName;

            if (name == 1) // Because 1 is the starting vertex, it has a time penalty of 0 to reach.
            {
                shortestDistanceToVertex = 0;
            }
        }
    }
}
