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
using ComputerSimulationLB1.MenuItems;

namespace ComputerSimulationLB1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const double b0 = 14.2036;
        private const double b1 = 1.1684;

        private void ImportFile(object sender, RoutedEventArgs e)
        {
            boxAmountIron.Text = null;
            boxMeltingTime.Text = null;

            MenuFile menuFile = new();
            menuFile.Import();
        }

        private void CalculateDataClick(object sender, RoutedEventArgs e)
        {
            try
            {
                boxMeltingTime.Text = CalculateData(boxAmountIron.Text);
            }
            catch
            {
                MessageBox.Show("Перевірте коректність введених даних");
            }
        } 
         
        public string CalculateData(string amountIronString)
        {
            double amountIron = double.Parse(amountIronString.Replace(".", ","));
            double time = b0 + b1 * amountIron;

            return Math.Round(time, 2).ToString();
        }

        private void MyWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
