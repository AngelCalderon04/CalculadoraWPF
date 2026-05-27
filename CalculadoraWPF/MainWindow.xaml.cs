using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalculadoraSOLID.Interfaces;
using CalculadoraSOLID.Operations;
using CalculadoraSOLID.Services;

namespace CalculadoraWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Instancia del servicio de calculadora
        CalculadoraService calculadora = new CalculadoraService();

        string operacion = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Evento para escribir numeros en pantalla
        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;

            if (txtPantalla.Text == "0")
            {
                txtPantalla.Text = boton.Content.ToString();
            }
            else
            {
                txtPantalla.Text += boton.Content.ToString();
            }
        }


        // Evento para agregar operadores matematicos
        private void Operador_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;

            txtPantalla.Text += boton.Content.ToString();
        }

        // Evento que realiza el calculo final
        private void BtnResultado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string expresion = txtPantalla.Text;

                string operador = "";

                if (expresion.Contains("+"))
                    operador = "+";

                else if (expresion.Contains("-"))
                    operador = "-";

                else if (expresion.Contains("*"))
                    operador = "*";

                else if (expresion.Contains("/"))
                    operador = "/";

                string[] partes = expresion.Split(char.Parse(operador));

                double numero1 = Convert.ToDouble(partes[0]);
                double numero2 = Convert.ToDouble(partes[1]);

                IOperacion operacion = null;

                switch (operador)
                {
                    case "+":
                        operacion = new Suma();
                        break;

                    case "-":
                        operacion = new Resta();
                        break;

                    case "*":
                        operacion = new Multiplicacion();
                        break;

                    case "/":
                        operacion = new Division();
                        break;
                }

                double resultado = calculadora.Calcular(numero1, numero2, operacion);

                txtPantalla.Text = resultado.ToString();
            }
            catch
            {
                MessageBox.Show("Operación inválida");
            }
        }

        // Limpia la pantalla de la calculadora
        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtPantalla.Text = "0";
        }
    }
}