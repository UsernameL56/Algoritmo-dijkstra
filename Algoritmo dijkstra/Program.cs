using System;
class Dijkstra
{
    private static int MinDistance(int[] dist, bool[] visited, int V) 
    { 
        int min = int.MaxValue, minIndex = -1; 
        for (int v = 0; v < V; ++v) 
        { 
            if (visited[v] == false && dist[v] <= min) 
            { 
                min = dist[v]; minIndex = v; 
            } 
        } 
        return minIndex; 
    }
    private static void PrintPath(int[] parent, int j) 
    { 
        if (parent[j] == -1) return; 
        PrintPath(parent, parent[j]); 
        Console.Write((char)('A' + j) + " "); 
    }
    private static void PrintSolution(int[] dist, int[] parent, int src, int dest) 
    { 
        Console.Write("Percorso minimo da " + (char)('A' + src) + " a " + (char)('A' + dest) + ": "); 
        PrintPath(parent, dest); Console.WriteLine("\nDistanza: " + dist[dest]); 
    }
    public static void DijkstraAlgo(int[,] graph, int src, int V, int dest) 
    { 
        int[] dist = new int[V]; 
        bool[] visited = new bool[V]; 
        int[] parent = new int[V]; 
        for (int i = 0; i < V; ++i) 
        { 
            parent[src] = -1; 
            dist[i] = int.MaxValue; 
            visited[i] = false; 
        } 
        dist[src] = 0; 
        for (int count = 0; count < V - 1; ++count) 
        { 
            int u = MinDistance(dist, visited, V); 
            visited[u] = true; 
            for (int v = 0; v < V; ++v) 
            { 
                if (!visited[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v]) 
                { 
                    dist[v] = dist[u] + graph[u, v]; parent[v] = u; 
                } 
            } 
        } 
        PrintSolution(dist, parent, src, dest); 
    }
    public static void Main(string[] args) 
    { 
        Random rand = new Random(); 
        int V = rand.Next(5, 10);  
        int[,] graph = new int[V, V];
        for (int i = 0; i < V; i++) 
        { 
            for (int j = i+1; j < V; j++) 
            { 
                graph[i, j] = rand.Next(0, 10); 
            } 
        } 
        for (int i = 0; i < V; i++)
        {
            for (int j = i + 1; j < V; j++)
            {
                graph[j, i] = graph[i, j];
            }
        }
        Console.WriteLine("Grafo generato casualmente:");
        Console.Write(" " + " ");
        for(int i = 0; i < V; i++)
        {
            Console.Write((char)('A' + i) + " ");
            
        }
        Console.WriteLine();

        for(int i = 0; i < V; i++)
        {
            Console.Write((char)('A' + i) + " ");
            for(int j = 0; j < V; j++)
            {
                Console.Write(graph[i, j] + " ");
            }
            Console.WriteLine();
        }

        int src = 0;
        do
        {
            Console.WriteLine("Inserire il nodo di partenza: ");
            src = int.Parse(Console.ReadLine());
        } while (src > V-1);
        
        int dest = 0;
        do
        {
            Console.WriteLine("Inserire il nodo di destinazione: ");
            dest = int.Parse(Console.ReadLine());
        } while (dest > V - 1);

        DijkstraAlgo(graph, src, V, dest); 
    } 
}