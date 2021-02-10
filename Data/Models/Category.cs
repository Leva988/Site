using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.Models
{
    public class Category
    {
        [BsonId]
        public int Id { set; get; }

        public string CategoryName { set; get; }

        public string Desc { set; get; }

    }
}
