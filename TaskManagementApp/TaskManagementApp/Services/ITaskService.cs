using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public interface ITaskService
    {
        Task<List<TaskEntity>> GetTasks();
        Task<string> CreateTask(TaskEntity task);
        Task<string> UpdateTask(int id, TaskEntity task);
        Task<string> DeleteTask(int id);
        Task<List<StateEntity>> GetStates();
    }
}
