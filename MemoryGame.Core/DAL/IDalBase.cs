using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoryGame.Core.Data.Context;
using MemoryGame.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Core.DAL
{
    public interface IDalBase<TEntity> where TEntity : BaseModel
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
    }
}