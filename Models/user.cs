namespace TodaAPI.Models
{
    public class user
    {
        // create a poco class for managing users with basic properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation property for related Todos
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();

        public user()
        {

        }

        public user(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
