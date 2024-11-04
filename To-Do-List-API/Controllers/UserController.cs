using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.Content.Task.DTO;
using To_Do_List_API.Content.Task.Interfaces;
using To_Do_List_API.Content.Task.Services;
using To_Do_List_API.Content.User.DTO;
using To_Do_List_API.Content.User.Interfaces;

namespace To_Do_List_API.Controllers;
/// <summary>
/// Controlador responsável pelas operações de gerenciamento de usuarios.
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    /// <summary>
    /// Obtém um usuario específico pelo ID.
    /// </summary>
    /// <param name="id">ID do usuario a ser obtido.</param>
    /// <returns>Um objeto <see cref="UserDto"/> representando o usuario encontrada.</returns>
    /// <response code="200">Retorna o usuario solicitado.</response>
    /// <response code="404">Se o usuario não for encontrado.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserbyId(int id)
    {
        try
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            return Ok(userDto);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    /// <summary>
    /// Cria um novo usuario
    /// </summary>
    /// <param name="userDto">Dados do usuario a ser criado.</param>
    /// <returns>O recurso recém-criado.</returns>
    /// <response code="201">Se o usuario for criada com sucesso.</response>
    /// <response code="400">Se o modelo do usuario for inválido.</response>
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
    {
        if (ModelState.IsValid)
        {
            await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserbyId), new { id = userDto.Id }, userDto);
        }
        return BadRequest(ModelState);
    }
    /// <summary>
    /// Atualiza um usuario
    /// </summary>
    /// <param name="id">ID do usuario a ser atualizado.</param>
    /// <param name="userDto">Dados do usuario a ser atualizado.</param>
    /// <returns>O recurso recém-atualizado.</returns>
    /// <response code="204">Se o usuario for atualizado com sucesso.</response>
    /// <response code="400">Se o modelo do usuario for inválido.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto, int id)
    {
        if (ModelState.IsValid)
        {
            await _userService.UpdateUserAsync(id, userDto);
            return NoContent();
        }
        return BadRequest(ModelState);
    }

    /// <summary>
    /// Deleta um usuario
    /// </summary>
    /// <param name="Id">Dados do usuario a ser deletado.</param>
    /// <returns>O recurso recém-atualizado.</returns>
    /// <response code="204">Se o usuario for deletado com sucesso.</response>
    /// <response code="400">Se o id do usuario for inválido.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (id != null)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        return BadRequest("ID de usuario não encontrado");
        
    }
    /// <summary>
    /// Obtém todos os usuarios.
    /// </summary>
    /// <response code="200">Retorna todos os usuarios solicitado.</response>
    /// <response code="404">Se nenhum usuario for encontrado.</response>
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        if (users == null || !users.Any())
        {
            return NotFound("No users found.");
        }

        return Ok(users);
    }

 

}