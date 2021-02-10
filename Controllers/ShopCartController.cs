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
    public class ShopCartController:Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep,ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.Items = items;
            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };

            return View(obj);

        }
        public RedirectToActionResult AddtoCart(int id)
        {
            var item =_carRep.Cars.FirstOrDefault(i => i.Id == id);
            if (item!= null)
            {
                _shopCart.AddItem(item);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            if (_shopCart.DeleteItems()==true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("NoGoods");
        }

        public IActionResult NoGoods()
        {
            ViewBag.Message = "У вас нету товаров в корзине";
            return View();
        }

    }
}
