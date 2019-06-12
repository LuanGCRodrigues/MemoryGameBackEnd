using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGame.Shared.DTOS
{
    public class LightUserDataDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string SessionKey { get; set; }
    }
}
