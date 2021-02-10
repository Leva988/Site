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
    public class CategoryRepository : ICarsCategory
    {
        private readonly DbContext _context = null;

        public CategoryRepository()
        {
            _context = new DbContext();
        }
        public IEnumerable<Category> AllCategories => _context.Categories.Find(_ =>true).ToList();
    }
}
