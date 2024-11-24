using DSS.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SGME.Model;
using SGME.Repositories;
using SGME.Services;


namespace SGME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {

            _UserService = UserService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            var Users = await _UserService.GetAllUserAsync();
            return Ok(Users);
        }

        [HttpGet("{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<User>> GetUserById(int UserId)
        {
            var User = await _UserService.GetUserByIdSync(UserId);
            if (User == null)
                return NotFound();

            return Ok(User);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateUser(string Name, string Email, string Password, DateTime Date,int UserTypeId )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _UserService.CreateUserAsync(Name,Email,Password,Date,UserTypeId);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }


            return StatusCode(StatusCodes.Status201Created, "User created");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Si los datos no son válidos
            }

            var user = await _UserService.LoginAsync(loginDto.Email, loginDto.Password);

            if (user == null)
            {
                return Unauthorized("Credenciales inválidas.");
            }

            // Aquí podrías generar un token JWT o similar, pero por ahora retornamos los datos del usuario
            return Ok(new { message = "Inicio de sesión exitoso", userId = user.Id });
        }

        [HttpPut("{UserId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> UpdateUser(int UserId, string Name, string Email, string Password, User user)
        {
            var existingContentUser = await _UserService.GetUserByIdSync(UserId);
            if (existingContentUser == null)
                return NotFound();
            try
            {

                await _UserService.UpdateUserAsync(user);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpDelete("{UserId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> DeleteUser(int UserId)
        {
            var Content = await _UserService.GetUserByIdSync(UserId);
            if (Content == null)
                return NotFound();

            try
            {
                await _UserService.DeleteUserAsync(UserId);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);
            }

        }
    }
}
