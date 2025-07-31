using Microsoft.AspNetCore.Mvc;

namespace BookReaderWebApp.Controllers
{
    [Route("E-Book")]
    public class EBookController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View("~/Views/E-Book/Ebookhome.cshtml");
        }
    }
} 