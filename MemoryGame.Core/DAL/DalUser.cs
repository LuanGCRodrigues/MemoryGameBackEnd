using MemoryGame.Core.Data.Context;
using MemoryGame.Core.Data.Models;

namespace MemoryGame.Core.DAL
{
  public class DalUser : DalBase<User>
  {
    public DalUser(MemoryGameContext Context) : base(Context)
    {
        
    }
  }
}