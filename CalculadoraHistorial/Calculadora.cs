namespace EspacioCalculadora;

public class Calculadora
{
    private List<Operacion> _historial = new List<Operacion> ();
    private double dato;
    public double Resultado
    {
        get => dato;
    }
    public void Sumar(double termino)
    {
        Operacion Suma = new Operacion(dato,termino,TipoOperacion.Suma);
        _historial.Add(Suma);
        dato = Suma.Resultado;
    }
    public void Restar(double termino)
    {
        Operacion Resta = new Operacion(dato,termino,TipoOperacion.Resta);
        _historial.Add(Resta);
        dato = Resta.Resultado;
    }
    public void Multiplicar(double termino)
    {
        Operacion Multiplicar = new Operacion(dato,termino,TipoOperacion.Multiplicacion);
        _historial.Add(Multiplicar);
        dato = Multiplicar.Resultado;
    }
    public void Dividir(double termino)
    {
        Operacion Dividir = new Operacion(dato,termino,TipoOperacion.Division);
        _historial.Add(Dividir);
        dato = Dividir.Resultado;
    }
    public void Limpiar()
    {
        Operacion Limpiar = new Operacion(dato,0,TipoOperacion.Limpiar);
        _historial.Add(Limpiar);
    }
    public IReadOnlyList<Operacion> Historial
    {
        get => _historial.AsReadOnly();
    }
}