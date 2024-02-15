using System;
class Dijkstra
{

    public static void Main(string[] args) 
    { 
        Random rand = new Random(); 
        int V = rand.Next(5, 10);  
        int[,] matrice = new int[V, V];
        for (int i = 0; i < V; i++) 
        { 
            for (int j = i+1; j < V; j++) 
            { 
                matrice[i, j] = rand.Next(0, 10); 
            } 
        } 
        for (int i = 0; i < V; i++)
        {
            for (int j = i + 1; j < V; j++)
            {
                matrice[j, i] = matrice[i, j];
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
                Console.Write(matrice[i, j] + " ");
            }
            Console.WriteLine();
        }

        int src = 0;
        do
        {
            Console.WriteLine("Inserire il nodo di partenza: ");
            src = int.Parse(Console.ReadLine());
        } while (src > V);
        
        int dest = 0;
        do
        {
            Console.WriteLine("Inserire il nodo di destinazione: ");
            dest = int.Parse(Console.ReadLine());
        } while (dest > V - 1);

        //DijkstraAlgo(matrice, src, V, dest); 
    } 
}