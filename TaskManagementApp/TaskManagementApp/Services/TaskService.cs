using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Models;
using TaskManagementApp.Repositories;
using TaskManagementApp.Server.Data;

namespace TaskManagementApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskEntity>> GetTasks()
        {
            return await _context.Task.Include(t => t.State).ToListAsync();
        }

        public async Task<string> CreateTask(TaskEntity task)
        {
            _context.Task.Add(task);
            await _context.SaveChangesAsync();
            return "Creado con éxito";
        }

        public async Task<string> UpdateTask(int id, TaskEntity task)
        {
            var taskDb = await _context.Task.FindAsync(id);
            if (taskDb == null)
                return "No se encuentra la tarea con el ID proporcionado.";

            taskDb.Title = task.Title;
            taskDb.StateId = task.StateId;
            await _context.SaveChangesAsync();
            return "Actualizado con éxito";
        }

        public async Task<string> DeleteTask(int id)
        {
            var taskDb = await _context.Task.FindAsync(id);
            if (taskDb == null)
                return "Tarea no encontrada";

            _context.Task.Remove(taskDb);
            await _context.SaveChangesAsync();
            return "Eliminado correctamente";
        }

        // Implementar el nuevo método para obtener la lista de estados
        public async Task<List<StateEntity>> GetStates()
        {
            return await _context.State.ToListAsync();
        }
    }
}
