using ToDo;

int duracion = 0;
string selector, descripcion;
bool validarNum;

GestorTareas Gestor = new GestorTareas();

Console.WriteLine("___GESTOR DE TAREAS 2.0___");

do
{
    Console.WriteLine("Ingrese una descripcion de la tarea: ");
    descripcion = Console.ReadLine();

    do
    {
        validarNum = true;

        Console.WriteLine("-> Ingrese la duracion de la tarea en horas (10-100): ");
        validarNum = int.TryParse(Console.ReadLine(), out duracion);
 
        if (!validarNum) Console.WriteLine("ERROR: valor invalido ingresado");
        
        if(validarNum && (duracion < 10 || duracion > 100)) 
        {
            Console.WriteLine("ADVERTENCIA: La duracion debe ser entre 10 y 100, intente nuevamente");
            validarNum = false;
        }
    } while (!validarNum);
    
    if(!Gestor.AgregarTarea(descripcion,duracion)) Console.WriteLine("ERROR: no se pudo agregar la tarea");

    Console.WriteLine("-> Desea guardar otra tarea? Y/N");
    selector = Console.ReadLine().ToUpper();
} while (selector == "Y");

Console.WriteLine("Saliendo...");