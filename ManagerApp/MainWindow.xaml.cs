using DataAccess.DAO;
using DataAccess.DataAccess;
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

namespace ManagerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnProductManager_Click(object sender, RoutedEventArgs e)
        {
            ProductManagement p = new ProductManagement();
            p.Show();
            Hide();
        }

        private void btnProductManager_Copy_Click(object sender, RoutedEventArgs e)
        {
            OrderManagement o = new OrderManagement();
            o.Show();
            Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginForm m = new LoginForm();
            m.Show();
            Hide();
        }

        private void btnAccountManager_Click(object sender, RoutedEventArgs e)
        {
            AccountManagement a = new AccountManagement();
            a.Show();
            Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AccountDAO accountDAO = new AccountDAO();
            Account account = accountDAO.GetAccountByUsername(LoginForm.GlobalUsername);
            if (account.Type != 1)
            {
                btnAccountManager.IsEnabled = false;
            }
        }
    }
}
