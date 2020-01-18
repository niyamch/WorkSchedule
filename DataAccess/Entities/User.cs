namespace DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
