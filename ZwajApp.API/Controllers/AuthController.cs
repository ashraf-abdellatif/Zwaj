using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private IConfiguration _config;    
        public AuthController(IAuthRepository IAuthRepository ,IConfiguration config)
        {
            _IAuthRepository = IAuthRepository;
            _config = config;
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
         // POST api/Auth/login
        [HttpPost("login")]
        public async Task<ActionResult> login(UserforLoginDTO userforLoginDTO)
        {
           var user = await _IAuthRepository.Login(userforLoginDTO.UserName , userforLoginDTO.PassWord);
            if(user == null)
            return Unauthorized();
            var tokenString = GenerateJSONWebToken(user);
            return Ok(new { token = tokenString });
        }
    
     private string GenerateJSONWebToken(User user)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
              _config["Jwt:Issuer"],    
              null,    
              expires: System.DateTime.Now.AddMinutes(120),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
    
    
    }
}