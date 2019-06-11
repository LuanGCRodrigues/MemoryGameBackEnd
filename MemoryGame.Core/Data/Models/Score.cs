using System;

namespace MemoryGame.Core.Data.Models
{
  public class Score : BaseModel
  {
    public virtual User User { get; set; }
    public int CountPlay { get; set; }
    public Int64 TimePlay { get; set; }
  }
}