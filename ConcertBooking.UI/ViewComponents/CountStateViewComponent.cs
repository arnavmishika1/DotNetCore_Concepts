using ConcertBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.UI.ViewComponents
{
    public class CountStateViewComponent : ViewComponent
    {
        private readonly IStateRepo _stateRepo;

        public CountStateViewComponent(IStateRepo stateRepo)
        {
            _stateRepo = stateRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var states = await _stateRepo.GetAll();
            var totalCount = states.Count();
            return View(totalCount);
        }
    }
}
