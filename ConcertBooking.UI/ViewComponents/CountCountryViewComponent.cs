using ConcertBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.UI.ViewComponents
{
    public class CountCountryViewComponent : ViewComponent
    {
        private readonly ICountryRepo _countryRepo;

        public CountCountryViewComponent(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var countries = await _countryRepo.GetAll();
            var totalCount = countries.Count();
            return View(totalCount);
        }
    }
}
