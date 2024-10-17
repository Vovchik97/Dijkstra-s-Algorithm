using System;
using System.Collections.Generic;

namespace AiSD_Lab_5
{
    public class DijkstraAlgorithm
    {
       public static Dictionary<int, int> Dijkstra(Dictionary<int, Dictionary<int, int>> graph, int start)
       {
           Dictionary<int, int> dist = new Dictionary<int, int>();
           Dictionary<int, bool> visited = new Dictionary<int, bool>();

           foreach (int vertex in graph.Keys)
           {
               dist[vertex] = int.MaxValue;
               visited[vertex] = false;
           }

           dist[start] = 0;

           for (int count = 0; count < graph.Count - 1; count++)
           {
               int u = -1;

               // Вершина с минимальным расстоянием
               foreach (int v in graph.Keys)
               {
                   if (!visited[v] && (u == -1 || dist[v] < dist[u]))
                   {
                       u = v;
                   }
               }

               visited[u] = true;

               // Обновляем расстояние до соседних вершин
               foreach (KeyValuePair<int, int> entry in graph[u])
               {
                   int v = entry.Key;
                   int weight = entry.Value;

                   if (!visited[v] && dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                   {
                       dist[v] = dist[u] + weight;
                   }
               }
           }

           return dist;
       }

       public static void Main(string[] args)
       {
           Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>
       {
           {1, new Dictionary<int, int> {{2, 1500}, {3, 2000}, {4, 4000}}},
           {2, new Dictionary<int, int> {{1, 1500}, {3, 6500}, {4, 5300}, {6, 3500}}},
           {3, new Dictionary<int, int> {{1, 2000}, {2, 6500}, {4, 2500}, {5, 4200}, {7, 5400}}},
           {4, new Dictionary<int, int> {{1, 4000}, {2, 5300}, {3, 2500}, {6, 2800}, {7, 1500}}},
           {5, new Dictionary<int, int> {{3, 4200}, {7, 5100}, {9, 6700}}},
           {6, new Dictionary<int, int> {{2, 3500}, {4, 2800}, {7, 1500}, {8, 4900}}},
           {7, new Dictionary<int, int> {{3, 5400}, {4, 1500}, {5, 5100}, {6, 1500}, {8, 3800}, {9, 2900}}},
           {8, new Dictionary<int, int> {{6, 4900}, {7, 3800}, {9, 6700}}},
           {9, new Dictionary<int, int> {{5, 6700}, {7, 2900}, {8, 6700}}}
       };

           int start = 1;
           Dictionary<int, int> dist = Dijkstra(graph, start);

           Console.WriteLine($"Дистанция до вершины {start} ко всем остальным вершинам:");
           foreach (KeyValuePair<int, int> entry in dist)
           {
               Console.WriteLine($"Вершина {entry.Key}: {entry.Value}");
           }
       }
    }

}
