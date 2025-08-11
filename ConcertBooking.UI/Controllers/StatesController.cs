using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.UI.ViewModels.StateViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ConcertBooking.UI.Controllers
{
    public class StatesController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICountryRepo _countryRepo;

        public StatesController(IStateRepo stateRepo, ICountryRepo countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        public async Task<IActionResult> Index()
        {
            var states = await _stateRepo.GetAll();
            var vm = new List<StateViewModel>();
            foreach(var state in states)
            {
                vm.Add(new StateViewModel
                {
                    Id = state.Id,
                    StateName = state.Name,
                    CountryName = state.Country.Name
                });
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var countries = await _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStateViewModel vm)
        {
            var state = new State
            {
                Name = vm.StateName,
                CountryId = vm.CountryId
            };
            await _stateRepo.Save(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var state = await _stateRepo.GetById(id);
            var countries = await _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");

            var vm = new EditStateViewModel
            {
                Id = state.Id,
                StateName = state.Name,
                CountryId = state.CountryId
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditStateViewModel vm)
        {
            var state = new State
            {
                Id = vm.Id,
                Name = vm.StateName,
                CountryId = vm.CountryId
            };
            await _stateRepo.Edit(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var state = await _stateRepo.GetById(id);
            await _stateRepo.RemoveData(state);
            return RedirectToAction("Index");
        }
    }
}

// To transfer data from controller to view
// ViewBag: create Dynamic variable
// ViewData: uses ["Key"]=value pairs(Dictionary type data)
// ViewBag and ViewData only works for single HTTP request, once http request disposed
// no data remains in these two
// TempData: aslo uses ["Key"]=value pairs
// TempData can remains in 2 Request
// TempData methods: Keep() - use to store value for multiple requests 
