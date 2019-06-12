using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemoryGame.BusinessLogic.BLL;
using MemoryGame.Shared.DTOS;

namespace MemoryGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBL _userBL;

        public UserController(UserBL userBL)
        {
            _userBL = userBL;
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LightUserDataDTO>> Get(int id)
        {
            if (id == 0)
                return BadRequest(new { message = "Id is necessary!" });

            var user = await _userBL.Get(id);
            return new JsonResult(user);
        }

        // POST api/user
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] UserDTO user)
        {
            if (UserIsValid(user))
            {
                string now = DateTime.Now.ToString();
                user.SessionKey = (user.Name + now).GetHashCode().ToString();

                var result = await _userBL.AddUser(user);
                return result;
            }
            else
            {
                return BadRequest(new { errorMessage = "Invalid Data" });
            }
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool UserIsValid(UserDTO user)
        {
            if (String.IsNullOrEmpty(user.Name) || String.IsNullOrEmpty(user.Password) || String.IsNullOrEmpty(user.UserName))
                return false;

            return true;
        }
    }
}
