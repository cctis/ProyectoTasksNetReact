using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Models;
using TaskManagementApp.Services;

namespace TaskManagementApp.Controllers
{
    
    [Authorize]
    [Route("api/states")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateEntity>>> GetStates()
        {
            var states = await _stateService.GetStates();
            return Ok(states);
        }

        

        [HttpPost]
        public async Task<ActionResult<string>> CreateState(StateEntity state)
        {
            var result = await _stateService.CreateState(state);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateState(int id, StateEntity state)
        {
            var result = await _stateService.UpdateState(id, state);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteState(int id)
        {
            var result = await _stateService.DeleteState(id);
            return Ok(result);
        }
    }
}
