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
            Console.WriteLine("nВыберите способ создания графа:\n1. Загрузить из файла\n2. Заполнить вручную");
            var creationMethodInput = Console.ReadLine();

            Graph<string> graph;

            if (creationMethodInput == "1")
            {
                //Console.Write("Введите путь к файлу: ");
                var filePath = @"C:\Users\PC\Desktop\C#\tgraph1\Graph.txt";
                graph = new Graph<string>(filePath);
            }
            else
            {
                Console.Write("Выберите тип графа:\n1. Ориентированный\n2. Неориентированный\nВведите номер: ");
                var graphTypeInput = Console.ReadLine();
                bool isDirected = graphTypeInput == "1";

                graph = new Graph<string>(isDirected); // Создаем граф в зависимости от выбора пользователя
            }

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
                Console.WriteLine("7. узнать степень вершины");
                Console.WriteLine("8. для вершины найти не смежные с ней вершины");
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

                    case "7":
                        Console.Write("Введите вершину для получения её степени: ");
                        var vertexInput = Console.ReadLine();
                        try
                        {
                            int degree = graph.GetVertexDegree(vertexInput);
                            Console.WriteLine($"Степень вершины {vertexInput}: {degree}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        return;
                    case "8":
                        Console.Write("Введите вершину для получения не смежных вершин: ");
                        var vertexInp = Console.ReadLine();

                        try
                        {
                            var nonAdjacentVertices = graph.GetNonAdjacentVertices(vertexInp);
                            Console.WriteLine($"Вершины, не смежные с {vertexInp}: {string.Join(", ", nonAdjacentVertices)}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
            
            // Сохранение в файл
            graph.SaveToFile(@"C:\Users\PC\Desktop\C#\tgraph1\Graph.txt");
        }
    }
}
