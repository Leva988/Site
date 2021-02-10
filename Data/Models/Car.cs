using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.Models
{
    public class Car
    {
        [BsonId]
        public int Id { set; get; }

        public string Name { set; get; }

        public string ShortDesc { set; get; }

        public string LongDesc { set; get; }

        public string Img { set; get; }

        public uint Price { set; get; }

        public bool IsFavorite { set; get; }

        public bool Available { set; get; }

        public int CategoryID { set; get; }

        public virtual Category Category { set; get; }


    }
}
