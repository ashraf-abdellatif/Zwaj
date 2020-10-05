using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Data;
using ZwajApp.API.DTOs;
using ZwajApp.API.Models;

namespace ZwajApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        IAuthRepository _IAuthRepository;
        public AuthController(IAuthRepository IAuthRepository)
        {
            _IAuthRepository = IAuthRepository;
        }
        // POST api/Auth/Register
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserforRegisterDTO UserforRegisterDTO)
        {
            if( await _IAuthRepository.IsExistUser(UserforRegisterDTO.UserName))
            return BadRequest("هذا المستخدم مسجل من قبل");
            var UserForCreate = new User{
                UserName = UserforRegisterDTO.UserName
            };
            await _IAuthRepository.Register(UserForCreate , UserforRegisterDTO.PassWord);
            return Ok();
        }
    }
}