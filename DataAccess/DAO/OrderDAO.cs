using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        public IEnumerable<Order> getOrderList()
        {
            List<Order> orders;
            try
            {
                var context = new AppleProductManagerContext();
                orders = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Get List Fail");
            }
            return orders;
        }

        public List<Order> SearchOrderByName(string orderName)
        {
            try
            {
                var context = new AppleProductManagerContext();
                List<Order> order = context.Orders
                    .Where(p => p.Username.Contains(orderName)).ToList();
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occurred!");
            }
        }
    }
}
