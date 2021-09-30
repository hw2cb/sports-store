using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} был сохранен"; //словарь, хранится до тех пор пока не будет прочитан
                //данные в темпдата ограничиваются сеансом одного пользователя, другие не видят объекты друг друга и хранятся долго, что бы быть прочитанными
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Create() => View("Edit", new Product());
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if(deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} был удален";
            }
            return RedirectToAction("Index");
        }
    }
}