using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoryGame.Core.Data.Context;
using MemoryGame.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Core.DAL
{
  public interface IDalBase<TEntity> where TEntity : BaseModel
  {
    IEnumerable<TEntity> GetAll();
    Task<TEntity> Get(long id);
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
  }
}