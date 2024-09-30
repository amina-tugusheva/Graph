using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gtaph0
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();

            // Добавление вершин
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");

            // Добавление рёбер
            graph.AddEdge("A", "B", 2.5);
            graph.AddEdge("A", "C", 3.0);
            graph.AddEdge("B", "C", 1.5);

            Console.WriteLine("Вывод списка смежности:");
            graph.PrintAdjacencyList();

            // Удаление ребра
            graph.RemoveEdge("A", "C");

            Console.WriteLine("Вывод списка смежности после удаления ребра:");
            graph.PrintAdjacencyList();

            //добавление ребра 
            graph.AddEdge("C", "A", 4.0);
            Console.WriteLine("Вывод списка смежности после добавления нового ребра:");
            graph.PrintAdjacencyList();

            // Удаление вершины
            graph.RemoveVertex("C");

            Console.WriteLine("Вывод списка смежности после удаления вершины:");
            graph.PrintAdjacencyList();

            // Сохранение в файл
            graph.SaveToFile("graph.txt");

            // Загрузка из файла
            Graph<string> loadedGraph = new Graph<string>("graph.txt");
            loadedGraph.PrintAdjacencyList();
        }
    }
}
/*
A: B 2.5, C 3.0
B: A 2.5
C: A 3.0

graph2

X: Y 1.0
Y: X 1.0, Z 4.0
Z: Y 4.0

graph3

P: P 5.0
Q: R 2.0
R: Q 2.0
*/