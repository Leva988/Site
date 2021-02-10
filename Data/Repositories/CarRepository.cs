using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Site.Data.interfaces;
using Site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.Repositories
{
    public class CarRepository : IAllCars
    {
        private readonly DbContext _context = null;

        public CarRepository()
        {
            _context = new DbContext();
        }

        public IEnumerable<Car> Cars => _context.Cars.Find(_ => true).ToList();

        public IEnumerable<Car> GetFavCars => _context.Cars.Find(c => c.IsFavorite).ToList();

        public Car GetobjectCar(int CarID)
        {
            return  _context.Cars.Find(Builders<Car>.Filter.Eq("_id", CarID)).FirstOrDefault();
        }
    }
}
