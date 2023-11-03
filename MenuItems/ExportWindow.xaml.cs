using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ComputerSimulationLB1.MenuItems
{
    public partial class ExportWindow : Window
    {
        public ExportWindow()
        {
            InitializeComponent();
        }

        private readonly ObservableCollection<StaticModel> model = new();

        public void AddingData(List<string> list)
        {
            var record = new StaticModel(Int32.Parse(list[0]), double.Parse(list[1]), double.Parse(list[2]));
            model.Add(record);

            dataGrid.ItemsSource = model;
        }

        private void ExportFile(object sender, RoutedEventArgs e)
        {
            MenuFile menu = new();
            menu.Export(model);
        }
    }
}
