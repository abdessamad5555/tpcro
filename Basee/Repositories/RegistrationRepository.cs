using Basee.Data;
using Basee.Models;
using Basee.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Basee.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly BaseeContext _context;

        public RegistrationRepository(BaseeContext context)
        {
            _context = context;
        }

        public async Task AddAsync(registration entity)
        {
            await _context.registration.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<registration>> GetAllAsync()
        {
            return await _context.registration.ToListAsync();
        }

        public async Task<registration?> GetByIdAsync(int id)
        {
            return await _context.registration.FindAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.registration.AnyAsync(e => e.Id == id);
        }
    }
}
