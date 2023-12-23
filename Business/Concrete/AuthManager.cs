using Business.Constants;
using Core.DTOs;
using Core.Entities.Concrete;
using Core.Utilities.Authentication;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Concrete
{

    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<IResult> Login(LoginDto request)
        {
            var hasUser = await _userManager.FindByNameAsync(request.UserName);
            var checkedUser = await _userManager.CheckPasswordAsync(hasUser, request.Password);

            if (request.UserName == String.Empty || request.Password == String.Empty)
            {
                return new ErrorResult(LoginErrorMessages.EMPTY_NICK_OR_PASSWORD);
            }
            if (hasUser != null && checkedUser)
            {
                var userRoles = await _userManager.GetRolesAsync(hasUser);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, hasUser.UserName),
                    new Claim(ClaimTypes.NameIdentifier, hasUser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);
                return new SuccessDataResult<TokenDto>
                    (new TokenDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                }, SuccessMessages.OK);
            }

         

            return new ErrorDataResult<TokenDto>(LoginErrorMessages.WRONG_NICK_OR_PASSWORD);
        }

        public async Task<IResult> Register(RegisterDto request)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)

                return new ErrorResult(ErrorMessages.USER_ALREADY_EXISTS);

            AppUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded) {
               
            return new ErrorDataResult<string>();
            }
            return new SuccessResult(SuccessMessages.OK);
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:SecurityKey"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtToken:Issuer"],
                audience: _configuration["JwtToken:Audience"],
                expires: DateTime.Now.AddMinutes(_configuration.GetValue<int>("Expiration")),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private string getMultipleErrors(IdentityResult result)
        {
            string results = "";
            foreach (var item in result.Errors)
            {
                results += item.Description + "\n";

            }
            return results;
        }
    }

}