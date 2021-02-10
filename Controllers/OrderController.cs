using Microsoft.AspNetCore.Mvc;
using Site.Data;
using Site.Data.interfaces;
using Site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;


namespace Site.Controllers
{
    public class OrderController:Controller
    {
        private readonly IAllOrders _allorders;
        private readonly ShopCart _shopCart;
      
        public OrderController(IAllOrders allorders, ShopCart shopCart)
        {
            _allorders = allorders;
            _shopCart = shopCart;
        }

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            _shopCart.Items = _shopCart.GetShopItems();
            if (_shopCart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары в корзине");
                return  RedirectToAction("NoGoods");
            }
            else if (ModelState.IsValid)
            {
                _allorders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно офррмлен";
            _shopCart.DeleteItems();
            return View();
        }

        public IActionResult NoGoods()
        {
            ViewBag.Message = "У вас должны быть товары в корзине";
            return View();
        }
    }
}
