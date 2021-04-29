using System;
using System.Collections.Generic;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 6);

            graph.ShowConnections();
        }
    }

    public class Graph
    {
        public Graph()
        {
            this.Adjacents = new Dictionary<int, List<int>>();
            this.VertexCount = 0;
        }

        public int VertexCount { get; set; }
        public Dictionary<int, List<int>> Adjacents { get; set; }

        public void AddVertex(int value)
        {
            this.Adjacents.Add(value, new List<int>());
            this.VertexCount++;
        }

        public void AddEdge(int vertex1, int vertex2)
        {
            if (!this.Adjacents.ContainsKey(vertex1))
            {
                throw new ArgumentException();
            }

            if (!this.Adjacents.ContainsKey(vertex2))
            {
                throw new ArgumentException();
            }

            this.Adjacents[vertex1].Add(vertex2);
            this.Adjacents[vertex2].Add(vertex1);
        }

        /*
         
            Only for test

         */
        public void ShowConnections()
        {
            foreach (var adjacent in this.Adjacents)
            {
                Console.WriteLine($"{adjacent.Key} --> {string.Join(" ", adjacent.Value)}");
            }
        }
    }
}
