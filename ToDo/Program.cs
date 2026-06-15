using ToDo;

string selector;

GestorTareas Gestor = new GestorTareas();

Console.WriteLine("_ _ _ _GESTOR DE TAREAS 2.0_ _ _ _");

do
{
    MostrarMenu();

    do
    {
        selector = Console.ReadLine();
    } while (selector != "1" && selector != "2" && selector != "3" && selector != "4" && selector != "5");

    switch (selector)
    {
        case "1":
            AgregarTarea();
            break;
        case "2":
            break;
        case "3":
            break;
        case "4":
            ConsultarLista();
            break;
        case "5":
            break;
    }

    if (selector != "5")
    {
        Console.WriteLine("--------------------------------------");
        Console.Write("-> Desea realizar otra tarea? Y/N: ");
        selector = Console.ReadLine().ToUpper();
        Console.WriteLine("--------------------------------------");    
    }
    else
    {
        selector = "N";
    }
    
} while (selector == "Y");

Console.WriteLine("Saliendo...");

// Funciones

void MostrarMenu ()
{
    Console.WriteLine("_______________MENU_______________");
    Console.WriteLine("1. AGREGAR TAREA");
    Console.WriteLine("2. MARCAR TAREA REALIZADA");
    Console.WriteLine("3. BUSCAR TAREA");
    Console.WriteLine("4. MOSTRAR TAREAS");
    Console.WriteLine("5. SALIR");
    Console.WriteLine("__________________________________");
}

void MostrarLista (IReadOnlyCollection<Tarea> Lista)
{
    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
    foreach (Tarea tarea in Lista)
    {
        Console.WriteLine($"ID: {tarea.TareaID}");
        Console.WriteLine($"Descripcion: {tarea.Descripcion}");
        Console.WriteLine($"Duracion: {tarea.Duracion}");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
    }
}

void ConsultarLista()
{
    IReadOnlyCollection<Tarea> ListaConsultada;
    string selector;

    Console.WriteLine("-> Que lista de tarea quiere ver? 1. Pendientes / 2.Realizadas");

    do
    {
        selector = Console.ReadLine();
    } while (selector != "1" && selector != "2");

    if (selector == "1")
    {
        ListaConsultada = Gestor.Pendientes;

        if (!ListaConsultada.Any())
        {
            Console.WriteLine("-> Lista de tareas pendientes vacia!");
        }
        else
        {
            Console.WriteLine("-> Mostrando lista de tareas pendientes: ");
            MostrarLista(ListaConsultada);
        }
    }
    else
    {
        ListaConsultada = Gestor.Realizadas;

        if (!ListaConsultada.Any())
        {
            Console.WriteLine("-> Lista de tareas realizadas vacia!");
        }
        else
        {
            Console.WriteLine("-> Mostrando lista de tareas pendientes: ");
            MostrarLista(ListaConsultada);
        }
    }
}

void AgregarTarea()
{
    int duracion = 0;
    string descripcion;
    bool validarNum;

    Console.WriteLine("Creando Tarea...");
    Console.Write("-> Ingrese una descripcion de la tarea: ");
    descripcion = Console.ReadLine();

    do
    {
        validarNum = true;

        Console.Write("-> Ingrese la duracion de la tarea en horas (10-100): ");
        validarNum = int.TryParse(Console.ReadLine(), out duracion);
 
        if (!validarNum) Console.WriteLine("ERROR: valor invalido ingresado");
        
        if(validarNum && (duracion < 10 || duracion > 100)) 
        {
            Console.WriteLine("ADVERTENCIA: La duracion debe ser entre 10 y 100, intente nuevamente");
            validarNum = false;
        }
    } while (!validarNum);

    if(!Gestor.AgregarTarea(descripcion,duracion)) Console.WriteLine("ERROR: no se pudo agregar la tarea");
    else Console.WriteLine("Tarea agregada con exito!");
}