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
    /// Interaction logic for OrderedBooksPage.xaml
    /// </summary>
    public partial class OrderedBooksPage : Page
    {
        private int userId;

        public OrderedBooksPage(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bookstore Online \nCreated by Jan Szreder");
        }

        private void zloz_zamowienie_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BrowsingPanelPage(userId));
        }
    }
}
