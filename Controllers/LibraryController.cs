using Microsoft.AspNetCore.Mvc;

namespace BookReaderWebApp.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            // Redirect /Library to /Library/Libraryhome
            return RedirectToAction("Libraryhome");
        }

        public IActionResult Libraryhome()
        {
            ViewData["Title"] = "Thư viện";
            return View();
        }

        public IActionResult Favorites()
        {
            ViewData["Title"] = "Sách yêu thích";
            return View();
        }

        public IActionResult BookmarkNotes()
        {
            ViewData["Title"] = "Đánh dấu & Ghi chú";
            return View();
        }

        public IActionResult ReadingProgress()
        {
            ViewData["Title"] = "Tiến độ đọc";
            return View();
        }

        public IActionResult ReadingHistory()
        {
            ViewData["Title"] = "Lịch sử đọc";
            return View();
        }
    }
} 