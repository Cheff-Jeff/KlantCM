using Microsoft.AspNetCore.SignalR;
using SignalRHub.Models;
using SignalRHub.Repo;

namespace SignalRHub.Hubs
{
    public class Chathub :Hub
    {

        private readonly static RepoEndUser _EndUserdata = new();
        private readonly static RepoRoom _Roomdata = new();

        public async Task SendMessage(string message, string roomId, string? ConnectionId)
        {
            int RoomId = Convert.ToInt32(roomId);

            Room r = _Roomdata.get(RoomId);
            if (r == null || !r.EndUserIds.Contains(Context.ConnectionId))
            {
                //Naar error sturen
            }
            if (ConnectionId != null)
            {
                await Clients.Client(ConnectionId).SendAsync("ReceiveMessage",message);
            }
            else
            {
                await Clients.Client(r.employee.ConnectionString).SendAsync("ReceiveMessageWorker", message);
            }
        }
        /// <summary>
        /// Add new user to the room that requested it.
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        public async Task AddEndUserToRoom(string roomId)
        {
            int RoomId = Convert.ToInt32(roomId);
            Room r = _Roomdata.get(RoomId);
            EndUser EndUser = _EndUserdata.FindFreeUser();
            r.EndUserIds.Add(EndUser.ConnectionString);
            _Roomdata.Update(r, r.Id);
            await Clients.Client(EndUser.ConnectionString).SendAsync("RecieveRoomId", RoomId.ToString());
            await Clients.Client(r.employee.ConnectionString).SendAsync("RecieveEndUserId", EndUser.ConnectionString);
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
            Room r = new() { Id = _Roomdata.Count ,employee = e };

            _Roomdata.Add(r, _Roomdata.Count);
            await Clients.Client(r.employee.ConnectionString).SendAsync("ReceiveRoomId",r.Id.ToString());
        }   

        /// <summary>
        /// New EndUser use this function
        /// </summary>
        /// <returns></returns>
        public void ConnectUser()
        {
            EndUser e = new(Context.ConnectionId);
            _EndUserdata.Add(e,_EndUserdata.Count);
        }

    }
}
