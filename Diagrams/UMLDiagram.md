classDiagram
    class user {
        int Id
        string Name
        string Email
        string Password
        ICollection~Todo~ Todos
        user()
        user(int id, string name, string email, string password)
    }

    class Todo {
        int Id
        string Name
        bool IsComplete
        string Description
        DateTime Created
        DateTime Updated
        int UserId
        user User
        Todo()
        Todo(int id, string name, bool isComplete, string description, DateTime created, DateTime updated, int userId)
        bool Equals(object obj)
        int GetHashCode()
        string ToString()
    }

    user "1" --> "0..*" Todo : has
