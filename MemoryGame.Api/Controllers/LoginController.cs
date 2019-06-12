using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MemoryGame.Shared.DTOS;
using MemoryGame.BusinessLogic.BLL;

namespace MemoryGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginBL _loginBL;

        public LoginController(LoginBL loginBL)
        {
            _loginBL = loginBL;
        }

        [HttpPost]
        public async Task<ActionResult<LightUserDataDTO>> Login([FromBody]UserLoginDTO userLoginDTO)
        {
            if (String.IsNullOrEmpty(userLoginDTO.UserName) || String.IsNullOrEmpty(userLoginDTO.Password))
                return BadRequest("User or password not supplied!");

            var result = await _loginBL.ValidateLogin(userLoginDTO);

            if (result == null)
                return BadRequest("User or password isn't correct!");

            return new JsonResult(result);
        }

        [Route("Logout")]
        [HttpPost]
        public async Task<ActionResult> Logout([FromBody] LightUserDataDTO userDto)
        {
            if (userDto.Id == 0 || String.IsNullOrEmpty(userDto.SessionKey))
                return BadRequest("Invalid user or Session to finalize!");

            var isCleared = await _loginBL.CleanSessionKey(userDto.Id, userDto.SessionKey);

            if (isCleared)
                return Ok(new { message= "Logout successful!" });

            return BadRequest("Session doesn't finalized!");
        }
    }
}