using Microsoft.AspNetCore.SignalR;
using SignalRHub.Models;

namespace SignalRHub.Hubs
{
    public class Chathub :Hub
    {
        private Dictionary<int, Room>? Dict = new();
        private List<string> EndUsers = new();

        public async Task SendMessage(string message, int RoomId, string? ConnectionId)
        {
            Room r = Dict[RoomId];
            if (r == null || !r.EndUserIds.Contains(Context.ConnectionId))
            {
                //Naar error sturen
            }
            if (ConnectionId != null)
            {
                await Clients.Client(ConnectionId).SendAsync(message);
            }
            else
            {
                await Clients.Client(r.employee.ConnectionString).SendAsync("ReceiveMessage", message);
            }
        }

        /// <summary>
        /// Function of the employee to start his room. De end-User is not allowed to acces this
        /// </summary>
        /// <param name="id">id of the employee</param>
        /// <param name="FirstName">The name of the employee</param>
        /// <returns></returns>
        public async Task StartRoom(int id, string FirstName)
        {
            Employee e = new Employee {Id = id,ConnectionString = Context.ConnectionId, FirstName = FirstName };
            List<string> l = new();
            Room r = new() { Id = Dict.Count + 1,employee = e, EndUserIds = l };
            Dict.Add(r.Id, r);
            await Clients.Client(r.employee.ConnectionString).SendAsync("ReceiveRoomId",r.Id.ToString());
        }   

        /// <summary>
        /// New EndUser use this function
        /// </summary>
        /// <returns></returns>
        public void ConnectUser()
        {
            EndUsers.Add(Context.ConnectionId);
        }
        /// <summary>
        /// Add new user to the room that requested it.
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        public async Task AddEndUserToRoom(int RoomId)
        {
            Room r = Dict[RoomId];
            string EndUser = EndUsers[0].ToString();
            EndUsers.RemoveAt(0);
            r.EndUserIds.Add(EndUser);
            Dict[RoomId] = r;
            await Clients.Client(EndUser).SendAsync("kutjebefje",RoomId.ToString());
            await Clients.Client(r.employee.ConnectionString).SendAsync("nattebafkont28",EndUser);
        }
    }
}
