using API.DTOs;

namespace API.Services;
public interface IAuthManager
{
    Task<bool> ValidateUser(LoginUserDTO userDTO);
    Task<string> CreateToken();
    Task<string> CreateRefreshToken();
    Task<TokenRequest> VerifyRefreshToken(TokenRequest request);
}
