namespace App.Domain.Core.Hw20.Role.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<User.Entities.User> Users { get; set; }
    }
}
