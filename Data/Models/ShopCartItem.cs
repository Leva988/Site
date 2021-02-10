using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.Models
{
    public class ShopCartItem
    {
        [BsonId]
        public int ItemId { get; set; }
        public Car Car  { get ;set; }

        public string ShopCartId { get; set; }

    }
}
