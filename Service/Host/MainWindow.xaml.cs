using ServiceModel;
using System.ServiceModel;
using System.Windows;

namespace Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceHost serviceHost = new ServiceHost(typeof(ServiceUFC));
            serviceHost.Open();
        }
    }
}
