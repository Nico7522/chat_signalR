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

        public async Task JoinSpecificChatRoom(string name, string roomNumber)
        {
            _sharedDB.connection[Context.ConnectionId] = name;
            await Groups.AddToGroupAsync(Context.ConnectionId, roomNumber);
            await Clients.Group(roomNumber).SendAsync("JoinSpecificChatRoom", $"{name} has joined room {roomNumber}");
        }

        public async Task ReceiveSpecificMessage(string msg, string roomNumber)
        {
            if (_sharedDB.connection.TryGetValue(Context.ConnectionId, out string? name)) {
                await Clients.Group(roomNumber).SendAsync("ReceiveSpecificMessage", name, msg);
            }
        }

        public async Task PointingPresent(int id, int status)
        {
            if(_sharedDB.UserList.TryGetValue(id, out User? userFound))
            {
                userFound.Status = status;
                await Clients.All.SendAsync("PointingPresent", userFound);
            } 
          
        }
    }
}
