using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        ITokenHelper _tokenHelper;
        IUserService _userService;

        public AuthManager(ITokenHelper tokenHelper, IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
           var claims = _userService.GetClaims(user);
           var accessToken = _tokenHelper.CreateToken(user, claims.Data);
           return new SuccessDataResult<AccessToken>(accessToken,"Token created"); 
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByUserName(userForLoginDto.UserName);

            if (userToCheck.Data== null)
            {
                return new ErrorDataResult<User>("Not Found");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
                {
                return new ErrorDataResult<User>("Password Error");
            }

            return new SuccessDataResult<User>(userToCheck.Data);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                UserName = userForRegisterDto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user,"User Added.");
        }

        public IResult UserMailExists(string email)
        {
            if (_userService.GetByMail(email).Data != null) {
                return new ErrorResult("Mail already exists");
            }
            return new SuccessResult();
        }

        public IResult UserNameExists(string userName) {
            if (_userService.GetByUserName(userName).Data!=null)
            {
                return new ErrorResult("Username already exists");
            }
            return new SuccessResult();
        }
    }
}
