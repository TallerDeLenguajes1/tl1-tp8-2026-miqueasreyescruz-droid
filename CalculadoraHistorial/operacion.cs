namespace EspacioCalculadora;
public class Operacion
{
    private double _resultadoAnterior;
    private double _nuevoValor;
    private TipoOperacion _operacion;
    public Operacion(double _resultadoAnterior, double _nuevoValor, TipoOperacion _operacion)
    {
        this._resultadoAnterior = _resultadoAnterior;
        this._nuevoValor = _nuevoValor;
        this._operacion = _operacion;
    }
    public double Resultado
    {
        get 
        {
            switch (_operacion)
            {
                case TipoOperacion.Suma:
                    return _resultadoAnterior + _nuevoValor;
                case TipoOperacion.Resta:
                    return _resultadoAnterior - _nuevoValor;
                case TipoOperacion.Multiplicacion:
                    return _resultadoAnterior * _nuevoValor;
                case TipoOperacion.Division:
                    if (_nuevoValor == 0) return _resultadoAnterior;
                    else return _resultadoAnterior / _nuevoValor; 
                case TipoOperacion.Limpiar:
                    return 0;
                default:
                    return _resultadoAnterior;
            }
        }
    }
    public double NuevoValor
    {
        get => _nuevoValor;
    }
}

public enum TipoOperacion
{
    Suma,
    Resta,
    Multiplicacion,
    Division,
    Limpiar
}