using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TConverter_gui
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void FahreheitEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(FahreheitEdit.Text, out float fahrenheit) || FahreheitEdit.Text == "-")
            {
                if (FahreheitEdit.IsSelectionActive)
                {
                    float result = (fahrenheit - 32) * 5 / 9;
                    CelsiusEdit.Text = Math.Round(result, 1) < -273.15 ? "Temperature below absolute zero" : Convert.ToString(Math.Round(result, 1));
                }
            }
            else
            {
                if (FahreheitEdit.Text.Length == 0)
                {
                    CelsiusEdit.Clear();
                }
                else
                {
                    CelsiusEdit.Clear();
                    FahreheitEdit.Clear();
                    _ = MessageBox.Show("Wrong Value");
                }
            }
        }
        private void CelsiusEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(CelsiusEdit.Text, out float celsius) || CelsiusEdit.Text == "-")
            {
                if (CelsiusEdit.IsSelectionActive)
                {
                    float result = (celsius * 9 / 5) + 32;
                    FahreheitEdit.Text = Math.Round(result, 1) < -459.67 ? "Temperature below absolute zero" : Convert.ToString(Math.Round(result, 1));
                }
            }
            else
            {
                if (CelsiusEdit.Text.Length == 0)
                {
                    FahreheitEdit.Clear();
                }
                else
                {
                    CelsiusEdit.Clear();
                    FahreheitEdit.Clear();
                    _ = MessageBox.Show("Wrong Value");
                }
            }
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
