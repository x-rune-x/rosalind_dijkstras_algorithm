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

        public List<Edge> GetGraphFromFile()
        {
            List<Edge> edgeList = new();

            using StreamReader sr = new(filePath);
            {                
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] edgeComponents = line.Split(" ");

                    if (edgeComponents.Length == 3) // The first line of the input data only has 2 numbers, n and m and does not contain an edge. We want to ignore it.
                    {
                        Edge edge = new(edgeComponents[0], edgeComponents[1], Int32.Parse(edgeComponents[2]));
                        edgeList.Add(edge);
                    }                    
                }
            }
            return edgeList;
        }
    }
}
