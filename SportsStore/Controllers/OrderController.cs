using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repositroy;
        private Cart cart;
        public OrderController(IOrderRepository repo, Cart cartService)
        {
            repositroy = repo;
            cart = cartService;
        }
        [Authorize]
        public ViewResult List() => View(repositroy.Orders.Where(o => !o.Shipped));
        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderID)
        {
            //306
            Order order = repositroy.Orders.FirstOrDefault(o => o.OrderID == orderID);
            if(order !=null)
            {
                order.Shipped = true;
                repositroy.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.Lines.Count()==0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста!");
            }
            if(ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray(); //получаем корзину из сервиса и записываем ее в наш поулченый Order
                repositroy.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }//308
}