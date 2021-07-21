using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public Tuple<List<Edge>, List<Vertex>> GetGraphFromFile()
        {
            List<Edge> edgeList = new();
            List<string> vertexStrings = new();
            List<Vertex> vertexList = new();

            using StreamReader sr = new(filePath);
            {                
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] edgeComponents = line.Split(" ");

                    if (edgeComponents.Length == 3) // The first line of the input data only has 2 numbers, n and m and does not contain an edge. We want to ignore it.
                    {
                        if (vertexStrings.Contains(edgeComponents[0]) == false)
                        {
                            vertexStrings.Add(edgeComponents[0]);
                            Vertex newVertex = new Vertex(edgeComponents[0]);
                            vertexList.Add(newVertex);
                        }
                        if (vertexStrings.Contains(edgeComponents[1]) == false)
                        {
                            vertexStrings.Add(edgeComponents[1]);
                            Vertex newVertex = new Vertex(edgeComponents[1]);
                            vertexList.Add(newVertex);
                        }

                        Edge edge = new(vertexList.Find(x => x.name == edgeComponents[0]), vertexList.Find(x => x.name == edgeComponents[1]), Int32.Parse(edgeComponents[2]));
                        edgeList.Add(edge);
                    }                    
                }
            }
            return new Tuple<List<Edge>, List<Vertex>>(edgeList, vertexList);
        }
    }
}
