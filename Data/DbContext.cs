using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data
{
    public class DbContext
    {
        private readonly IMongoDatabase _database = null;
        
        public DbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            if (client != null)
              _database = client.GetDatabase("Site");
        }

        public IMongoCollection<Car> Cars
        {
            get
            {
                return _database.GetCollection<Car>("Cars");
            }
        }

        public IMongoCollection<Category> Categories
        {
            get
            {
                return _database.GetCollection<Category>("Categories");
            }
        }

        public IMongoCollection<ShopCartItem> ShopCartItem
        {
            get
            {
                return _database.GetCollection<ShopCartItem>("ShopCartItem");
            }
        }

        public IMongoCollection<Order> Orders
        {
            get
            {
                return _database.GetCollection<Order>("Orders");
            }
        }

        public IMongoCollection<OrderDetail> OrderDetails
        {
            get
            {
                return _database.GetCollection<OrderDetail>("OrderDetails");
            }
        }


    }
}
