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
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDto taskdto)
        {
            if (ModelState.IsValid)
            {
                await _taskService.AddTaskAsync(taskdto);
                return CreatedAtAction(nameof(GetTaskById), new { id = taskdto.Id }, taskdto);
            }

            return BadRequest("O modelo da tarefa é invalido");
        }

        /// <summary>
        /// Atualiza uma tarefa
        /// </summary>
        /// <param name="taskDto">Dados da tarefa a ser atualizada.</param>
        /// /// <param name="id">ID da tarefa a ser atualizada.</param>
        /// <returns>O recurso recém-atualizado.</returns>
        /// <response code="201">Se a tarefa for atualizada com sucesso.</response>
        /// <response code="400">Se o modelo da tarefa for inválido.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskDto taskdto, int id)
        {
            if (ModelState.IsValid)
            {
                await _taskService.UpdateTaskAsync(id, taskdto);
                return Ok(taskdto);
            }

            return BadRequest("O modelo da tarefa é invalido");
        }

        /// <summary>
        /// Deleta uma tarefa
        /// </summary>
        /// <param name="Id">Id da tarefa a ser Deletada.</param>
        /// <returns>O recurso deletado.</returns>
        /// <response code="201">Se a tarefa for Deleta com sucesso.</response>
        /// <response code="400">Se o id da tarefa for inválido.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (id != null)
            {
                await _taskService.DeleteTaskAsync(id);
                return Ok();
            }

            return BadRequest("A tarefa com o ID selecionado não foi encontrada");
        }
        /// <summary>
        /// Retorna todas as tarefas
        /// </summary>
        /// <returns>Uma lista com todas as tarefas .</returns>
        /// <response code="201">Se as tarefas foram retornadas com sucesso.</response>
        /// <response code="400">Se nenhum tarefa foi retornada.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            if (tasks == null || !tasks.Any())
            {
                return NotFound("Nenhuma tarefa foi encontrada.");
            }

            return Ok(tasks);
        }
        /// <summary>
        /// Retorna todas as tarefas associadas a um usuário específico.
        /// </summary>
        /// <param name="id">ID do usuário cujas tarefas serão recuperadas.</param>
        /// <returns>Uma lista de tarefas associadas ao usuário.</returns>
        /// <response code="200">Retorna a lista de tarefas associadas ao usuário.</response>
        /// <response code="404">Se não forem encontradas tarefas relacionadas ao usuário.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTasksByUser(int id)
        {
            var tasks = await _taskService.GetAllTasksByUser(id);
            if(tasks == null || !tasks.Any())
            {
                return NotFound("Nehuma tarefa relacionada a esse usuario foi encontrada");
            }
            return Ok(tasks);
        }
    }

}
