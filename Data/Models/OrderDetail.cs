using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.Models
{
    public class OrderDetail
    {
        [BsonId]
        public int Id { get; set; }

        public int OrderID { get; set; }

        public int CarID { get; set; }

        public uint Price { get; set; }

        public virtual Car Car { get; set; }

        public virtual Order Order { get; set; }

    }
}
