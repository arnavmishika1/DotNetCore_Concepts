using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.UI.ViewModels.UserInfoViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConcertBooking.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepo _userRepo;

        public AuthController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserInfoViewModel vm)
        {
            var model = new UserInfo
            {
                UserName = vm.Username,
                Password = vm.Password
            };
            await _userRepo.RegisterUser(model);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserInfoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var userInfo = await _userRepo.GetUserInfo(vm.Username, vm.Password);
                if (userInfo != null)
                {
                    HttpContext.Session.SetInt32("userId", userInfo.UserId);
                    HttpContext.Session.SetString("userName", userInfo.UserName);
                    return RedirectToAction("Index", "Countries");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
