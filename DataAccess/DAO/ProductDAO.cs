using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        public IEnumerable<Product> getProductList()
        {
            List<Product> products;
            try
            {
                var context = new AppleProductManagerContext();
                products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occurred!");
            }
            return products;
        }

        public Product getProductByID(int id)
        {

            Product product = null;
            try
            {
                using var context = new AppleProductManagerContext();
                product = context.Products.SingleOrDefault(c => c.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occurred!");
            }
            return product;
        }

        public void addNewProduct(Product product)
        {
            try
            {
                Product _product = getProductByID(product.ProductId);
                if (_product == null)
                {
                    var context = new AppleProductManagerContext();
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product is already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occurred!");
            }
        }

        public void updateProduct(Product product)
        {
            try
            {
                Product _product = getProductByID(product.ProductId);
                if (_product != null)
                {
                    var context = new AppleProductManagerContext();
                    context.Entry<Product>(product).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occurred!");
            }
        }

        public void deleteProduct(Product product)
        {
            try
            {
                Product _product = getProductByID(product.ProductId);
                if (_product != null)
                {
                    var context = new AppleProductManagerContext();
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occurred!");
            }
        }

        public bool IsProductExists(string proName)
        {
            using (var context = new AppleProductManagerContext())
            {
                return context.Products.Any(m => m.Name == proName);
            }
        }

        public List<Product> SearchProductByName(string proName)
        {
            try
            {
                var context = new AppleProductManagerContext();
                List<Product> pro = context.Products
                    .Where(p => p.Name.Contains(proName)).ToList();
                return pro;
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occurred!");
            }
        }
    }
}
