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
    public partial class ProductManagement : Window
    {
        public ProductManagement()
        {
            InitializeComponent();
            handleBeforeLoaded();
        }
        public void updateListView()
        {
            ProductDAO proDAO = new ProductDAO();
            lvProducts.ItemsSource = proDAO.getProductList();
        }
        //public void updateListView()
        //{
        //    ProductDAO proDAO = new ProductDAO();
        //    IEnumerable<Product> products = proDAO.getProductList();
        //    var productNames = products.Select(p => new
        //    {
        //        ProductId = p.ProductId,
        //        Name = p.Name,
        //        Description = p.Description,
        //        Quantity = p.Quantity,
        //        TypeName = p.TypeNavigation.TypeName
        //    });
        //    lvProducts.ItemsSource = productNames;
        //}

        private void handleBeforeLoaded()
        {
            updateListView();
        }

        public Product getProductObject()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    Name = txtProductName.Text,
                    Description = txtDescription.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    Type = int.Parse(cbType.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return product;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = getProductObject();
                ProductDAO proDAO = new ProductDAO();
                if (!proDAO.IsProductExists(product.Name))
                {
                    proDAO.addNewProduct(product);
                    updateListView();
                    MessageBox.Show("Add Success", "Add New Product");
                }
                else
                {
                    MessageBox.Show("This Product already exist. Please try again!");
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
                Product product = getProductObject();
                ProductDAO proDAO = new ProductDAO();
                proDAO.updateProduct(product);
                updateListView();
                MessageBox.Show("Update Success", "Update Product");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed!", "Update Product");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    Product product = getProductObject();
                    ProductDAO proDAO = new ProductDAO();
                    proDAO.deleteProduct(product);
                    updateListView();
                    MessageBox.Show("Delete successful", "Delete Product");
                }
                else
                {
                    MessageBox.Show("No products were deleted.", "Delete Product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Failed!", "Delete Product");
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

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchKeyword = txtSearch.Text;
                ProductDAO orDAO = new ProductDAO();
                List<Product> searchResults = orDAO.SearchProductByName(searchKeyword);
                lvProducts.ItemsSource = searchResults;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
