using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== COLA FIFO EN C# ===");
        Console.WriteLine("Ingresa números (positivos). -9999 para terminar.\n");

        Queue<int> cola = new Queue<int>();

        while (true)
        {
            Console.Write("Número: ");
            string entrada = Console.ReadLine();

            // Reemplazado int.Parse por TryParse para evitar el crash
            if (!int.TryParse(entrada, out int num))
            {
                Console.WriteLine("Entrada inválida, ingresa un número.");
                continue;
            }

            if (num == -9999) break;
            if (num < 0)
            {
                Console.WriteLine("Solo positivos, por favor.");
                continue;
            }

            cola.Enqueue(num);
            Console.WriteLine("Añadido: " + num);
        }

        Console.WriteLine("\nCola inicial:");
        MostrarCola(cola);

        // Insertar algo más
        Console.WriteLine("\nInsertando 99 y 88:");
        cola.Enqueue(99);
        cola.Enqueue(88);
        MostrarCola(cola);

        // Quitar del frente
        Console.WriteLine("\nQuitando del frente:");
        if (cola.Count > 0)
        {
            int sacado = cola.Dequeue();
            Console.WriteLine("Sacado: " + sacado);
        }
        MostrarCola(cola);

        // Balking: buscar y eliminar un valor
        Console.Write("\nValor a eliminar (balkval): ");
        string entradaBalk = Console.ReadLine();

        if (!int.TryParse(entradaBalk, out int valorABuscar))
        {
            Console.WriteLine("Valor inválido, saltando balkval.");
        }
        else
        {
            List<int> temp = new List<int>();
            bool eliminado = false;

            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                if (actual == valorABuscar && !eliminado)
                {
                    eliminado = true;
                    Console.WriteLine("Eliminado: " + actual);
                }
                else
                {
                    temp.Add(actual);
                }
            }

            if (!eliminado) Console.WriteLine("Valor no encontrado.");

            foreach (int x in temp)
                cola.Enqueue(x);
        }

        Console.WriteLine("\nCola después de balking:");
        MostrarCola(cola);

        // Opcional: eliminar por posición
        Console.Write("\nPosición a eliminar (1 para el primero): ");
        string entradaPos = Console.ReadLine();

        if (!int.TryParse(entradaPos, out int pos) || pos < 1 || pos > cola.Count)
        {
            Console.WriteLine("Posición inválida, saltando balkpos.");
        }
        else
        {
            List<int> temp2 = new List<int>();
            int contador = 1;

            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                if (contador != pos)
                    temp2.Add(actual);
                else
                    Console.WriteLine($"Eliminado (posición {pos}): {actual}");
                contador++;
            }

            foreach (int x in temp2)
                cola.Enqueue(x);
        }

        Console.WriteLine("\nCola después de eliminar por posición:");
        MostrarCola(cola);

        // Opcional: fusionar con otra cola
        Console.WriteLine("\nCreando cola 2 con 100, 200, 300");
        Queue<int> cola2 = new Queue<int>();
        cola2.Enqueue(100);
        cola2.Enqueue(200);
        cola2.Enqueue(300);

        Console.WriteLine("Cola 2:");
        MostrarCola(cola2);

        Console.WriteLine("\nFusionando colas...");
        while (cola2.Count > 0)
            cola.Enqueue(cola2.Dequeue());

        Console.WriteLine("Cola final:");
        MostrarCola(cola);

        Console.WriteLine("\n=== FIN ===");
        Console.ReadKey();
    }

    static void MostrarCola(Queue<int> q)
    {
        if (q.Count == 0)
        {
            Console.WriteLine("Cola vacía");
            return;
        }

        Console.Write("Frente -> ");
        foreach (int x in q)
            Console.Write($"[{x}] ");
        Console.WriteLine("<- Final");
    }
}