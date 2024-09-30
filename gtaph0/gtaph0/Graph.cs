using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gtaph0
{
    class Graph<T>
    {
        private Dictionary<T, List<(T, double)>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<T, List<(T, double)>>();
        }

        public Graph(string filePath)
        {
            adjacencyList = new Dictionary<T, List<(T, double)>>();
            LoadFromFile(filePath);
        }

        public Graph(Graph<T> other)
        {
            adjacencyList = new Dictionary<T, List<(T, double)>>();
            foreach (var vertex in other.adjacencyList)
            {
                adjacencyList[vertex.Key] = new List<(T, double)>(vertex.Value);
            }
        }

        public void AddVertex(T vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<(T, double)>();
            }
            else
            {
                Console.WriteLine("Вершина уже существует.");
            }
        }

        public void AddEdge(T from, T to, double weight = 1.0)
        {
            if (!adjacencyList.ContainsKey(from) || !adjacencyList.ContainsKey(to))
            {
                Console.WriteLine("Одна или обе вершины не существуют");
                return;
            }

            adjacencyList[from].Add((to, weight));
        }

        public void RemoveVertex(T vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                Console.WriteLine("Вершина не существует");
                return;
            }

            adjacencyList.Remove(vertex);
            foreach (var v in adjacencyList.Keys)
            {
                adjacencyList[v].RemoveAll(e => e.Item1.Equals(vertex));
            }
        }

        public void RemoveEdge(T from, T to)
        {
            if (!adjacencyList.ContainsKey(from))
            {
                Console.WriteLine("Первая вершина не существует");
                return;
            }

            adjacencyList[from].RemoveAll(e => e.Item1.Equals(to));
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var vertex in adjacencyList)
                {
                    writer.WriteLine($"{vertex.Key}: {string.Join(", ", vertex.Value)}");
                }
            }
        }

        private void LoadFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(/*@"C:\Users\tugushevaai\Desktop\gtaph0\graph.txt"*/filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(':');
                    var vertex = (T)Convert.ChangeType(parts[0].Trim(), typeof(T));
                    var edges = parts[1].Split(',');

                    foreach (var edge in edges)
                    {
                        var edgeParts = edge.Trim().Split(' ');
                        var toVertex = (T)Convert.ChangeType(edgeParts[0], typeof(T));
                        double weight = edgeParts.Length > 1 ? Convert.ToDouble(edgeParts[1]) : 1.0;

                        AddVertex(vertex);
                        AddVertex(toVertex);
                        AddEdge(vertex, toVertex, weight);
                    }
                }
            }
        }

        public void PrintAdjacencyList()
        {
            foreach (var vertex in adjacencyList)
            {
                Console.Write($"{vertex.Key}: ");
                foreach (var edge in vertex.Value)
                {
                    Console.Write($"({edge.Item1}, {edge.Item2}) ");
                }
                Console.WriteLine();
            }
        }
    }
}
