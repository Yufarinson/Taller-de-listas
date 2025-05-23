using Listas;

var doublyList = new DoublyLinkedList<string>();
var opc = "0";

do
{
    opc = Menu();
    Console.Clear(); 
    try 
    {
        switch (opc)
        {
            case "1": 
                Console.Write("Ingrese el dato a adicionar (la lista lo ordenará ascendentemente): ");
                var dataToAdd = Console.ReadLine();
                if (!string.IsNullOrEmpty(dataToAdd))
                {
                    doublyList.Add(dataToAdd);
                    Console.WriteLine($"'{dataToAdd}' adicionado. Lista actual: {doublyList.ShowForward()}");
                }
                else
                {
                    Console.WriteLine("No se ingresó ningún dato.");
                }
                break;

            case "2": 
                Console.WriteLine("Lista (hacia adelante):");
                Console.WriteLine(doublyList.ShowForward());
                break;

            case "3": 
                Console.WriteLine("Lista (hacia atrás):");
                Console.WriteLine(doublyList.ShowBackward());
                break;

            case "4": 
                doublyList.SortDescending();
                Console.WriteLine("Lista ordenada descendentemente.");
                Console.WriteLine(doublyList.ShowForward());
                break;

            case "5": 
                var modes = doublyList.GetModes();
                if (modes.Count > 0)
                {
                    Console.WriteLine("Moda(s): " + string.Join(", ", modes));
                }
                else
                {
                    Console.WriteLine("No hay moda(s) o la lista está vacía.");
                }
                break;

            case "6": 
                Console.WriteLine("Gráfico de ocurrencias:");
                Console.WriteLine(doublyList.ShowGraph());
                break;

            case "7": 
                Console.Write("Ingrese el dato a buscar: ");
                var dataToFind = Console.ReadLine();
                if (!string.IsNullOrEmpty(dataToFind))
                {
                    var exists = doublyList.Exists(dataToFind);
                    Console.WriteLine($"El dato '{dataToFind}' {(exists ? "SÍ" : "NO")} existe en la lista.");
                }
                else
                {
                    Console.WriteLine("No se ingresó ningún dato para buscar.");
                }
                break;

            case "8": 
                Console.Write("Ingrese el dato a eliminar (primera ocurrencia): ");
                var dataToRemoveOne = Console.ReadLine();
                if (!string.IsNullOrEmpty(dataToRemoveOne))
                {
                    if (doublyList.RemoveOne(dataToRemoveOne))
                    {
                        Console.WriteLine($"Primera ocurrencia de '{dataToRemoveOne}' eliminada.");
                    }
                    else
                    {
                        Console.WriteLine($"'{dataToRemoveOne}' no encontrado en la lista.");
                    }
                    Console.WriteLine($"Lista actual: {doublyList.ShowForward()}");
                }
                else
                {
                    Console.WriteLine("No se ingresó ningún dato para eliminar.");
                }
                break;

            case "9": 
                Console.Write("Ingrese el dato a eliminar (todas las ocurrencias): ");
                var dataToRemoveAll = Console.ReadLine();
                if (!string.IsNullOrEmpty(dataToRemoveAll))
                {
                    int removedCount = doublyList.RemoveAll(dataToRemoveAll);
                    if (removedCount > 0)
                    {
                        Console.WriteLine($"Se eliminaron {removedCount} ocurrencia(s) de '{dataToRemoveAll}'.");
                    }
                    else
                    {
                        Console.WriteLine($"'{dataToRemoveAll}' no encontrado en la lista.");
                    }
                    Console.WriteLine($"Lista actual: {doublyList.ShowForward()}");
                }
                else
                {
                    Console.WriteLine("No se ingresó ningún dato para eliminar.");
                }
                break;

            case "10": 
                doublyList.Clear();
                Console.WriteLine("Lista limpiada.");
                break;

            case "0":
                Console.WriteLine("Saliendo del programa...");
                break;

            default:
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocurrió un error: {ex.Message}");
    }
    if (opc != "0")
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

} while (opc != "0");

string Menu()
{
    Console.Clear();
    Console.WriteLine("========= MENÚ LISTA DOBLEMENTE LIGADA =========");
    Console.WriteLine("1. Adicionar elemento");
    Console.WriteLine("2. Mostrar lista hacia adelante");
    Console.WriteLine("3. Mostrar lista hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar la(s) moda(s)");
    Console.WriteLine("6. Mostrar gráfico de ocurrencias");
    Console.WriteLine("7. Verificar si un elemento existe");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("10. Limpiar lista");
    Console.WriteLine("0. Salir");
    Console.WriteLine("================================================");
    Console.Write("Elija una opción: ");
    return Console.ReadLine() ?? "0";
}