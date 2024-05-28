using API.Core.DTOs;
using API.Core.Services;
using API.Data.Entities;
using API.Core.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Areas;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<AccountController> _logger;
    private readonly IAuthManager _authManager;

    public AccountController(UserManager<IdentityUser> userManager,
        ILogger<AccountController> logger,
        IAuthManager authManager)
    {
        _userManager = userManager;
        _logger = logger;
        _authManager = authManager;
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
    {
        _logger.LogInformation($"Registration Attempt for {userDTO.Email} ");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = new IdentityUser(); // userDTO.IdentityUserToDTO(); // _mapper.Map<IdentityUser>(userDTO);
            user.Email = userDTO.Email;
            user.UserName = userDTO.Email;
            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(user, userDTO.Roles);
            return Accepted();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
            return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
    {
        _logger.LogInformation($"Login Attempt for {userDTO.Email} ");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            if (!await _authManager.ValidateUser(userDTO))
            {
                return Unauthorized();
            }

            return Accepted(new TokenRequest
            {
                Token = await _authManager.CreateToken(),
                RefreshToken = await _authManager.CreateRefreshToken()
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
            return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
        }
    }

    [HttpPost]
    [Route("refreshtoken")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
    {
        var tokenRequest = await _authManager.VerifyRefreshToken(request);
        if (tokenRequest is null)
        {
            return Unauthorized();
        }

        return Ok(tokenRequest);
    }
}