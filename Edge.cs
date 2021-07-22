
namespace Dijkstra
{
    class Edge // Each edge is composed of an origin vertex, a destination vertex and a time penalty between them.
    {
        public Vertex vertex1;
        public Vertex vertex2;
        public int time;

        public Edge(Vertex v1, Vertex v2, int edgeTime)
        {
            vertex1 = v1;
            vertex2 = v2;
            time = edgeTime;
        }
    }
}
