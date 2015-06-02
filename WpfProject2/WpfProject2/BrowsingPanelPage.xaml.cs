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
using System.Xml;

namespace WpfProject2
{
    /// <summary>
    /// Interaction logic for BrowsingPanelPage.xaml
    /// </summary>
    public partial class BrowsingPanelPage : Page
    {
        public BrowsingPanelPage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           // readFromServer("http://ojp.cba.pl/Magazines.xml");
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bookstore Online \nCreated by Jan Szreder");
        }
    }
}
