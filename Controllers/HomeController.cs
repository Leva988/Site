using Microsoft.AspNetCore.Mvc;
using Site.Data.interfaces;
using Site.Data.Models;
using Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class HomeController:Controller
    {
        private readonly IAllCars _carRep;
      
        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavCars = _carRep.GetFavCars
            };
            return View(homeCars);
        }
    }
}
