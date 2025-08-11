
using ConcertBooking.Entities;

namespace ConcertBooking.Repositories.Interfaces
{
    public interface ICountryRepo
    {
        Task<IEnumerable<Country>> GetAll();
        Task<Country> GetById(int id);
        Task Save(Country country);
        Task Edit(Country country);
        Task RemoveData(Country country);
    }
}
