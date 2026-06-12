namespace ToDo;

public class Tarea
{
    private int _tareaID;
    private string _descripcion;
    int _duracion;

    public int TareaID { get => _tareaID; }
    public string Descripcion { get => _descripcion; set => _descripcion = value; }
    public int Duracion { get => _duracion; set => _duracion = value; }

    public Tarea(int tareaID, string descripcion, int duracion)
    {
        this._tareaID = tareaID;
        this._descripcion = descripcion;
        this._duracion = duracion;
    }
}

public class GestorTareas
{
    private List<Tarea> _listapendientes = new List<Tarea>();
    private int _inicialID = 1000;

    public List<Tarea> Listapendientes { get => _listapendientes; }
    public int InicialID { get => _inicialID; }

    public bool AgregarTarea(string descripcion,int duracion)
    {
        bool exitoso = true;

        if (duracion > 10 && duracion < 100)
        {
            Tarea NuevaTarea = new Tarea(_inicialID,descripcion,duracion);
            Listapendientes.Add(NuevaTarea);
            _inicialID++;    
        }
        else
        {
            exitoso = false;
        }

        return exitoso;
    }
} 