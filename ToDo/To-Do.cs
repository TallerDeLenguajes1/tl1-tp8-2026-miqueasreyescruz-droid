namespace ToDo;

public class Tarea
{
    int tareaID;
    string descripcion;
    int duracion;

    public int TareaID { get => tareaID; set => tareaID = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }
}