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
using System.Net;
using System.Net.Mail;

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
                sendOrderMagazine();
            }
            else
            {
                MessageBox.Show("Nie wybrano rekordu");
            }
        }

        private void sendOrderMagazine()
        {
            Magazine1 selectedMagazine = dataGrid1.SelectedItem as Magazine1;
            var activeUser = (from l in context.Logowanie where l.Id == userId select l).FirstOrDefault();

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("q123aaaaz123aaaqqq147@gmail.com");
                message.To.Add(new MailAddress("q123aaaaz123aaaqqq147@gmail.com"));
                message.Subject = "Customer order - Magazine";
                message.Body = "Client: " + activeUser.Login + " " + activeUser.Surname + "\n Order magazine: " + "\nTitle: "
                + selectedMagazine.Title + "Issue: " + selectedMagazine.Issue + "Price: " + selectedMagazine.Price;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("q123aaaaz123aaaqqq147@gmail.com", "asd123123qwe");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("Successfully sent message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }

        private void sendOrderBook()
        {
            Books1 selectedMagazine = dataGrid2.SelectedItem as Books1;
            var activeUser = (from l in context.Logowanie where l.Id == userId select l).FirstOrDefault();

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("q123aaaaz123aaaqqq147@gmail.com");
                message.To.Add(new MailAddress("q123aaaaz123aaaqqq147@gmail.com"));
                message.Subject = "Customer order - Book";
                message.Body = "Client: " + activeUser.Login + " " + activeUser.Surname + "\n Order magazine: " + "\nTitle: "
                + selectedMagazine.Title + "Price: " + selectedMagazine.Availability;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("q123aaaaz123aaaqqq147@gmail.com", "asd123123qwe");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("Successfully sent message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }

        private void zamow_ksiazke_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid2.SelectedItems.Count > 0)
            {
                Books1 selectedBook = dataGrid2.SelectedItem as Books1;
               
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

                if (selectedBook.Category.Equals("available"))
                {
                    newBook.Availability = true;
                }
                else
                {
                    newBook.Availability = false;
                }

                context.Book.Add(newBook);
                context.SaveChanges();
                sendOrderBook();
            }
            else
            {
                MessageBox.Show("Nie wybrano rekordu");
            }
        }
    }
}
