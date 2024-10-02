using TaskManagementApp.Models;

namespace TaskManagementApp.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetAllTasksAsync();
        Task<TaskEntity?> GetTaskByIdAsync(int id);
        Task AddTaskAsync(TaskEntity task);
        Task UpdateTaskAsync(TaskEntity task);
        Task DeleteTaskAsync(int id);
    }
}
