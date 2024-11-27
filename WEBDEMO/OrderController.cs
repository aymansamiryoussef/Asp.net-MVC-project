using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WEBDEMO.Session_Extension_Methods;

namespace WEBDEMO.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationContextClass _contextClass;
        public OrderController(ApplicationContextClass contextClass)
        {
            _contextClass = contextClass;
        }
        [HttpPost]
        public IActionResult SetOrder()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIN", "Account");
            }
            else
            {
                var cart = HttpContext.Session.GetCart();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



                var order = new Order

                {
                    UserID = userId,
                    OrderDate = DateTime.Now,
                    OrderStatus = "Confirmed",
                    Items = cart.Items.Select(item => new Orderitem
                    {

                        ProductID = item.ProudctId,
                        quantity = item.Quantity,
                        price = item.Price,
                        TotalPrice = item.TotalPrice,

                    }).ToList(),

                    TotalAmount= cart.Items.Sum(i =>i.TotalPrice ),
                };


                _contextClass.orders.Add(order);
                _contextClass.SaveChanges();


                HttpContext.Session.Remove("Cart");

                TempData["OrderSuccessMessage"] = "Your order has been placed successfully!";

                // Redirect to the product page
                return RedirectToAction("Index", "Proudct");

            }

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
