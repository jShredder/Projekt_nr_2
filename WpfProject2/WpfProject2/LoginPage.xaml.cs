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

namespace WpfProject2
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            LibraryDBEntities context = new LibraryDBEntities();
            SignIn signIn = new SignIn(userName.Text, userSurname.Text, userPassword.Password);

            if (signIn.loginUser())
            {
                var activeUser = (from user in context.Logowanie where user.Login == userName.Text where user.Surname == userSurname.Text select user).FirstOrDefault();
                this.NavigationService.Navigate(new BrowsingPanelPage(activeUser.Id));
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPage());
        }
    }
}
