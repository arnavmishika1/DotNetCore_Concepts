using ConcertBooking.Entities;

namespace ConcertBooking.Repositories.Interfaces
{
    public interface ICityRepo
    {
        Task<IEnumerable<City>> GetAll();
        Task<City> GetById(int id);
        Task Save(City city);
        Task Edit(City city);
        Task RemoveData(City city);
    }
}
