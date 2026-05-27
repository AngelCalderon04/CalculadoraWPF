using CalculadoraSOLID.Interfaces;

namespace CalculadoraSOLID.Operations
{
    public class Division : IOperacion
    {
        public double Calcular(double numero1, double numero2)
        {
            return numero1 / numero2;
        }
    }
}