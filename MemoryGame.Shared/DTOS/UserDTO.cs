namespace MemoryGame.Shared.DTOS
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SessionKey { get; set; }
        public bool IsDeleted { get; set; }
    }
}