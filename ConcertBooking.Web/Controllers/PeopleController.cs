using ConcertBooking.Web.Data;
using ConcertBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var people = _context.Peoples.ToList();
            return View(people);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(People people)
        {
            _context.Peoples.Add(people);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = _context.Peoples.Find(id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(People people)
        {
            _context.Peoples.Update(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var person = _context.Peoples.Find(id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Delete(People people)
        {
            _context.Peoples.Remove(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var person = _context.Peoples.Find(id);
            return View(person);
        }
    }
}
