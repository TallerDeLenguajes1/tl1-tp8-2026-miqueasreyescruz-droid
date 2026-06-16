namespace ToDo;

public class Tarea
{
    private int _tareaID;
    private string _descripcion;
    private int _duracion;

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
    private List<Tarea> _listarealizadas = new List<Tarea>();
    private int _inicialID = 1000;

    public int InicialID { get => _inicialID; }

    public bool AgregarTarea(string descripcion,int duracion)
    {
        if (duracion < 10 || duracion > 100) return false;
    
        Tarea NuevaTarea = new Tarea(_inicialID,descripcion,duracion);
        _listapendientes.Add(NuevaTarea);
        _inicialID++; 

        return true;
    }

    public IReadOnlyList<Tarea> Pendientes
    {
        get => _listapendientes.AsReadOnly();
    }

    public IReadOnlyCollection<Tarea> Realizadas
    {
       get => _listarealizadas.AsReadOnly();
    }

    public List<Tarea> BuscarCoincidencia (string clave)
    {
        List<Tarea> coincidencias = new List<Tarea>();

        foreach (Tarea tarea in _listapendientes)
        {
            if (tarea.Descripcion.Contains(clave, StringComparison.OrdinalIgnoreCase)) // StringComparison.OrdinalIgnoreCase Para que ignore si es Mayusc o Minusc
            {
                coincidencias.Add(tarea);
            }
        }

        return coincidencias;
    }

    public bool MarcarRealizada (int ID)
    {
        Tarea tareaEncontrada = _listapendientes.Find(t => t.TareaID == ID);

        if (tareaEncontrada == null) return false;

        _listarealizadas.Add(tareaEncontrada);
        _listapendientes.Remove(tareaEncontrada);

        return true;
    }
} 