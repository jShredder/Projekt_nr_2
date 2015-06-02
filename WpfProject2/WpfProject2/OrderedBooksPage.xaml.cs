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
        LibraryDBEntities context = new LibraryDBEntities();

        private int userId;

        public OrderedBooksPage(int id)
        {
            InitializeComponent();
            userId = id;
            showOrderedBooks();
            showOrderedMagazines();

            var activeUser = (from l in context.Logowanie where l.Id == userId select l).FirstOrDefault();
            userNameTextbox.Text = activeUser.Login + " " + activeUser.Surname;
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

        private void showOrderedBooks()
        {

            var orderedBooks = (from b in context.Book
                                join s in context.State on b.StateId equals s.Id
                                join c in context.Category on b.CategoryId equals c.Id
                                where b.LogowanieId == userId
                                select new
                                {
                                    title1 = b.Title,
                                    author1 = b.Author,
                                    price1 = b.Price,
                                    state1 = s.StateName,
                                    category1 = c.CategoryName
                                }
            ).ToList();

            orderedBooksDatagrid.ItemsSource = orderedBooks;
        }

        private void showOrderedMagazines()
        {
            var orderedMagazines = (from m in context.Magazine
                                join s in context.State on m.StateId equals s.Id
                                join c in context.Category on m.CategoryId equals c.Id
                                where m.LogowanieId == userId
                                select new
                                {
                                    title1 = m.Title,
                                    issue1 = m.Issue,
                                    price1 = m.Price,
                                    state1 = s.StateName,
                                    category1 = c.CategoryName
                                }
            ).ToList();
            orderedMagazinesDatagrid.ItemsSource = orderedMagazines;
        }

        private void orderedMagazinesDatagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void orderedBooksDatagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
