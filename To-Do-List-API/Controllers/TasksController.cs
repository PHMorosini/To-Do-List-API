using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.Content.Task.DTO;
using To_Do_List_API.Content.Task.Interfaces;
using To_Do_List_API.Content.User.DTO;

namespace To_Do_List_API.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações de gerenciamento de tarefas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Obtém uma tarefa específica pelo ID.
        /// </summary>
        /// <param name="id">ID da tarefa a ser obtido.</param>
        /// <returns>Um objeto <see cref="taskDto"/> representando a task encontrada.</returns>
        /// <response code="200">Retorna a task solicitado.</response>
        /// <response code="404">Se a task não for encontrado.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            if (id != null)
            {
                var taskdto = await _taskService.GetTaskByIdAsync(id);
                return Ok(taskdto);
            }
            return BadRequest("Tarefa não encontrada");
        }

        /// <summary>
        /// Cria uma nova tarefa
        /// </summary>
        /// <param name="taskDto">Dados da tarefa a ser criada.</param>
        /// <returns>O recurso recém-criado.</returns>
        /// <response code="201">Se a tarefa for criada com sucesso.</response>
        /// <response code="400">Se o modelo da tarefa for inválido.</response>
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody]TaskCreateDto taskdto)
        {
            if (ModelState.IsValid)
            {
                await _taskService.AddTaskAsync(taskdto);
                return  CreatedAtAction(nameof(GetTaskById), new { id = taskdto.Id }, taskdto);
            }

            return BadRequest("O modelo da tarefa é invalido");
        }

    }
}
