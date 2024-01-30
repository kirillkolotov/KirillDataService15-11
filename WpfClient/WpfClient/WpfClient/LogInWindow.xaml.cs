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
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        private User user;
        private bool UserNameOK, PassOK;
        private ServiceUFCClient ServiceUFC;
        public LogInWindow()
        {
            InitializeComponent();
            ServiceUFC = new ServiceUFCClient();
            user= new User();
            UserNameOK = PassOK = false;
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

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidUsername valid = new ValidUsername();
            ValidationResult result = valid.Validate(txtUser.Text, null);
            if (result.IsValid)
            {                
                txtUser.BorderBrush = Brushes.DarkGray;
                txtUser.Foreground = Brushes.White;
                txtUser.ToolTip = null;
                UserNameOK = true;
            }
            else
            {
                txtUser.BorderBrush = Brushes.Red;
                txtUser.Foreground = Brushes.Red;
                txtUser.ToolTip = result.ErrorContent.ToString();
                UserNameOK = false;
            }
        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidPassword valid = new ValidPassword();
            ValidationResult result = valid.Validate(txtPass.Password, null);
            if (result.IsValid)
            {
                txtPass.BorderBrush = Brushes.DarkGray;
                txtPass.Foreground = Brushes.White;
                txtPass.ToolTip = null;
                PassOK = true;
            }
            else
            {
                txtPass.BorderBrush = Brushes.Red;
                txtPass.Foreground = Brushes.Red;
                txtPass.ToolTip = result.ErrorContent.ToString();
                PassOK = false;
            }
        }
        private void Signup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.ShowDialog();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!UserNameOK || !PassOK)
            {
                MessageBox.Show("Errors found!\n FIX IT", "NO");
                return;
            }
            user=new User { Username = txtUser.Text, Password = txtPass.Password };
            user = ServiceUFC.Login(user);
            if (user == null)
            {
                MessageBox.Show("no user detected");
                this.DataContext = user = new User();
                return;
            }
            if (user.IsAdmin)
            {
                AdminWindow mW = new AdminWindow(user);
                Close();
                mW.Show();
            }
            else
            {
                UserWindow wp = new UserWindow(user);
                Close();
                wp.Show();
            }
            txtUser.Text = txtPass.Password = string.Empty;
        }
    }
}
