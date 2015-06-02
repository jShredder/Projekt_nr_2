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
    class Register : Veryfication
    {
        LibraryDBEntities context = new LibraryDBEntities();
        private Logowanie newUser = new Logowanie();
        private string repeatedPass;

        public Register(string name, string surname, string password, string repeatedPass)
        {
            newUser.Login = name;
            newUser.Password = password;
            newUser.Surname = surname;
            this.repeatedPass = repeatedPass;
        }

        override public bool loginVeryfication(string login)
        {
            if (context.Logowanie.Where(user1 => user1.Login == newUser.Login).FirstOrDefault() == null && login != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        override public bool passVeryfication(string pass)
        {
            if (pass.Equals(repeatedPass) && !newUser.Password.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int registerUser()
        {
            if (loginVeryfication(newUser.Login))
            {
                if (passVeryfication(newUser.Password))
                {
                    newUser.Password = hashPass(newUser.Password);
                    newUser.UserType = false;
                    newUser.WrongAttempts = 0;
                    newUser.Blocked = false;
                    context.Logowanie.Add(newUser);
                    context.SaveChanges();

                    var activeUser = (from user in context.Logowanie where user.Login == newUser.Login where user.Surname == newUser.Surname select user).FirstOrDefault();

                    return activeUser.Id;
                }
                else
                {
                    MessageBox.Show("Wprowadzone hasła nie zgadzają się!");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("Użytkownik o podanym nicku już istnieje!");
                return -1;
            }
        }
    }
}
