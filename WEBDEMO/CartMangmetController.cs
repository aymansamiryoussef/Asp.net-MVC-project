using BusinessLayer.Interface;
using BusinessLayer.Reprosetory;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEBDEMO.Session_Extension_Methods;

namespace WEBDEMO.Controllers
{
    public class CartMangmetController : Controller
    {
        private readonly IProudctReprository proudctReprository;
        public CartMangmetController(IProudctReprository _proudctReprository)
        {
            proudctReprository = _proudctReprository;


        }
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetCart();
            var cartItems= cart.Items.ToList();
            ViewBag.totalprice= cart.TotalPrice;
            return View("CartView",cartItems);
        }

        public IActionResult AddToCart(int id, int Quantity = 1)
        {
            var cart = HttpContext.Session.GetCart();

            var proudct = proudctReprository.GetByID(id);

            var cartItem = cart.Items.FirstOrDefault(i=>i.ProudctId==proudct.Id);

            if(cartItem!=null)
            {

                cartItem.Quantity += Quantity;

            }
            else
            {

                cart.Items.Add(new CartItems
                {
                    ProudctId = proudct.Id,
                    ImageUrl=proudct.ImageUrl,
                    Quantity = Quantity,
                    Price = proudct.Price,
                    ProudctName=proudct.Name,
                    
                });

            }

            HttpContext.Session.SetCart(cart);

            var cartcount = cart.Items.Sum(i => i.Quantity);
            HttpContext.Session.SetInt32("CartItemCount", cartcount);

            return Json(new { success = true, message = "Item added to cart.",cartcount });


        }

       

        [HttpPost]
        public IActionResult UpdateQuantity(int id, int change)
        {
            var cart = HttpContext.Session.GetCart();
            var item = cart.Items.FirstOrDefault(i => i.ProudctId == id);

            if (item != null)
            {
                item.Quantity += change;

                // Ensure the quantity does not go below 1
                if (item.Quantity < 1)
                {
                    cart.Items.Remove(item); // Remove item if quantity is less than 1
                }

                // Save the updated cart back to session
                HttpContext.Session.SetCart(cart);
  
                

                return Json(new { success = true, newQuantity = item.Quantity });
            }

            return Json(new { success = false });
        }

    }
}
