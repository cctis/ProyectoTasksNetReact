using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Models;
using TaskManagementApp.Server.Data;

namespace TaskManagementApp.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _context;

        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StateEntity>> GetAllStatesAsync()
        {
            return await _context.State.ToListAsync();
        }

        public async Task<StateEntity?> GetStateByIdAsync(int id)
        {
            return await _context.State.FindAsync(id);
        }

        public async Task AddStateAsync(StateEntity state)
        {
            _context.State.Add(state);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStateAsync(StateEntity state)
        {
            _context.State.Update(state);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStateAsync(int id)
        {
            var state = await _context.State.FindAsync(id);
            if (state != null)
            {
                _context.State.Remove(state);
                await _context.SaveChangesAsync();
            }
        }
    }
}
