using TaskManagementApp.Models;

namespace TaskManagementApp.Repositories
{
    public interface IStateRepository
    {
        Task<List<StateEntity>> GetAllStatesAsync();
        Task<StateEntity?> GetStateByIdAsync(int id);
        Task AddStateAsync(StateEntity state);
        Task UpdateStateAsync(StateEntity state);
        Task DeleteStateAsync(int id);
    }
}
