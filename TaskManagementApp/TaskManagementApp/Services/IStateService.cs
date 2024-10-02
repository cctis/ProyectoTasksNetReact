using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public interface IStateService
    {
        Task<List<StateEntity>> GetStates();
        Task<string> CreateState(StateEntity state);
        Task<string> UpdateState(int id, StateEntity state);
        Task<string> DeleteState(int id);
    }
}
