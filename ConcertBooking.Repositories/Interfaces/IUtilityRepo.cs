using Microsoft.AspNetCore.Http;

namespace ConcertBooking.Repositories.Interfaces
{
    public interface IUtilityRepo
    {
        Task<string> SaveImage(string ContainerName, IFormFile file);
        Task<string> EditImage(string ContainerName, IFormFile file, string dbPath);
        Task DeleteImage(string ContainerName, string dbPath);
    }
}
