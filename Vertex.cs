
namespace Dijkstra
{
    public class Vertex
    {
        public string name;
        public double shortestDistanceToVertex = double.PositiveInfinity; // All vertexes start an unknown time from vertex 1 so a value of infinity is assigned.
        public string precedingVertexInShortestPath;

        public Vertex(string vertexName)
        {
            name = vertexName;

            if (name == "1") // Because 1 is the starting vertex, it has a time penalty of 0 to reach.
            {
                shortestDistanceToVertex = 0;
            }
        }
    }
}
