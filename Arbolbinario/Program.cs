using System;

class Nodo
{
    public int Dato;
    public Nodo? Izquierdo;   // Nullable para evitar errores
    public Nodo? Derecho;

    public Nodo(int dato)
    {
        Dato = dato;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBinario
{
    public Nodo? Raiz;

    public ArbolBinario()
    {
        Raiz = null;
    }

    // Inserción de nodo
    public void Insertar(int dato)
    {
        Raiz = InsertarRec(Raiz, dato);
    }

    private Nodo InsertarRec(Nodo? nodo, int dato)
    {
        if (nodo == null)
            return new Nodo(dato);

        if (dato < nodo.Dato)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, dato);
        else if (dato > nodo.Dato)
            nodo.Derecho = InsertarRec(nodo.Derecho, dato);

        return nodo;
    }

    // Recorridos
    public void InOrden(Nodo? nodo)
    {
        if (nodo != null)
        {
            InOrden(nodo.Izquierdo);
            Console.Write(nodo.Dato + " ");
            InOrden(nodo.Derecho);
        }
    }

    public void PreOrden(Nodo? nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Dato + " ");
            PreOrden(nodo.Izquierdo);
            PreOrden(nodo.Derecho);
        }
    }

    public void PostOrden(Nodo? nodo)
    {
        if (nodo != null)
        {
            PostOrden(nodo.Izquierdo);
            PostOrden(nodo.Derecho);
            Console.Write(nodo.Dato + " ");
        }
    }

    // Búsqueda
    public bool Buscar(int dato)
    {
        return BuscarRec(Raiz, dato);
    }

    private bool BuscarRec(Nodo? nodo, int dato)
    {
        if (nodo == null) return false;
        if (dato == nodo.Dato) return true;
        if (dato < nodo.Dato) return BuscarRec(nodo.Izquierdo, dato);
        else return BuscarRec(nodo.Derecho, dato);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion;

        do
        {
            Console.WriteLine("\n=== MENU ARBOL BINARIO ===");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Recorrido InOrden");
            Console.WriteLine("3. Recorrido PreOrden");
            Console.WriteLine("4. Recorrido PostOrden");
            Console.WriteLine("5. Buscar elemento");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            
            bool exito = int.TryParse(Console.ReadLine(), out opcion);
            if (!exito)
            {
                Console.WriteLine("Ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese un número: ");
                    if (int.TryParse(Console.ReadLine(), out int dato))
                        arbol.Insertar(dato);
                    else
                        Console.WriteLine("Número no válido.");
                    break;

                case 2:
                    Console.WriteLine("Recorrido InOrden:");
                    arbol.InOrden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine("Recorrido PreOrden:");
                    arbol.PreOrden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Recorrido PostOrden:");
                    arbol.PostOrden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 5:
                    Console.Write("Ingrese el número a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out int buscar))
                    {
                        if (arbol.Buscar(buscar))
                            Console.WriteLine("Elemento encontrado!");
                        else
                            Console.WriteLine("Elemento no encontrado!");
                    }
                    else
                        Console.WriteLine("Número no válido.");
                    break;

                case 6:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida!");
                    break;
            }

        } while (opcion != 6);
    }
}


