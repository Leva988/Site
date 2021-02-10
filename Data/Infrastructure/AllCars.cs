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
    public class AllCars : IAllCars
    {

        private readonly ICarsCategory _categoryCars = new CarsCategory();
 
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                        new Car{
                        Name ="Tesla",
                        ShortDesc ="red",
                        LongDesc ="dual motor",
                        Img ="/img/tesla.jpg",
                        Price =450000,
                        IsFavorite =true,
                        Available =false,
                        Category =_categoryCars.AllCategories.First() },

                    new Car{
                        Name ="BMW",
                        ShortDesc ="X6",
                        LongDesc ="jeep",
                        Img ="/img/BMW_X6.jpg",
                        Price =57000,
                        IsFavorite =true,
                        Available =true,
                        Category =_categoryCars.AllCategories.ElementAt(1) },

                      new Car{
                        Name ="Toyota",
                        ShortDesc ="Camry",
                        LongDesc ="sedan",
                        Img ="/img/ToyotaCamry.jpeg",
                        Price =28000,
                        IsFavorite =true,
                        Available =true,
                        Category =_categoryCars.AllCategories.ElementAt(2)},
                };
            }
        }
                       
        public IEnumerable<Car> GetFavCars { get; }

        public Car GetobjectCar(int CarID) { throw new NotImplementedException(); }
}

}
