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
    class SignIn : Veryfication
    {
        LibraryDBEntities context = new LibraryDBEntities();
        private Logowanie newUser = new Logowanie();

        public SignIn(string name, string surname, string password)
        {
            newUser.Login = name;
            newUser.Surname = surname;
            newUser.Password = password;
        }

        override public bool loginVeryfication(string login)
        {
            var activeUser = (from user in context.Logowanie where newUser.Login == user.Login select user).FirstOrDefault();

            if (newUser.Login.Equals("") || newUser.Surname.Equals(""))
            {
                MessageBox.Show("Uzupełnij pola logowania");
                return false;
            }
            else if (activeUser == null)
            {
                MessageBox.Show("Podano błędny login");
                return false;
            }
            else if (activeUser.Blocked)
            {
                MessageBox.Show("Podałeś trzykrotnie błędne hasło. W celu odblokowania\nkonta skontaktuj się z administratorem");
                return false;
            }
            else if (newUser.Surname != activeUser.Surname)
            {
                MessageBox.Show("Podane nieprawidłowe nazwisko");
                return false;
            }
            else if (!passVeryfication(newUser.Password))
            {
                if (activeUser.WrongAttempts == 3)
                {
                    activeUser.Blocked = true;
                    MessageBox.Show("Podałeś trzykrotnie błędne hasło. W celu odblokowania\nkonta skontaktuj się z administratorem");
                }
                else
                {
                    MessageBox.Show("Podane hasło jest nieprawidłowe");
                    activeUser.WrongAttempts++;
                    if (activeUser.WrongAttempts == 3)
                    {
                        activeUser.Blocked = true;
                        MessageBox.Show("Podałeś trzykrotnie błędne hasło. W celu odblokowania\nkonta skontaktuj się z administratorem");
                    }
                }
                context.SaveChanges();
                return false;
            }
            else
            {
                activeUser.WrongAttempts = 0;
                context.SaveChanges();
                return true;
            }
        }

        override public bool passVeryfication(string pass)
        {
            var activeUser = (from user in context.Logowanie where newUser.Login == user.Login select user).FirstOrDefault();

            if (newUser.Password.Equals(""))
            {
                return false;
            }
            else if (hashPass(newUser.Password).Equals(activeUser.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool loginUser()
        {
            if (loginVeryfication(newUser.Login))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
