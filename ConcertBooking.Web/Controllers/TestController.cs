using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.Web.Controllers
{
    public class TestController : Controller
    {
        static int _counter = 0;
        public IActionResult ShowButton()
        {
            return View();
        }
        public IActionResult ClickAction()
        {
            ++_counter;
            return View("ShowButton", _counter);
        }
    }
}
