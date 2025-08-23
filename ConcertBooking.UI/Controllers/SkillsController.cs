using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.UI.ViewModels.SkillViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.UI.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillRepo _skillRepo;

        public SkillsController(ISkillRepo skillRepo)
        {
            _skillRepo = skillRepo;
        }

        public async Task<IActionResult> Index()
        {
            var skills = await _skillRepo.GetAll();
            List<SkillViewModel> vm = new List<SkillViewModel>();

            foreach (var skill in skills)
            {
                vm.Add(new SkillViewModel
                {
                    Id = skill.Id,
                    Title = skill.Title
                });
            }

            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSkillViewModel vm)
        {
            if (ModelState.IsValid) 
            { 
                Skill skill = new Skill
                {
                    Title = vm.Title
                };
                await _skillRepo.Save(skill);
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _skillRepo.GetById(id);
            SkillViewModel vm = new SkillViewModel
            {
                Id = skill.Id,
                Title = skill.Title
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SkillViewModel vm)
        {
            var skill = new Skill
            {
                Id = vm.Id,
                Title = vm.Title
            };
            await _skillRepo.Edit(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _skillRepo.GetById(id);
            await _skillRepo.RemoveData(skill);
            return RedirectToAction("Index");
        }
    }
}
