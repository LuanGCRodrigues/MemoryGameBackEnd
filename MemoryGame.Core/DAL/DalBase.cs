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
    public class DalBase<TEntity> : IDalBase<TEntity> where TEntity : BaseModel
    {
        private readonly MemoryGameContext _context;
        private readonly DbSet<TEntity> entities;
        public DalBase(MemoryGameContext Context)
        {
            _context = Context;
            entities = _context.Set<TEntity>();
        }

        public Task<TEntity> Get(long id)
        {
            return entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return entities;
        }

        public TEntity Insert(TEntity entity)
        {
            try
            {
                entities.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                throw;
            }

        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);
            _context.SaveChanges();
        }
    }
}