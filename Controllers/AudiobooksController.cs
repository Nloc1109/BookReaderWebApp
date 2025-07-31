using Microsoft.AspNetCore.Mvc;

namespace BookReaderWebApp.Controllers
{
    public class AudiobooksController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Sách nói";
            return View("Audiobookhome");
        }
        
        public IActionResult Bestsellers()
        {
            ViewData["Title"] = "Bestseller sách nói";
            return View();
        }
        
        public IActionResult New()
        {
            ViewData["Title"] = "Sách nói mới";
            return View();
        }
        
        public IActionResult Narrators()
        {
            ViewData["Title"] = "Người đọc sách nói";
            return View();
        }
        
        public IActionResult Search(string q)
        {
            ViewData["Title"] = $"Tìm kiếm: {q}";
            ViewData["SearchQuery"] = q;
            return View();
        }
        
        public IActionResult Category(string category)
        {
            ViewData["Title"] = $"Sách nói - {category}";
            ViewData["Category"] = category;
            return View();
        }
        
        public IActionResult Details(int id)
        {
            ViewData["Title"] = "Chi tiết sách nói";
            ViewData["AudiobookId"] = id;
            return View();
        }
    }
} 