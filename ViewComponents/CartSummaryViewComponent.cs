using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using NewCoreProject.Helpers;
using NewCoreProject.Models;

namespace NewCoreProject.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Get the cart from session, similar to what you do in the Cart view
            var cart = HttpContext.Session.GetObjectFromJson<List<Product>>("mycart") ?? new List<Product>();

            // You can pass the cart list directly, or a summary object
            return View(cart);
        }
    }
}
