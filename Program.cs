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

            var graph = graphImporter.GetGraphFromFile();
            var edgeList = graph.Item1;
            var vertexList = graph.Item2;

            foreach (Vertex vertex in vertexList)
            {
                Console.WriteLine(vertex.name);
            }

            foreach (Edge edge in edgeList)
            {
                Console.WriteLine($"edge is {edge.vertex1.name} to {edge.vertex2.name} with a time of {edge.distance}");

                //if (vertexList.Contains(edge.v1) == false)
                //{
                //    vertexList.Add(edge.v1);
                //}
                //if (vertexList.Contains(edge.v2) == false)
                //{
                //    vertexList.Add(edge.v2);
                //}
            }
            //var unvisitedVertices = vertexList.Where(x => x != "1").ToList();
            //var verticesToExplore = vertexList.Where(x => x == "1").ToList(); // Initiialse the list of vertices to explore from to 1 since that is the starting point.

            //List<PathToVertex> knownShortestPaths = new();

            //foreach (string vertex in vertexList)
            //{
            //    if (vertex == "1")
            //    {
            //        knownShortestPaths.Add(new PathToVertex(vertex, 0));
            //    }
            //    else
            //    {
            //        knownShortestPaths.Add(new PathToVertex(vertex, double.PositiveInfinity));
            //    }
            //}

            //while (unvisitedVertices.Count > 0 && verticesToExplore.Count > 0)
            //{
            //    List<string> vertexAddList = new();
            //    foreach (string vertex in verticesToExplore)
            //    {                    
            //        foreach (Edge edge in graph.Where(x => x.v1 == vertex))
            //        {
            //            var pathToSource = knownShortestPaths.Where(x => x.vertex == edge.v1).First();
            //            double currentDistanceToSource = pathToSource.distance;

            //            if (unvisitedVertices.Contains(edge.v2) == true)
            //            {
            //                unvisitedVertices.Remove(edge.v2);
            //                vertexAddList.Add(edge.v2);

            //                var shortestPathToVertex = knownShortestPaths.Where(x => x.vertex == edge.v2).First();
            //                var indexOfPathToVertex = knownShortestPaths.FindIndex(a => a.vertex == edge.v2);
            //                if (edge.distance + currentDistanceToSource < shortestPathToVertex.distance)
            //                {
            //                    shortestPathToVertex.distance = edge.distance + currentDistanceToSource;
            //                    shortestPathToVertex.direction = edge.v1;
            //                    knownShortestPaths[indexOfPathToVertex] = shortestPathToVertex;
            //                }
            //            }
            //        }
            //    }
            //    verticesToExplore.Clear();
            //    verticesToExplore.AddRange(vertexAddList);
            //}
            //foreach (PathToVertex path in knownShortestPaths)
            //{
            //    if (path.distance == double.PositiveInfinity)
            //    {
            //        path.distance = -1;
            //    }
            //}

            //foreach (PathToVertex path in knownShortestPaths)
            //{
            //    Console.WriteLine(path.distance);
            //}
        }
    }
}
