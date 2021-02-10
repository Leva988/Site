using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.Models
{
    public class ShopCart
    {
        public string ShopCartId { get; set; }

        public IEnumerable<ShopCartItem> Items { get; set; }

        private readonly DbContext _context = null;

        public ShopCart()
        {
            _context = new DbContext();
        }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart() { ShopCartId = shopCartId };
        }

        public IEnumerable<ShopCartItem> GetShopItems()
        {
            var item = _context.ShopCartItem.Find(_=> true).ToList();
            return item;
        }

        public void AddItem(Car car)
        {
            _context.ShopCartItem.InsertOne(new ShopCartItem
            {
                ItemId = car.Id,
                Car = car,
                ShopCartId = ShopCartId
            });
        }

        public bool DeleteItems()
        {
            DeleteResult deleteResult = _context.ShopCartItem.DeleteMany(_=> true);
            return  deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

    }
}
