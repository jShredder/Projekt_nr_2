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
        LibraryDBEntities context = new LibraryDBEntities();
        private int userId;

        public BrowsingPanelPage(int id)
        {
            InitializeComponent();
            userId = id;
            textbox1.Text = "userId = " + userId;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bookstore Online \nCreated by Jan Szreder");
        }

        private void zamowienia_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OrderedBooksPage(userId));
        }

        private void zamow_magazyn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItems.Count > 0)
            {
                Magazine1 selectedMagazine = dataGrid1.SelectedItem as Magazine1;

                Magazine newMagazine = new Magazine();
                newMagazine.LogowanieId = userId;
                newMagazine.Title = selectedMagazine.Title;
                newMagazine.Issue = selectedMagazine.Issue;
                var catId = context.Category.Where(cat => cat.CategoryName.Equals(selectedMagazine.Category)).FirstOrDefault();
                newMagazine.CategoryId = catId.Id;
                newMagazine.Price = decimal.Parse(selectedMagazine.Price);
                var stId = context.State.Where(s => s.StateName.Equals(selectedMagazine.State)).FirstOrDefault();
                newMagazine.StateId = stId.Id;
                newMagazine.Amount = short.Parse(selectedMagazine.Amount);
                if (selectedMagazine.Availability.Equals("available"))
                {
                    newMagazine.Availability = true;
                }
                else
                {
                    newMagazine.Availability = false;
                }

                context.Magazine.Add(newMagazine);
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Nie wybrano rekordu");
            }
        }

        private void zamow_ksiazke_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid2.SelectedItems.Count > 0){
                Books1 selectedBook = dataGrid2.SelectedItem as Books1;
                /*
                
                textbox1.Text = "title: " + selectedBook.Title +"\n";
                textbox1.Text += "author: " + selectedBook.Author + "\n";
                textbox1.Text += "price: " + selectedBook.Price + "\n";
                textbox1.Text += "state: " + selectedBook.State + "\n";
                textbox1.Text += "category: " + selectedBook.Category + "\n";
                textbox1.Text += "year: " + selectedBook.Year + "\n";
                textbox1.Text += "Availability: " + selectedBook.Availability + "\n";
                textbox1.Text += "amount: " + selectedBook.Amount + "\n";
                */
                Book newBook = new Book();
                

                newBook.LogowanieId = userId;
                newBook.Title = selectedBook.Title;
                newBook.Author = selectedBook.Author;
                newBook.Year = int.Parse(selectedBook.Year);
                var catId = context.Category.Where(cat => cat.CategoryName.Equals(selectedBook.Amount)).FirstOrDefault();
                newBook.CategoryId = catId.Id;
                var stId = context.State.Where(s => s.StateName.Equals(selectedBook.Price)).FirstOrDefault();
                newBook.StateId = stId.Id;

                newBook.Price = decimal.Parse(selectedBook.Availability);

                newBook.Amount = short.Parse(selectedBook.State);
                
                if(selectedBook.Category.Equals("available")){
                    newBook.Availability = true;
                }else{
                    newBook.Availability = false;
                }

                context.Book.Add(newBook);
                context.SaveChanges();
                textbox1.Text += "przesłano\n";
            }else{
                 MessageBox.Show("Nie wybrano rekordu");
            }
        }
    }
}
