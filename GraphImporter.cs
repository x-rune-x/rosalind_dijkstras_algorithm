using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dijkstra
{
    class GraphImporter
    {
        public string filePath;
        public int numberOfVertices; //n
        public int numberOfEdges; // m

        public GraphImporter(string pathString)
        {
            filePath = pathString;

            using StreamReader sr = new(pathString); // The number of vertices (n) and number of edges (m) are stored in the first line of the text graph. 
            {
                string nAndmString = sr.ReadLine(); // Read the first line as a string.
                string[] nAndMList = nAndmString.Split(" "); // Split the string at the space and store the two integers in a list.
                numberOfVertices = Int32.Parse(nAndMList[0]); // n and m are stored in the first and second position of the list respectively.
                numberOfEdges = Int32.Parse(nAndMList[1]);
            }
        }

        public Tuple<List<Edge>, List<Vertex>> GetGraphFromFile() // By returning a tuple, we can return both all the vertices and all the edges of the graph in seperate lists.
        {
            List<Edge> edgeList = new();
            // List<string> vertexStrings = new();
            List<Vertex> vertexList = new();

            using StreamReader sr = new(filePath);
            {                
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] edgeComponents = line.Split(" ");

                    if (edgeComponents.Length == 3) // The first line of the input data only has 2 numbers, n and m and does not contain an edge. We want to ignore it.
                    {
                        int originVertex = Int32.Parse(edgeComponents[0]);
                        int destinationVertex = Int32.Parse(edgeComponents[1]);

                        if (!vertexList.Exists(x => x.name == originVertex))
                        {
                            vertexList.Add(new Vertex(originVertex));
                        }
                        if (!vertexList.Exists(x => x.name == destinationVertex))
                        {                          
                            vertexList.Add(new Vertex(destinationVertex));
                        }

                        Edge edge = new(vertexList.Find(x => x.name == originVertex), vertexList.Find(x => x.name == destinationVertex), Int32.Parse(edgeComponents[2]));
                        edgeList.Add(edge);
                    }                    
                }
            }

            for (int i = 1; i <= numberOfVertices; i++) // This step is to account for vertices that are not part of an edge.
            {
                if (!vertexList.Exists(x => x.name == i))
                {
                    vertexList.Add(new Vertex(i));
                }
            }

            return new Tuple<List<Edge>, List<Vertex>>(edgeList, vertexList);
        }
    }
}
