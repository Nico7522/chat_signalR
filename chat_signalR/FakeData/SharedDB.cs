using chat_signalR.models;
using System.Collections.Concurrent;

namespace chat_signalR.FakeData
{
    public class SharedDB
    {
        private readonly ConcurrentDictionary<string, UserConnection> _connection = new();
     
        public ConcurrentDictionary<string, UserConnection> connection => _connection;

        private  Dictionary<int, User> _usersList = new Dictionary<int, User>()
        {
            {
                1, new User() { Id = 1, Name= "Nicolas", status = 0}
            }
        };

        
        public Dictionary<int, User> UserList => _usersList;
    }
}
