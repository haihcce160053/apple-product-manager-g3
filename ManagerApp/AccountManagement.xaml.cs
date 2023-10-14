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
    /// <summary>
    /// Interaction logic for AccountManagement.xaml
    /// </summary>
    public partial class AccountManagement : Window
    {
        public AccountManagement()
        {
            InitializeComponent();
            handleBeforeLoaded();
        }

        public void updateListView()
        {
            AccountDAO orDAO = new AccountDAO();
            lvAccount.ItemsSource = orDAO.GetAccount();
        }
        private void handleBeforeLoaded()
        {
            updateListView();
        }

        public Account getAccountObject()
        {
            Account acc = null;
            try
            {
                acc = new Account
                {
                    Username = txtUserName.Text,
                    Password = txtPassword.Text,
                    Fullname = txtFullName.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    Type = int.Parse(txtType.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return acc;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            Hide();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchKeyword = txtSearch.Text;
                AccountDAO orDAO = new AccountDAO();
                List<Account> searchResults = orDAO.SearchAccByUsername(searchKeyword);
                lvAccount.ItemsSource = searchResults;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account account = getAccountObject();
                AccountDAO proDAO = new AccountDAO();
                if (!proDAO.IsUserNameExists(account.Username, account.Email))
                {
                    proDAO.AddAccount(account);
                    updateListView();
                    MessageBox.Show("Add Success", "Add New Product");
                }
                else
                {
                    MessageBox.Show("UserName or Email already exist. Please try again!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Failed!", "Add New Product");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account product = getAccountObject();
                AccountDAO proDAO = new AccountDAO();
                proDAO.UpdateAccount(product);
                updateListView();
                MessageBox.Show("Update Success", "Update Account");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed!", "Update Account");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Account?", "Delete Account", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    Account acc = getAccountObject();
                    AccountDAO proDAO = new AccountDAO();
                    proDAO.DeleteAccount(acc);
                    updateListView();
                    MessageBox.Show("Delete successful", "Delete Account");
                }
                else
                {
                    MessageBox.Show("No Account were deleted.", "Delete Account");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Failed!", "Delete Account");
            }
        }
    }
}
