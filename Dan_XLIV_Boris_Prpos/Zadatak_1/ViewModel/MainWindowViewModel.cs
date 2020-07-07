using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;
        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(param => LoginExecute(), param => CanLoginExecute());
                }
                return login;
            }
        }
        private void LoginExecute()
        {
            try
            {
                if (Username == "Zaposleni" && Password == "Zaposleni")
                {
                    MessageBox.Show("Welcome Zaposleni");
                }
                else if (Username.Length == 13 && NumbersOnly(Username) == true && Password == "Gost")
                {
                    User userView = new User(Username);
                    userView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid parametres");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }
        private bool CanLoginExecute()
        {
            if (String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(Username))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            main.Close();
        }
        private bool CanCloseExecute()
        {
            return true;
        }
        private bool NumbersOnly(string input)
        {
            input = Username;

            char[] array = input.ToCharArray();

            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (Char.IsDigit(array[i]))
                {
                    counter++;
                }
            }
            if (counter==13)
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
