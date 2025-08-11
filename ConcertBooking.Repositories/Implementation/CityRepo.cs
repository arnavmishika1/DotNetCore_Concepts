using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ConcertBooking.Repositories.Implementation
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;

        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.Cities.Include(x => x.State)
                        .ThenInclude(y => y.Country).ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task RemoveData(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task Save(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }
    }
}
