using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace MiAplicacionWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j1 = Convert.ToInt32(j1TextBox.Text);
                int j2 = Convert.ToInt32(j2TextBox.Text);

                //Llama al código IntervaloSuma que realiza la suma de j1+j2
                int suma = IntervaloSuma.CalcularSuma(j1, j2);
                int resta = j1 - j2;
                int valorAbsoluto = Math.Abs(resta);

                //Calcula los valores minimo y máximo
                int min = Math.Min(valorAbsoluto, suma);
                int max = Math.Max(valorAbsoluto, suma);

                //Llama al archivo ListaMomentosTotales que imprime los valores entre los intervalos de |j1-j2| y j1+j2
                string intervaloTexto = ListaMomentosTotales.ValoresJ(min, max);

                // Obtener lista de valores para j1 y j2 de MomentosJ1Yj2
                string m1 = MomentosJ1Yj2.ObtenerValoresJ1Texto(j1);
                string m2 = MomentosJ1Yj2.ObtenerValoresJ2Texto(j2);

                // Agregar las listas de valores a intervaloTexto y los muestra en pantalla
                intervaloTexto += $"\nValores de m1 entre -j1 y j1: {m1}";
                intervaloTexto += $"\nValores de m2 entre -j2 y j2: {m2}";



                resultadoTextBlock.Text = intervaloTexto;
                //añadido
                List<int> valoresJ = ListaMomentosTotales.ObtenerValoresJ(min, max);
                jComboBox.ItemsSource = valoresJ;


            }
            catch (Exception ex)
            {
                resultadoTextBlock.Text = "Error: " + ex.Message;
            }
        }


        //El menú de los j posibles a elegir
        private void jComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (jComboBox.SelectedItem != null)
            {
                int j = (int)jComboBox.SelectedItem;

                // Obtener valores de m para el valor seleccionado de j
                List<int> valoresM = new List<int>();
                int negativo = -j;
                for (int i = negativo; i <= j; i++)
                {
                    valoresM.Add(i);
                }

                mComboBox.ItemsSource = valoresM;
                UpdateSelectedValuesTextBlock();
            }
        }




        //El menú de los m posible dado el j ya elegido, con un salto de línea 
        private void mComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mComboBox.SelectedItem != null)
            {
                int m = (int)mComboBox.SelectedItem;
                string intervaloTexto = resultadoTextBlock.Text;

                string mSeleccionadoTexto = $"\nValor de m seleccionado: {m}";

                // Reemplazar o agregar la parte correspondiente al valor seleccionado de m
                if (intervaloTexto.Contains("Valor de m seleccionado:"))
                {
                    int startIndex = intervaloTexto.IndexOf("Valor de m seleccionado:");
                    int endIndex = intervaloTexto.IndexOf('\n', startIndex);
                    if (endIndex == -1)
                        endIndex = intervaloTexto.Length;

                    intervaloTexto = intervaloTexto.Remove(startIndex, endIndex - startIndex);
                }

                resultadoTextBlock.Text = intervaloTexto + mSeleccionadoTexto;
                UpdateSelectedValuesTextBlock();
            }
        }

        private void UpdateSelectedValuesTextBlock()
        {
            int j1 = Convert.ToInt32(j1TextBox.Text);
            int j2 = Convert.ToInt32(j2TextBox.Text);
            int j = 0;
            int m = 0;

            if (jComboBox.SelectedItem != null)
            {
                j = (int)jComboBox.SelectedItem;
            }

            if (mComboBox.SelectedItem != null)
            {
                m = (int)mComboBox.SelectedItem;
            }

            string selectedValuesText = CalculoCoeficientesClebsh.GetSelectedValuesTextBlock(j1, j2, j, m);
            selectedValuesTextBlock.Text = selectedValuesText;

        }


        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            BotonLimp botonLimp = new BotonLimp();
            botonLimp.Limpiar_Click(sender, e);
        }

        private void JPlusButton_Click(object sender, RoutedEventArgs e) //Operador Ascenso, incrementa nuestro estado
        {

            int j1 = Convert.ToInt32(j1TextBox.Text);
            int j2 = Convert.ToInt32(j2TextBox.Text);

            // Lógica para el botón J_+
            int j = (int)jComboBox.SelectedItem;
            int m = (int)mComboBox.SelectedItem;


            PrintMessage("\n  \n Operador Ascenso \n");
            StringBuilder mensajeBuilder = new StringBuilder();
            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine($"√[(j - m)(j + m1 + 1)] < j1, j2; m1, m2 | j1,j2;{j}, {m} + 1 > = √[(j1 - m1+1)(j1 + m1)] < j1, j2; m1 - 1, m2 | j1,j2;{j}, {m} > +");
            mensajeBuilder.AppendLine($"√[(j2 - m2+1)(j2 + m2)] < j1, j2; m1, m2 - 1 | j1{j}, {m} >");
            mensajeBuilder.AppendLine();

            mensajeBuilder.Append($"√[({j} - {m})({j} + {m} + 1)] < j1, j2; m1, m2 | {j}, {m} + 1 > =");

            // Obtener lista de valores para j1 y j2 de MomentosJ1Yj2
            List<int> valoresJ1 = MomentosJ1Yj2.ObtenerValoresJ1(j);
            List<int> valoresJ2 = MomentosJ1Yj2.ObtenerValoresJ2(j);

            // Obtener los pares ordenados que cumplen la condición m = m1 + m2
            List<string> paresOrdenados = new List<string>();
            foreach (int m1 in valoresJ1)
            {
                int m2 = m - m1;
                if (valoresJ2.Contains(m2))
                {
                    string parOrdenado = $"√[(j1 - {m1} + 1)(j1 + {m1})] < j1, j2; {m1} - 1, {m2} | j1,j2;{j}, {m} > +";
                    paresOrdenados.Add(parOrdenado);
                }
            }

            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine();

            // Imprimir los pares ordenados
            mensajeBuilder.AppendLine($"(m1 + 1, m2)");

            // Imprimir puntos arriba del punto
            for (int i = 0; i < 3; i++)
            {
                mensajeBuilder.AppendLine("     .");
            }

            // Imprimir punto y texto correspondiente
            mensajeBuilder.AppendLine("     .          .       .         . (m1 + 1, m2)");

            // Imprimir (j, m)
            mensajeBuilder.AppendLine($"({j1}, {j2})");

            string mensaje = mensajeBuilder.ToString();
            PrintMessage(mensaje);

            //Falta que elimine los términos inválidos y se aplique para el segundo término de la ecuación
        }






        private void JMinusButton_Click(object sender, RoutedEventArgs e) // Operador Descenso, decrementa nuestro estado
        {
            // Lógica para el botón J_-
            int j = (int)jComboBox.SelectedItem;
            int m = (int)mComboBox.SelectedItem;

            PrintMessage("\n \n Operador Descenso \n");
            StringBuilder mensajeBuilder = new StringBuilder();
            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine($"√[(j + m)(j - m1 + 1)] < j1, j2; m1, m2 | j1,j2;{j}, {m} - 1 > = √[(j1 + m1 + 1)(j1 - m1)] < j1, j2; m1 + 1, m2 | j1,j2;{j}, {m} > -");
            mensajeBuilder.AppendLine($"√[(j2 + m2 + 1)(j2 - m2)] < j1, j2; m1, m2 + 1 | j1{j}, {m} >");
            mensajeBuilder.AppendLine();

            mensajeBuilder.Append($"√[({j} + {m})({j} - {m} + 1)] < j1, j2; m1, m2 | {j}, {m} - 1 > =");

            // Obtener lista de valores para j1 y j2 de MomentosJ1Yj2
            List<int> valoresJ1 = MomentosJ1Yj2.ObtenerValoresJ1(j);
            List<int> valoresJ2 = MomentosJ1Yj2.ObtenerValoresJ2(j);

            // Obtener los pares ordenados que cumplen la condición m = m1 + m2
            List<string> paresOrdenados = new List<string>();
            foreach (int m1 in valoresJ1)
            {
                int m2 = m - m1;
                if (valoresJ2.Contains(m2))
                {
                    string parOrdenado = $"√[(j1 + {m1} + 1)(j1 - {m1})] < j1, j2; {m1} + 1, {m2} | j1,j2;{j}, {m} > -";
                    paresOrdenados.Add(parOrdenado);
                }
            }

            // Imprimir los pares ordenados
            foreach (string parOrdenado in paresOrdenados)
            {
                mensajeBuilder.AppendLine(parOrdenado);
            }

            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine($"  (m1 - 1, m2)   .          .       .       ({j}, {m})");
            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine("                                               .");
            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine("                                               .");
            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine("                                               .");
            mensajeBuilder.AppendLine();
            mensajeBuilder.AppendLine("                                           (m1, m2-1)");

            string mensaje = mensajeBuilder.ToString();
            PrintMessage(mensaje);
        }



        private void PrintMessage(string message)
        {
            // Imprimir el mensaje en el TextBlock "selectedValuesTextBlock"
            selectedValuesTextBlock.Text += message + "\n";
        }




    }
}
