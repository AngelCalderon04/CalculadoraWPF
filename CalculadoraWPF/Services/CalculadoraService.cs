using CalculadoraSOLID.Interfaces;

namespace CalculadoraSOLID.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public double Calcular(double numero1, double numero2, IOperacion operacion)
        {
            return operacion.Calcular(numero1, numero2);
        }
    }
}