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
using WpfClient.ServiceReferenceUFC;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ServiceUFCClient ServiceUFC;
        FighterList fighters;
        public Window1()
        {
            InitializeComponent();
            ServiceUFC = new ServiceUFCClient();
            fighters=ServiceUFC.GetAllFighters();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FighterWindow fighterWindow = new FighterWindow(fighters[0]);
            fighterWindow.ShowDialog();
        }
    }
}
