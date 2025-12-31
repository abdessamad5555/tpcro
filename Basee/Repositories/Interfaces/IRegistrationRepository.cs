using Basee.Models;

namespace Basee.Repositories.Interfaces
{
    public interface IRegistrationRepository
    {
        Task AddAsync(registration entity);
        Task<IEnumerable<registration>> GetAllAsync();
        Task<registration?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
