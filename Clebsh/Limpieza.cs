using System.Windows;
using System.Windows.Controls;

namespace MiAplicacionWPF
{
    public class BotonLimp
    {
        public void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            // Restablecer los valores y controles a su estado inicial
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.j1TextBox.Text = string.Empty;
            mainWindow.j2TextBox.Text = string.Empty;
            mainWindow.jComboBox.ItemsSource = null;
            mainWindow.mComboBox.ItemsSource = null;
            mainWindow.resultadoTextBlock.Text = string.Empty;
            mainWindow.selectedValuesTextBlock.Text = string.Empty;

            mainWindow.jComboBox.IsEnabled = false;
            mainWindow.mComboBox.IsEnabled = false;

            // Restablecer selecciones de ComboBox
            mainWindow.jComboBox.SelectedIndex = -1;
            mainWindow.mComboBox.SelectedIndex = -1;

            // Habilitar los ComboBox nuevamente
            mainWindow.jComboBox.IsEnabled = true;
            mainWindow.mComboBox.IsEnabled = true;
        }
    }
}