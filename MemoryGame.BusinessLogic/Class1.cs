using System;
using System.Threading.Tasks;
using MemoryGame.Core.DAL;
using MemoryGame.Core.Data.Models;

namespace MemoryGame.BusinessLogic
{
  public class Teste
  {
    private readonly DalUser _dal;
    public Teste(DalUser dal)
    {
      _dal = dal;
    }

    public async Task<string> Get()
    {
      var dal = await _dal.Get(1);
      return "opa";
    }
  }
}
