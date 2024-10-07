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
            Console.Write("Выберите тип графа:\n1. Ориентированный\n2. Неориентированный\nВведите номер: ");
            var graphTypeInput = Console.ReadLine();
            bool isDirected = graphTypeInput == "1";

            var graph = new Graph<string>(isDirected); // Создаем граф в зависимости от выбора пользователя
            
            // Добавление вершин
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");

            // Добавление рёбер
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C", 3.0);
            graph.AddEdge("B", "C", 9.0);
            graph.AddEdge("A", "D", 7.0);


            Console.WriteLine("Список смежности графа:");// Вывод списка смежности
            graph.PrintAdjacencyList();


            graph.RemoveEdge("A", "B");
            Console.WriteLine("после удаления ребра АВ:");// Удаление ребра
            
            graph.PrintAdjacencyList();

            //минимальный консольный интерфейс
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Добавить вершину");
                Console.WriteLine("2. Удалить вершину");
                Console.WriteLine("3. Добавить ребро");
                Console.WriteLine("4. Удалить ребро");
                Console.WriteLine("5. Показать список смежности");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите опцию: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Введите имя вершины: ");
                        var vertexToAdd = Console.ReadLine();
                        graph.AddVertex(vertexToAdd);
                        break;

                    case "2":
                        Console.Write("Введите имя вершины для удаления: ");
                        var vertexToRemove = Console.ReadLine();
                        graph.RemoveVertex(vertexToRemove);
                        break;

                    case "3":
                        Console.Write("Введите начальную вершину: ");
                        var fromVertex = Console.ReadLine();
                        Console.Write("Введите конечную вершину: ");
                        var toVertex = Console.ReadLine();
                        Console.Write("Введите вес (по умолчанию 1.0): ");
                        var weightInput = Console.ReadLine();
                        double weight = string.IsNullOrWhiteSpace(weightInput) ? 1.0 : Convert.ToDouble(weightInput);
                        graph.AddEdge(fromVertex, toVertex, weight);
                        break;

                    case "4":
                        Console.Write("Введите начальную вершину: ");
                        var fromEdge = Console.ReadLine();
                        Console.Write("Введите конечную вершину: ");
                        var toEdge = Console.ReadLine();
                        graph.RemoveEdge(fromEdge, toEdge);
                        break;

                    case "5":
                        Console.WriteLine("Список смежности:");
                        graph.PrintAdjacencyList();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, попробуйте снова.");
                        break;
                }
            }


            // Сохранение в файл
            graph.SaveToFile(@"C:\Users\PC\Desktop\C#\tgraph1\Graph.txt");

            // Загрузка из файла
            Graph<string> loadedGraph = new Graph<string>(@"C:\Users\PC\Desktop\C#\tgraph1\Graph.txt");
            loadedGraph.PrintAdjacencyList();
        }
    }
}
