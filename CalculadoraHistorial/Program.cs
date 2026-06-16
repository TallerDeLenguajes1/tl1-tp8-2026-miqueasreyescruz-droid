using EspacioCalculadora;

Calculadora MiCalculadora = new Calculadora();

float num = 0;
string selector = "";
bool verificador = true;

Console.WriteLine("--- Calculadora ---");
do
{
    Console.WriteLine("------ MENU ------");
    Console.WriteLine("1. SUMA");
    Console.WriteLine("2. RESTA");
    Console.WriteLine("3. MILTIPLICACION");
    Console.WriteLine("4. DIVISION");
    Console.WriteLine("5. RESULTADO");
    Console.WriteLine("------------------");

    selector = Console.ReadLine();
    if (selector != "1" && selector != "2" && selector != "3" && selector != "4" && selector != "5")
    {
        Console.WriteLine("-> ERROR: opcion no valida, ingrese nuevamente:");
    }
    else
    {
        bool validarNum = false;

        while(!validarNum)
        {
            Console.WriteLine("-> Ingrese el numero: ");
            validarNum = float.TryParse(Console.ReadLine(), out num);
            if (!validarNum) Console.WriteLine("ERROR: valor invalido ingresado");
        }

        switch (selector)
        {
            case "1":
                MiCalculadora.Sumar(num);
                break;
            case "2":
                MiCalculadora.Restar(num);
                break;
            case "3":
                MiCalculadora.Multiplicar(num);
                break;
            case "4":
                MiCalculadora.Dividir(num);
                break;
            case "5":
                Console.WriteLine("Resultado: " + MiCalculadora.Resultado);
                break;
            default:
                
                break;
        }
    }

    Console.WriteLine("------------------");

    do
    {
        Console.WriteLine("-> Desea realizar otra operacion? (S/N)");
        selector = Console.ReadLine().ToUpper();
    } while (selector != "S" && selector != "N");

    if (selector == "N")
    {
        verificador = false;
        Console.WriteLine("Resultado final: " + MiCalculadora.Resultado);
        Console.WriteLine("Saliendo...");
    }
} while (verificador);
