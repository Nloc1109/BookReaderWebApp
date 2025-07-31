using Microsoft.AspNetCore.Mvc;

namespace BookReaderWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Thể loại sách";
            return View("Categoryhome");
        }

        public IActionResult Detail(string id)
        {
            // Decode URL parameter
            var categoryName = System.Web.HttpUtility.UrlDecode(id);
            ViewData["Title"] = categoryName;
            ViewData["CategoryName"] = categoryName;
            return View();
        }
    }
} 