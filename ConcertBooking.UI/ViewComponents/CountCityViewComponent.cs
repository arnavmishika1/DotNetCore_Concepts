using ConcertBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.UI.ViewComponents
{
    public class CountCityViewComponent : ViewComponent
    {
        private readonly ICityRepo _cityRepo;

        public CountCityViewComponent(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities = await _cityRepo.GetAll();
            int totalCount = cities.Count();
            return View(totalCount);
        }
    }
}
