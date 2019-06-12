using MemoryGame.Core.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MemoryGame.Shared.DTOS;

namespace MemoryGame.BusinessLogic.BLL
{
    public class UserBL
    {
        private readonly DalUser _dal;
        public UserBL(DalUser dal)
        {
            _dal = dal;
        }

        public async Task<LightUserDataDTO> Get(int id)
        {
            LightUserDataDTO user = await _dal.GetById(id);
            return user;
        }

        public async Task<object> AddUser(UserDTO user)
        {
            try
            {
                var result = await _dal.InsertUser(user);

                if (result == null)
                    return new { errorMessage = "User already registered!", fail = true };

                return new { successMessage = "User saved successful!" , result };
            }
            catch (Exception e)
            {
                return new { errorMessage = "Error in save data", systemMessage = e.Message, fail = true } ;
            }
        }
    }
}
