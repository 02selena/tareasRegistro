
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear catálogo de revistas
        List<string> catalogo = new List<string>()
        {
            "National Geographic",
            "Yanbal",
            "El Universo",
            "Ciencias Economicas",
            "Natura",
            "Viztazo",
            "Vogue",
            "Azzorti",
            "Avon",
            "Salud y Bienestar"
        };

        int opcion = 0;

        do
        {
            // Menú interactivo
            Console.WriteLine("\n--- Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Mostrar todos los títulos");
            Console.WriteLine("3. Salir");
            Console.Write("Ingrese una opción: ");

            // Leer opción del usuario
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida, intente de nuevo.");
                continue;
            }


            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el título de la revista a buscar: ");
                   string titulo = Console.ReadLine()!;
                   bool encontrado = BuscarRevista(catalogo, titulo);

                    if (encontrado)
                        Console.WriteLine("Encontrado");
                    else
                        Console.WriteLine("No encontrado");
                    break;

                case 2:
                    Console.WriteLine("\n--- Lista de revistas ---");
                    foreach (string revista in catalogo)
                    {
                        Console.WriteLine(revista);
                    }
                    break;

                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }

        } while (opcion != 3);
    }

    // Método iterativo para buscar una revista
    static bool BuscarRevista(List<string> catalogo, string titulo)
    {
        foreach (string revista in catalogo)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}
