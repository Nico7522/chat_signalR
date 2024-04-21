using chat_signalR.models;
using System.Collections.Concurrent;

namespace chat_signalR.FakeData
{
    public class SharedDB
    {
        private readonly ConcurrentDictionary<string, string> _connection = new();
     
        public ConcurrentDictionary<string, string> connection => _connection;

        private  Dictionary<int, User> _usersList = new Dictionary<int, User>()
        {
            { 1, new User() { Id = 1, Name = "Nicolas", Status = 0 } },
            { 2, new User() { Id = 2, Name = "Valentin", Status = 0 } },
            { 3, new User() { Id = 3, Name = "Ryan", Status = 0 } },
            { 4, new User() { Id = 4, Name = "Emma", Status = 1 } },
            { 5, new User() { Id = 5, Name = "Sophie", Status = 2 } },
            { 6, new User() { Id = 6, Name = "Lucas", Status = 2 } },
            { 7, new User() { Id = 7, Name = "Léa", Status = 0 } },
            { 8, new User() { Id = 8, Name = "Thomas", Status = 1 } },
            { 9, new User() { Id = 9, Name = "Camille", Status = 2 } }
        };

        
        public Dictionary<int, User> UserList => _usersList;
    }
}
