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
using System.Windows.Shapes;

namespace WpfChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Gauge_Click(object sender, RoutedEventArgs e)
        {
            GaugeWindow window = new GaugeWindow();
            window.ShowDialog();
        }

        private void Map_Click(object sender, RoutedEventArgs e)
        {
            MapWindow window = new MapWindow();
            window.ShowDialog();
        }

        private void Pie_Click(object sender, RoutedEventArgs e)
        {
            PieWindow window = new PieWindow();
            window.ShowDialog();
        }

        private void DPie_Click(object sender, RoutedEventArgs e)
        {
            DoughnutChartWindow window = new DoughnutChartWindow();
            window.ShowDialog();
        }

    }
}
