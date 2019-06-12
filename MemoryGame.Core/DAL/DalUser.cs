using AutoMapper;
using MemoryGame.Core.Data.Context;
using MemoryGame.Core.Data.Models;
using MemoryGame.Shared.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryGame.Core.DAL
{
    public class DalUser : DalBase<User>
    {
        private readonly MemoryGameContext _context;
        private readonly DbSet<User> _userEntity;
        private readonly IMapper _mapper;
        public DalUser(MemoryGameContext context,  IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _userEntity = _context.Set<User>();
        }

        public async Task<LightUserDataDTO> GetById(int id)
        {
            User user = await Get(id);
            return _mapper.Map<LightUserDataDTO>(user);
        }

        public async Task<LightUserDataDTO> GetByNamePass(UserLoginDTO userDto)
        {
            User user = _userEntity.Where(x => x.UserName == userDto.UserName && x.Password == userDto.Password).FirstOrDefault();
            return _mapper.Map<LightUserDataDTO>(user);
        }

        public async Task<LightUserDataDTO> UpdateSessionKey(LightUserDataDTO userDto, string newSessionKey, string password)
        {
            User user = _userEntity.Where(x => x.UserName == userDto.UserName && x.Password == password).FirstOrDefault();

            user.SessionKey = newSessionKey;
            _context.SaveChanges();

            return _mapper.Map<LightUserDataDTO>(user);
        }

        public async Task<bool> CleanSessionKey(int id, string sessionKey)
        {
            User user = _userEntity.Where(x => x.Id == id && x.SessionKey == sessionKey).FirstOrDefault();

            if (user == null)
                return false;

            user.SessionKey = "";
            _context.SaveChanges();

            return true;
        }

        public async Task<LightUserDataDTO> InsertUser(UserDTO userDto)
        {
            User user = _userEntity.Where(x => x.UserName == userDto.UserName).FirstOrDefault();

            if (user != null)
                return null;

            user = _mapper.Map<User>(userDto);

            user = Insert(user);
            return _mapper.Map<LightUserDataDTO>(user);
        }
    }
}