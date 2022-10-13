using Microsoft.AspNetCore.SignalR;
using SignalRHub.Models;
using SignalRHub.Repo;

namespace SignalRHub.Hubs
{
    public class Chathub :Hub
    { // TODO: Add error handeling 


        private readonly IRepo<EndUser, string> _EndUserdata;
        private readonly  IRepo<Room, int> _Roomdata;

        public Chathub(IRepo<EndUser, string> eud, IRepo<Room, int>rd)
        {
            _EndUserdata = eud;
            _Roomdata = rd;
        }

        public async Task SendMessage(string message, string roomId, string? ConnectionId)
        {
            int RoomId = Convert.ToInt32(roomId);

            Room r = _Roomdata.get(RoomId);
            if (r == null || !r.EndUserIds.Contains(Context.ConnectionId) && r.employee.ConnectionString != Context.ConnectionId)
            {
                //Naar error sturen
                return;
            }
            if (ConnectionId != null)
            {
                await Clients.Client(ConnectionId).SendAsync("ReceiveMessage",message);
            }
            else
            {
                await Clients.Client(r.employee.ConnectionString).SendAsync("ReceiveMessageWorker", message, Context.ConnectionId);
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
            if (r == null) return;
            EndUser e = _EndUserdata.FindFreeUser();
            if (e == null) return;
            e.RoomId = r.Id;
            e.inRoom = true;
            _EndUserdata.Update(e, e.ConnectionString);
            r.EndUserIds.Add(e.ConnectionString);
            _Roomdata.Update(r, r.Id);
            await Clients.Client(e.ConnectionString).SendAsync("RecieveRoomId", RoomId.ToString());
            await Clients.Client(r.employee.ConnectionString).SendAsync("RecieveEndUserId", e.ConnectionString);
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
            Room r = new() { Id = _Roomdata.Count() ,employee = e, EndUserIds = l };

            _Roomdata.Add(r, _Roomdata.Count());
            await Clients.Client(r.employee.ConnectionString).SendAsync("ReceiveRoomId",r.Id.ToString());
        }   

        /// <summary>
        /// New EndUser use this function
        /// </summary>
        /// <returns></returns>
        public void ConnectUser()
        {
            string id = Context.ConnectionId;
            EndUser e = new(id);
            _EndUserdata.Add(e,id);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string Connection = Context.ConnectionId;
            if (Connection != null)
            {
                EndUser e = _EndUserdata.get(Connection);
                if (e != null)
                {
                    if (e.RoomId != -1)
                    {
                        Room r = _Roomdata.get(e.RoomId);
                        r.EndUserIds.Remove(e.ConnectionString);
                    }
                }
            }

            _EndUserdata.remove(Connection);

            await base.OnDisconnectedAsync(exception);
        }

    }
}
