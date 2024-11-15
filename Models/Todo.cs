namespace TodaAPI.Models
{
    public class Todo
    {
        // create a poco class for managing todo activities 
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;

        // Foreign key for User
        public int UserId { get; set; }
        public user User { get; set; }

        public Todo()
        {

        }

        public Todo(int id, string name, bool isComplete, string description, DateTime created, DateTime updated, int userId)
        {
            Id = id;
            Name = name;
            IsComplete = isComplete;
            Description = description;
            Created = created;
            Updated = updated;
            UserId = userId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Todo todo = (Todo)obj;
            return Id == todo.Id &&
                   Name == todo.Name &&
                   IsComplete == todo.IsComplete &&
                   Description == todo.Description &&
                   Created == todo.Created &&
                   Updated == todo.Updated &&
                   UserId == todo.UserId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, IsComplete, Description, Created, Updated, UserId);
        }

        public override string ToString()
        {
            return $"Todo [Id={Id}, Name={Name}, IsComplete={IsComplete}, Description={Description}, Created={Created}, Updated={Updated}, UserId={UserId}]";
        }
    }
}
