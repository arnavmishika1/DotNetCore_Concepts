using System.Diagnostics;
using ConcertBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.Web.Controllers
{
    // Controller Class is implmented by all controllers and it provides
    // the base functionality for handling requests and responses.
    // It provides methods like View, Redirect, Json, Results, etc.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // IActionResult is the return type for action methods in controllers
        // View is a method that returns a ViewResult
        // and that ViewResult is inherited from ActionResult
        // and ActionResult is the base class for all action results.
        // and its iherited from IActionResult interface.

        // Do not pass string directly to View method, if you accidentally pass a string, it will throw an exception
        // because View method expects a model of type object or a view model.
        // if you want to pass 1. write View name as string and after comma pass string value as model
        // 2. or create a model class and pass that model class to the View.
        // 3. or you can use ViewData or ViewBag to pass data to the view.
        public IActionResult Index()
        {
            // Collection initializer syntax is used to create a list of People objects which is defined using {}
            List<People> people = new List<People>
            {
                new People { Id = 1, Name = "John Doe", City = "New York" },
                new People { Id = 2, Name = "Marry", City = "California" },
                new People { Id = 3, Name = "Rachin", City = "New Jersey" }
            };
            return View(people);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

// Difference between IActionResult and ActionResult:
// IActionResult is an interface that defines a contract for action results.
// ActionResult is a concrete class that implements the IActionResult interface.
// ActionResult provides a default implementation of the IActionResult interface
// and can be used as a base class for custom action results.
// ActionResult can be used to return different types of results like ViewResult, JsonResult, RedirectResult, etc.
// IActionResult is more flexible and can be used to return any type of result,
// while ActionResult is more specific and provides a default implementation for common action results.
// In general, you can use ActionResult when you want to return a specific type of result
// and use IActionResult when you want to return a more generic result that can be any type of action result.
// In most cases, you can use ActionResult as it provides a default implementation
// for common action results and is more convenient to use.
// However, if you need more flexibility or want to return a custom action result,
// you can use IActionResult as the return type for your action methods.
// In summary, ActionResult is a concrete class that implements the IActionResult interface,
// while IActionResult is an interface that defines a contract for action results.
// You can use ActionResult as the return type for your action methods
// when you want to return a specific type of result,
// and use IActionResult when you want to return a more generic result that can be any type of action result.
