using System;

namespace MemoryGame.Shared.DTOS
{
    public class ScoreDTO
    {
        public int Id { get; set; }
        public virtual UserDTO User { get; set; }
        public int CountPlay { get; set; }
        public Int64 TimePlay { get; set; }
    }
}