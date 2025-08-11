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
    public class StateRepo : IStateRepo
    {
        private readonly ApplicationDbContext _context;

        public StateRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(State state)
        {
            _context.States.Update(state);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            // Include is specified here for Eager loading of EF.
            // It is doing inner join of SQL internally
            return await _context.States.Include(x => x.Country).ToListAsync();
        }

        public async Task<State> GetById(int id)
        {
            // Find always works with primary key
            return await _context.States.FindAsync(id);
        }

        public async Task RemoveData(State state)
        {
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
        }

        public async Task Save(State state)
        {
            await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();
        }
    }
}
