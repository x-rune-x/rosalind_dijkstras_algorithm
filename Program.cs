using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphImporter graphImporter = new GraphImporter("C:/Users/masterofdoom/code projects/C#/Dijkstra/sampleData.txt");
            Console.WriteLine($"The number of vertices is {graphImporter.numberOfVertices}, the number of edges is {graphImporter.numberOfEdges}");

            List<Edge> graph = graphImporter.GetGraphFromFile();
            List<string> vertexList = new();

            foreach (Edge edge in graph)
            {
                Console.WriteLine($"{edge.v1} - {edge.v2} > {edge.distance}");

                if (vertexList.Contains(edge.v1) == false)
                {
                    vertexList.Add(edge.v1);
                }
                if (vertexList.Contains(edge.v2) == false)
                {
                    vertexList.Add(edge.v2);
                }
            }
            var unvisitedVertex = vertexList.Where(x => x != "1").ToList();
            List<string> vertexToExplore = new() { "1" };

            List<PathToVertex> knownShortestPaths = new();

            foreach (string vertex in vertexList)
            {
                if (vertex == "1")
                {
                    knownShortestPaths.Add(new PathToVertex(vertex, 0));
                }
                else
                {
                    knownShortestPaths.Add(new PathToVertex(vertex, double.PositiveInfinity));
                }
            }
            
            while (unvisitedVertex.Count > 0 && vertexToExplore.Count > 0)
            {
                foreach (Edge edge in graph)
                {
                    if (vertexToExplore.Contains(edge.v1))
                    {
                        if (unvisitedVertex.Contains(edge.v2))
                        {
                            vertexToExplore.Add(edge.v2);
                            unvisitedVertex.Remove(edge.v2);

                            // PathToVertex checkPath = knownShortestPaths.Where(x => x.vertex == edge.v2);
                        }
                    }
                }
            }
        }
        public void findPath(string vertex, List<Edge> edgeList)
        {

        }
    }
}
