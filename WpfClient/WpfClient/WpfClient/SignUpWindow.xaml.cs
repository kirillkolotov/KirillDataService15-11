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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private bool pass, repass;
        private ServiceUFCClient serviceUFC;
        private User user;
        public SignUpWindow()
        {
            InitializeComponent();
            user= new User();
            this.DataContext = user;
            serviceUFC = new ServiceUFCClient();
            pass = repass = false;
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
           this.Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.Text =
            FirstNameTextBox.Text =
            LastnameTextBox.Text =
            EmailTextBox.Text =
            PasswordTextBox.Password =
            ReapetPasswordTextBox.Password = string.Empty;

        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            if (AllDataIsValid() == false) //האם המידע בטופס תקין
            {
                MessageBox.Show("You got errors. Fix it", "No", MessageBoxButton.OK);
                return;
            }
            if (serviceUFC.FindUsername(UsernameTextBox.Text))//האם שם המשתמש קיים במערכת
            {
                MessageBox.Show("username is in taken. Fix it", "No", MessageBoxButton.OK);
                return;
            }
            //שם המשתמש פנוי, השלמת מידע חסר
            user.Password = PasswordTextBox.Password;
            user.IsAdmin = false;
            if (serviceUFC.NewUser(user) != 1) //האם נוצר משתמש חדש?
            {
                MessageBox.Show("Oh oh...something is wrong","No",MessageBoxButton.OK);
                return;
            }
            //המשתמש נרשם, סיום ויציאה
            MessageBox.Show("Thank you", "Yess", MessageBoxButton.OK);
            this.Close();
        }
        private bool AllDataIsValid()
        {
            if (UsernameTextBox.Text.Equals(string.Empty)) return false;
            if (FirstNameTextBox.Text.Equals(string.Empty)) return false;
            if (LastnameTextBox.Text.Equals(string.Empty)) return false;
            if (EmailTextBox.Text.Equals(string.Empty)) return false;
            if (PasswordTextBox.Password.Equals(string.Empty)) return false;
            if (ReapetPasswordTextBox.Password.Equals(string.Empty)) return false;
            if (Validation.GetHasError(UsernameTextBox)) return false;
            if (Validation.GetHasError(FirstNameTextBox)) return false;
            if (Validation.GetHasError(LastnameTextBox)) return false;
            if (Validation.GetHasError(EmailTextBox)) return false;
            if (!pass) return false;
            if (!repass) return false;
            return true;
        }

        private void ReapetPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password.Equals(ReapetPasswordTextBox.Password))
            {
                ReapetPasswordTextBox.BorderBrush = Brushes.Transparent;
                HintAssist.SetHelperText(ReapetPasswordTextBox, "Passwords match");
                repass = true;
            }
            else
            {
                ReapetPasswordTextBox.BorderBrush = Brushes.Red;
                HintAssist.SetHelperText(ReapetPasswordTextBox, "Passwords DO NOT match");
                repass = false;
            }
        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidPassword valid = new ValidPassword();
            ValidationResult result = valid.Validate(PasswordTextBox.Password, null);
            if (result.IsValid)
            {
                PasswordTextBox.BorderBrush = Brushes.Transparent;
                HintAssist.SetHelperText(PasswordTextBox, "Password");
                pass = true;
            }
            else
            {
                PasswordTextBox.BorderBrush = Brushes.Red;
                HintAssist.SetHelperText(PasswordTextBox, result.ErrorContent.ToString());
                pass = false;
            }
        }
    }
}
