using MongoDB.Driver;
using Site.Data.interfaces;
using Site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.Repositories
{
    public class OrdersRepository : IAllOrders
    {
        private readonly DbContext _context = null;
        private readonly ShopCart _shopCart;

        public  OrdersRepository(DbContext context,ShopCart shopCart)
        {
            _context = context;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _context.Orders.InsertOne(order);

            var items = _shopCart.Items;
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = el.Car.Id,
                    OrderID = order.Id,
                    Price = el.Car.Price
                };
                _context.OrderDetails.InsertOne(orderDetail);
            }
           
        }
    }
}
