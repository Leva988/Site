using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Site.Data.interfaces;
using Site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.Infrastructure
{
    public class CarsCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                   new Category { CategoryName = "электрокары" , Desc ="Илон Маск рулит" },
                   new Category { CategoryName = "бензиновые автомобили", Desc = "ДВС" },
                   new Category { CategoryName = "дизельные автомобили", Desc = "ДВС" }
                };

            }
        }
    }
}
