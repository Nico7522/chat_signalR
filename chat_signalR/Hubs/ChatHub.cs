using chat_signalR.FakeData;
using chat_signalR.models;
using Microsoft.AspNetCore.SignalR;

namespace chat_signalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly SharedDB _sharedDB;
        public ChatHub(SharedDB sharedDB)
        {
            _sharedDB = sharedDB;
            
        }
    

        public async Task JoinChat(UserConnection conn)
        {
            await Clients.All.SendAsync("ReceiveMessage", "admin", $"{conn.Username} has joined");
        }

        public async Task JoinSpecificChatRoom(UserConnection conn)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);

            _sharedDB.connection[Context.ConnectionId] = conn;
            await Clients.Group(conn.ChatRoom).SendAsync("JoinSpecificChatRoom", "admin", $"{conn.Username} has joined {conn.ChatRoom}");
        }

        public async Task ReceiveSpecificMessage(string msg)
        {
            if (_sharedDB.connection.TryGetValue(Context.ConnectionId, out UserConnection? conn)) {
                await Clients.Group(conn.ChatRoom).SendAsync("ReceiveSpecificMessage", conn.Username, msg);
            }
        }

        public async Task PointingPresent(int id)
        {
            if(_sharedDB.UserList.TryGetValue(id, out User? userFound))
            {
                await Clients.All.SendAsync("PointingPresent", userFound);
            } 
          
        }
    }
}
