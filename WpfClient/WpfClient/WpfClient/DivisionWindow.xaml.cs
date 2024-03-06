using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for DvivsionWindow.xaml
    /// </summary>
    public partial class DivisionWindow : Window
    {
        ServiceUFCClient ServiceUFCClient;
        DivisionList divisions;
        int max;
        int min;
        public DivisionWindow()
        {
            InitializeComponent();
            ServiceUFCClient=new ServiceUFCClient();
            divisions=ServiceUFCClient.GetAllDivisions();
            lvDivision.ItemsSource = divisions;
        }

       
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MinTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                min = int.Parse(MinTextBox.Text);
                if (min < 0)
                {
                    MinTextBox.Foreground = Brushes.Red;
                    MinTextBox.BorderBrush = Brushes.Red;
                    HintAssist.SetHelperText(MinTextBox, "Positive number");
                }
                else
                {
                    MinTextBox.Foreground = Brushes.White;
                    MinTextBox.BorderBrush = Brushes.White;
                    HintAssist.SetHelperText(MinTextBox, "Insert min here");
                }
            }
            catch {
                MinTextBox.Foreground = Brushes.Red;
                MinTextBox.BorderBrush = Brushes.Red;
                HintAssist.SetHelperText(MinTextBox, "Only numbers");
            }
        }
        private void DivisionNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MaxTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
