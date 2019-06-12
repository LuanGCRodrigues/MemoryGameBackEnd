using AutoMapper;
using MemoryGame.Core.Data.Models;
using MemoryGame.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGame.Core.Mappers
{
    public class DtoToModel : Profile
    {
        public DtoToModel()
        {
            CreateMap<UserDTO, User>();
            CreateMap<LightUserDataDTO, User>();
            CreateMap<ScoreDTO, Score>();
        }
    }
}
