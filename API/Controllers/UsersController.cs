using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getbymail")]
        [SecuredOperations("admin,moderator")]
        public IActionResult GetByMail(string mail) {
            var result = _userService.GetByMail(mail);
            if (result.Success) {
                return Ok(result);
                    }
            return BadRequest(result);
        }
        [HttpGet("getbyusername")]
        [SecuredOperations("admin,moderator")]
        public IActionResult GetByUserName(string userName) {
            var result = _userService.GetByUserName(userName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        [SecuredOperations("admin,moderator")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        [SecuredOperations("admin,moderator")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        [SecuredOperations("admin,moderator")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        [SecuredOperations("admin,moderator")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        [SecuredOperations("admin,moderator")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
