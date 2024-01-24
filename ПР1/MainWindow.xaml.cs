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

namespace ПР1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ans.IsReadOnly = true;
        }

        double calculate_function(double x0, double b0, double f) {
            double condition = x0 * b0;
            double result;

            if (1 < condition & condition < 10)
            {
                result = Math.Exp(f);
            }
            else if (12 < condition & condition < 40)
            {
                result = Math.Sqrt(Math.Abs(f + 4 * b0));
            }
            else
            {
                result = b0 * Math.Pow(f, 2);
            }

            return result;
        }

        double calculate_subfunction(string op, double x0) {
            switch (op) {
                case "sinh": return Math.Sinh(x0);
                case "square": return Math.Pow(x0, 2);
                case "exp": return Math.Exp(x0);
                default: return 0;
            }
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(x.Text)) { ans.Text = "x is Empty"; }
            else if (string.IsNullOrEmpty(b.Text)) { ans.Text = "b is Empty"; }
            else
            {
                try
                {
                    double x0 = Convert.ToDouble(x.Text);
                    double b0 = Convert.ToDouble(b.Text);

                    if (sh_x.IsChecked == true)
                    {
                        double f = calculate_subfunction("sinh", x0);
                        double result = calculate_function(x0, b0, f);
                        ans.Text = Convert.ToString(result);
                    }
                    else if (x_2.IsChecked == true)
                    {
                        double f = calculate_subfunction("square", x0);
                        double result = calculate_function(x0, b0, f);
                        ans.Text = Convert.ToString(result);
                    }
                    else if (e_x.IsChecked == true)
                    {
                        double f = calculate_subfunction("exp", x0);
                        double result = calculate_function(x0, b0, f);
                        ans.Text = Convert.ToString(result);
                    }
                }
                catch { ans.Text = "Not a number"; }
            }
        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            x.Clear();
            b.Clear();
            ans.Clear();
            sh_x.IsChecked = false;
            x_2.IsChecked = false;
            e_x.IsChecked = false;
        }

        private void x_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void b_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ans_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void x_2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void e_x_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void sh_x_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?",
                    "Exit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes) { Close(); }
        }
    }
}
