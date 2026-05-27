namespace CalculadoraSOLID.Interfaces

// Interfaz del servicio principal de czlculo  de la calcu
{
    public interface ICalculadoraService
    {
        double Calcular(double numero1, double numero2, IOperacion operacion);
    }
}