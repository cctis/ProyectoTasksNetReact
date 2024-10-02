using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Models;
using TaskManagementApp.Server.Data;

namespace TaskManagementApp.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskEntity>> GetAllTasksAsync()
        {
            return await _context.Task.Include(t => t.State).ToListAsync();
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(int id)
        {
            return await _context.Task.Include(t => t.State).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTaskAsync(TaskEntity task)
        {
            _context.Task.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskEntity task)
        {
            _context.Task.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Task.FindAsync(id);
            if (task != null)
            {
                _context.Task.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
