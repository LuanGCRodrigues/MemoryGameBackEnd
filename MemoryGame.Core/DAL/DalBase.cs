using System.Collections.Generic;
using System.Threading.Tasks;
using MemoryGame.Core.Data.Context;
using MemoryGame.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Core.DAL
{
  public class DalBase<TEntity> : IDalBase<TEntity> where TEntity : BaseModel
  {
    private readonly MemoryGameContext _context;
    private readonly DbSet<TEntity> entities;
    public DalBase(MemoryGameContext Context)
    {
      _context = Context;
      entities = _context.Set<TEntity>();
    }

    public void Delete(TEntity entity)
    {
      throw new System.NotImplementedException();
    }

    public Task<TEntity> Get(long id)
    {
      return entities.FirstOrDefaultAsync(x => x.Id == id);
    }

    public IEnumerable<TEntity> GetAll()
    {
      throw new System.NotImplementedException();
    }

    public void Insert(TEntity entity)
    {
      throw new System.NotImplementedException();
    }

    public void Update(TEntity entity)
    {
      throw new System.NotImplementedException();
    }
  }
}