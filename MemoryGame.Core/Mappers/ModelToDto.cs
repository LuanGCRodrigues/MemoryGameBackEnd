using AutoMapper;
using MemoryGame.Core.Data.Models;
using MemoryGame.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGame.Core.Mappers
{
    public class ModelToDto : Profile
    {
        public ModelToDto()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, LightUserDataDTO>();
            CreateMap<Score, ScoreDTO>();
        }
    }
}
