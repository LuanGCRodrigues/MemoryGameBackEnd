using MemoryGame.Core.DAL;
using MemoryGame.Shared.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.BusinessLogic.BLL
{
    public class LoginBL
    {
        private readonly DalUser _dalUser;
        public LoginBL(DalUser dalUser)
        {
            _dalUser = dalUser;
        }

        public async Task<LightUserDataDTO> ValidateLogin(UserLoginDTO userDto)
        {
            var user = await _dalUser.GetByNamePass(userDto);

            if (user == null)
                return null;

            string now = DateTime.Now.ToString();
            string hash = (user.Name + now).GetHashCode().ToString();

            user = await _dalUser.UpdateSessionKey(user, hash, userDto.Password);

            return user;
        }

        public async Task<bool> CleanSessionKey(int id, string sessionKey)
        {
            var isCleared = await _dalUser.CleanSessionKey(id, sessionKey);
            return isCleared;
        }
    }
}
