using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine(" Ingrese una opción:");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("1. Ejercicio 1 - Suma de serie de números");
            Console.WriteLine("2. Ejercicio 2 - Filtrar números de una lista");
            Console.WriteLine("3. Ejercicio 3 - Agrupar elementos similares en una lista");
            Console.WriteLine("4. Ejercicio 4 - Administrador de inventario");
            Console.WriteLine("5. Salir");
            Console.Write("Su opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Ejercicio1();
                    break;
                case 2:
                    Ejercicio2();
                    break;
                case 3:
                    Ejercicio3();
                    break;
                case 4:
                    Ejercicio4();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, ingrese una opción válida.");
                    break;
            }
        } while (opcion != 5);
    }

    static void Ejercicio1()
    {
        Console.Write("Ingrese el número base: ");
        int numero = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese la cantidad de términos: ");
        int terminos = Convert.ToInt32(Console.ReadLine());

        int resultado = SumaSerie(numero, terminos);
        Console.WriteLine($"Resultado: {resultado}");
    }

    static int SumaSerie(int numero, int terminos)
    {
        int suma = 0;
        int valor = numero;

        for (int i = 0; i < terminos; i++)
        {
            suma += valor;
            valor = valor * 10 + numero;
        }

        return suma;
    }

    static void Ejercicio2()
    {
        Console.Write("Ingrese los números separados por comas: ");
        string entrada = Console.ReadLine();
        List<int> numeros = entrada.Split(',').Select(int.Parse).ToList();

        List<int> resultado = FiltrarNumeros(numeros);
        Console.WriteLine($"Resultado: [{string.Join(", ", resultado)}]");
    }

    static List<int> FiltrarNumeros(List<int> numeros)
    {
        List<int> salida = new List<int>();

        foreach (int num in numeros)
        {
            if (num % 5 == 0 && num <= 600)
            {
                salida.Add(num);
            }
            else if (num > 1000)
            {
                break;
            }
        }

        return salida;
    }

    static void Ejercicio3()
    {
        Console.Write("Ingrese los números separados por comas: ");
        string entrada = Console.ReadLine();
        List<int> lista = entrada.Split(',').Select(int.Parse).ToList();

        List<List<int>> resultado = AgruparElementos(lista);
        Console.WriteLine("Resultado:");
        foreach (var grupo in resultado)
        {
            Console.WriteLine($"[{string.Join(", ", grupo)}]");
        }
    }

    static List<List<int>> AgruparElementos(List<int> lista)
    {
        var grupos = lista.GroupBy(x => x).Select(g => g.ToList()).ToList();
        return grupos;
    }

    static void Ejercicio4()
    {
        Dictionary<string, List<string>> inventario = new Dictionary<string, List<string>>();
        Dictionary<string, List<int>> stock = new Dictionary<string, List<int>>();

        int opcion;
        do
        {
            Console.WriteLine("Administrador de inventario. Ingrese una opción:");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Ver inventario");
            Console.WriteLine("3. Salir");
            Console.Write("Su opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarProducto(inventario, stock);
                    break;
                case 2:
                    VerInventario(inventario, stock);
                    break;
                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, ingrese una opción válida.");
                    break;
            }
        } while (opcion != 3);
    }

    static void RegistrarProducto(Dictionary<string, List<string>> inventario, Dictionary<string, List<int>> stock)
    {
        Console.WriteLine("Ingrese el nombre del producto:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese la cantidad:");
        int cantidad = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el grupo (dairy, cleaning, grain):");
        string grupo = Console.ReadLine();

        if (!inventario.ContainsKey(grupo))
        {
            inventario.Add(grupo, new List<string>());
            stock.Add(grupo, new List<int>());
        }

        if (inventario[grupo].Contains(nombre))
        {
            int index = inventario[grupo].IndexOf(nombre);
            stock[grupo][index] += cantidad;
        }
        else
        {
            inventario[grupo].Add(nombre);
            stock[grupo].Add(cantidad);
        }

        Console.WriteLine($"Producto {nombre} registrado con éxito en el grupo {grupo}.");
    }

    static void VerInventario(Dictionary<string, List<string>> inventario, Dictionary<string, List<int>> stock)
    {
        Console.WriteLine("Inventario:");
        foreach (var grupo in inventario)
        {
            Console.WriteLine($"Grupo: {grupo.Key}");
            for (int i = 0; i < grupo.Value.Count; i++)
            {
                Console.WriteLine($"- {grupo.Value[i]}: {stock[grupo.Key][i]} unidades");
            }
            Console.WriteLine();
        }
    }
}