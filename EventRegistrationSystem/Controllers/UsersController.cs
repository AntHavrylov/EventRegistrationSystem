using EventRegistrationSystem.Mapping;
using EventRegistrationSystem.Models.Dtos;
using EventRegistrationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistrationSystem.Controllers
{

    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEncryptionService _encryptionService;

        public UsersController(
            IUserService userService,
            IEncryptionService encryptionService)
        {
            _userService = userService;
            _encryptionService = encryptionService;
        }

        [Authorize]
        [HttpPost(ApiEndpoints.Users.Register)]
        public async Task<IActionResult> RegisterUser(
            [FromBody] RegisterUserRequest request,
            CancellationToken ct)
        {
            var user = request.ToUser(_encryptionService);
            var result = await _userService.CreateUserAsync(user, ct);
            if(!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost(ApiEndpoints.Users.Login)]
        public async Task<IActionResult> LoginUser(
            [FromBody] LoginUserRequest request,
            CancellationToken ct)
        {
            var token = await _userService.LoginAsync(request.Email, request.Password, ct);
            return Ok(token);
        }
    }
}
