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
        private void FahreheitEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(FahreheitEdit.Text, out float fahrenheit) || FahreheitEdit.Text == "-")
            {
                if (FahreheitEdit.IsSelectionActive)
                {
                    CelsiusEdit.ToolTip = null;
                    float result = (fahrenheit - 32) * 5 / 9;
                    if (Math.Round(result, 1) < -273.15)
                    {
                        FahreheitEdit.Clear();
                        CelsiusEdit.ToolTip = "Temperature below absolute zero";
                    }
                    else
                    {
                        CelsiusEdit.Text = Convert.ToString(Math.Round(result, 1));
                    }
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
                    FahreheitEdit.ToolTip = null;
                    float result = (celsius * 9 / 5) + 32;
                    if (Math.Round(result, 1) < -459.67)
                    {
                        CelsiusEdit.Clear();
                        FahreheitEdit.ToolTip = "Temperature below absolute zero";
                    }
                    else
                    {
                        FahreheitEdit.Text = Convert.ToString(Math.Round(result, 1));
                    }
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
