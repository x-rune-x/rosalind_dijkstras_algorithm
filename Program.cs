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
            Console.WriteLine(($"The number of vertices is {graphImporter.numberOfVertices}, the number of edges is {graphImporter.numberOfEdges}"));

            List<Edge> graph = graphImporter.GetGraphFromFile();
            Console.WriteLine(graph);
        }
    }
}
