using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema2_CalculadoraBasica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            calcularButton.IsEnabled = false;
        }
        // ESTO ES MUY CONFUSO
        private (float?, float?) CompruebaOperandos()
        {
            try
            {
                return (float.Parse(operando1TextBox.Text), float.Parse(operando2TextBox.Text));
            } catch (Exception)
            {
                MessageBox.Show("Se ha producido un error. Revise los operandos");
            }
            return(null, null) ;

        }
        private void CalcularButton_Click(object sender, RoutedEventArgs e)
        {
            
            float? op1, op2;
            (op1, op2) = CompruebaOperandos();
            if (op1 != null && op2 != null)
            {
                resultadoTextBox.Text = operadorTextBox.Text switch
                {
                    "+" => (op1 + op2).ToString(),
                    "-" => (op1 - op2).ToString(),
                    "*" => (op1 * op2).ToString(),
                    "/" => (op1 / op2).ToString(),
                    _ => ""
                };
            }
            
            
        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            operando1TextBox.Text = "";
            operando2TextBox.Text = "";
            operadorTextBox.Text = "";
            resultadoTextBox.Text = "";
        }

        private void OperadorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (operadorTextBox.Text) {
                case "+":
                case "*":
                case "-":
                case "/":
                    calcularButton.IsEnabled = true; break;
                default
                    : calcularButton.IsEnabled = false; break;
            }
        }
    }
}
