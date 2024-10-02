using TaskManagementApp.Models;
using TaskManagementApp.Repositories;

namespace TaskManagementApp.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        // Obtener la lista de estados
        public async Task<List<StateEntity>> GetStates()
        {
            return await _stateRepository.GetAllStatesAsync();
        }

        // Crear un nuevo estado
        public async Task<string> CreateState(StateEntity state)
        {
            try
            {
                await _stateRepository.AddStateAsync(state);
                return "Estado creado con éxito";
            }
            catch (Exception ex)
            {
                return $"Error al crear el estado: {ex.Message}";
            }
        }

        // Actualizar un estado existente
        public async Task<string> UpdateState(int id, StateEntity state)
        {
            var existingState = await _stateRepository.GetStateByIdAsync(id);
            if (existingState == null)
            {
                return "No se encuentra el estado con el ID proporcionado";
            }

            try
            {
                existingState.StateName = state.StateName;
                await _stateRepository.UpdateStateAsync(existingState);
                return "Estado actualizado con éxito";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el estado: {ex.Message}";
            }
        }

        // Eliminar un estado existente
        public async Task<string> DeleteState(int id)
        {
            try
            {
                await _stateRepository.DeleteStateAsync(id);
                return "Estado eliminado con éxito";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el estado: {ex.Message}";
            }
        }
    }
}
