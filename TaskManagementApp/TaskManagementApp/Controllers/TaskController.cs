using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Models;
using TaskManagementApp.Services;

namespace TaskManagementApp.Controllers
{
    
    [Authorize]
    [Route("api")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // Obtener la lista de tareas.
        [HttpGet("tasks")]
        public async Task<ActionResult<List<TaskEntity>>> GetTasks()
        {
            var tasks = await _taskService.GetTasks();
            return Ok(tasks);
        }

        // Obtener la lista de estados desde el servicio de tareas
        [HttpGet("listState")]
        public async Task<ActionResult<List<StateEntity>>> GetStates()
        {
            var states = await _taskService.GetStates();
            return Ok(states);
        }

        // Crear una nueva tarea.
        [HttpPost("tasks")]
        public async Task<ActionResult<string>> CreateTask(TaskEntity task)
        {
            var result = await _taskService.CreateTask(task);
            return Ok(result);
        }

        // Actualizar una tarea existente.
        [HttpPut("tasks/{id}")]
        public async Task<ActionResult<string>> UpdateTask(int id, TaskEntity task)
        {
            var result = await _taskService.UpdateTask(id, task);
            return Ok(result);
        }

        // Eliminar una tarea existente.
        [HttpDelete("tasks/{id}")]
        public async Task<ActionResult<string>> DeleteTask(int id)
        {
            var result = await _taskService.DeleteTask(id);
            return Ok(result);
        }
    }
}
