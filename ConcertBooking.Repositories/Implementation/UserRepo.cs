using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Repositories.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> GetUserInfo(string userName, string password)
        {
            var user = await _context.UserInfos
                .FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower() &&
                x.Password == password);

            return user;
        }

        public async Task RegisterUser(UserInfo userInfo)
        {
            if(!Exists(userInfo.UserName))
            {
                await _context.UserInfos.AddAsync(userInfo);
                await _context.SaveChangesAsync();
            }
        }

        private bool Exists(string userName)
        {
            return _context.UserInfos.Any(x => x.UserName.ToLower() == userName.ToLower());
        }
    }
}
