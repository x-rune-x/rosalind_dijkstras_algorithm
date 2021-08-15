using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphImporter graphImporter = new GraphImporter("C:/Users/masterofdoom/code projects/C#/Dijkstra/rosalind_dij.txt");
            Console.WriteLine($"The number of vertices is {graphImporter.numberOfVertices}, the number of edges is {graphImporter.numberOfEdges}");

            var graph = graphImporter.GetGraphFromFile();
            var edgeList = graph.Item1;
            var vertexList = graph.Item2;
            var exploredVertices = new List<Vertex>();

            while (vertexList.Count > 0) // Each pass through the loop explores a new vertex which is then removed from the list at the end and added to the explored list.
            {
                vertexList = vertexList.OrderBy(x => x.shortestDistanceToVertex).ToList(); // Create a priority queue where the vertex with the shortest known path is next to be explored.
                var vertexToExplore = vertexList[0];

                var edgesToExplore = edgeList.Where(x => x.vertex1.name == vertexToExplore.name).ToList();
                foreach (Edge edge in edgesToExplore)
                {
                    if ((edge.vertex1.shortestDistanceToVertex + edge.time) < edge.vertex2.shortestDistanceToVertex)
                    {
                        edge.vertex2.shortestDistanceToVertex = edge.vertex1.shortestDistanceToVertex + edge.time;
                        edge.vertex2.precedingVertexInShortestPath = edge.vertex1.name;
                    }
                }

                vertexList.Remove(vertexToExplore);
                exploredVertices.Add(vertexToExplore);
            }

            exploredVertices = exploredVertices.OrderBy(x => x.name).ToList(); // Following code is mostly formatting to make Rosalind happy.           

            using StreamWriter sw = new("C:/Users/masterofdoom/code projects/C#/Dijkstra/solution.txt");
            {
                foreach (Vertex vertex in exploredVertices)
                {
                    if (vertex.shortestDistanceToVertex == double.PositiveInfinity)
                    {
                        vertex.shortestDistanceToVertex = -1;
                    }
                    Console.WriteLine($"{vertex.name}, {vertex.shortestDistanceToVertex}");
                    sw.Write(vertex.shortestDistanceToVertex + " ");
                }
            }
        }
    }
}
