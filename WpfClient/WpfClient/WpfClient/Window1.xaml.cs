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
using WpfAnimatedGif;
using WpfClient.ServiceReferenceUFC;
using System.Windows.Media.Animation;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ServiceUFCClient ServiceUFC;
        FighterList fighters;
        bool view;
        public Window1()
        {
            InitializeComponent();
            ServiceUFC = new ServiceUFCClient();
            fighters=ServiceUFC.GetAllFighters();

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"pack://application:,,,/images/Gifs/gif.gif");
            image.EndInit();
            view = false;
            ImageBehavior.SetAnimatedSource(gif, image);
            ImageBehavior.SetAutoStart(gif, false);
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FighterWindow fighterWindow = new FighterWindow(fighters[0]);
            fighterWindow.ShowDialog();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            DivisionWindow window = new DivisionWindow();
            window.ShowDialog();
        }

        private void gif_MouseEnter(object sender, MouseEventArgs e)
        {
            if (view == false)
            {
                ImageBehavior.SetRepeatBehavior(gif, RepeatBehavior.Forever);
                view = true;
            }
        }

        private void gif_MouseLeave(object sender, MouseEventArgs e)
        {
            view = false;
            ImageBehavior.SetAnimationDuration(gif, new Duration(new TimeSpan(1)));
        }

    }
}
