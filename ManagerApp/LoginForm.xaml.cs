using DataAccess.DAO;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace ManagerApp
{
    public partial class LoginForm : Window
    {
        public static string GlobalUsername = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            SecureString securePassword = txtPassword.SecurePassword;
            string password = new System.Net.NetworkCredential(string.Empty, securePassword).Password;
            LoginAccount(username, password);
        }

        private void LoginAccount(string username, string password)
        {
            if(username.Length > 0 && password.Length > 0)
            {
                AccountDAO accountDAO = new AccountDAO();
                Account account = accountDAO.GetAccountByUsername(username);
                if(account != null)
                {
                    if(account.Password == password)
                    {
                        GlobalUsername = username;
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login failed, please try again!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Login failed, please try again!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
