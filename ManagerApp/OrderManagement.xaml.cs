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
using System.Windows.Shapes;

namespace ManagerApp
{
    public partial class OrderManagement : Window
    {
        public OrderManagement()
        {
            InitializeComponent();
            handleBeforeLoaded();
        }

        public void updateListView()
        {
            OrderDAO orDAO = new OrderDAO();
            lvOrder.ItemsSource = orDAO.getOrderList();
        }
        private void handleBeforeLoaded()
        {
            updateListView();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchKeyword = txtSearch.Text;
                OrderDAO orDAO = new OrderDAO();
                List<Order> searchResults = orDAO.SearchOrderByName(searchKeyword);
                lvOrder.ItemsSource = searchResults;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AccountDAO accountDAO = new AccountDAO();
            Account account = accountDAO.GetAccountByUsername(LoginForm.GlobalUsername);
            MainWindow m = new MainWindow();
            if (account.Type == 1)
            {
                m.Show();
                Hide();
            }
            else
            {
                m.btnAccountManager.IsEnabled = false;
                m.Show();
                Hide();
            }
        }
    }
}
