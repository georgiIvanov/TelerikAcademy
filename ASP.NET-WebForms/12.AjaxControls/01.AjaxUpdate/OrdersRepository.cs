using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.AjaxUpdate
{
    public class OrdersRepository
    {
        NorthwindEntities db = new NorthwindEntities();

        public List<Order> SelectOrders()
        {
            var found = db.Orders.ToList();
            return found;
        }
    }
}