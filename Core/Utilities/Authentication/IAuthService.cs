using Core.DTOs;
using Core.Utilities.Results;

namespace Core.Utilities.Authentication
{

    public interface IAuthService
    {
        Task<IResult> Login(LoginDto request);
        Task<IResult> Register(RegisterDto request);

    }
}