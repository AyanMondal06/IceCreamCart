using Microsoft.AspNetCore.Mvc;
using IceCreamCart.Infrastructure;
using IceCreamCart.Models;
using Microsoft.EntityFrameworkCore;
using IceCreamCart.Extensions;
using Microsoft.Identity.Client;


namespace IceCreamCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IceCreamCartContext context;
        public CategoryController(IceCreamCartContext context)
        {
            this.context = context;
        }
        public IActionResult index()
        {
            return View("");
        }
    }

}