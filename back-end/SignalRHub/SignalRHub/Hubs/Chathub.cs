using Microsoft.AspNetCore.SignalR;
using SignalRHub.Models;
using SignalRHub.Repo;

namespace SignalRHub.Hubs
{
    public class Chathub :Hub
    { 


        private readonly IRepo<EndUser, string> _EndUserdata;
        private readonly  IRepo<Room, int> _Roomdata;

        private static int Count;

        public Chathub(IRepo<EndUser, string> eud, IRepo<Room, int>rd)
        {
            _EndUserdata = eud;
            _Roomdata = rd;
        }
        /// <summary>
        /// Sends message to enduser or to the worker
        /// </summary>
        /// <param name="message">text of the message</param>
        /// <param name="roomId">the room in which everyone resides</param>
        /// <param name="ConnectionId">used by to direct the message to the correct EndUser</param>
        /// <returns></returns>
        public async Task SendMessage(string message, string roomId, string? ConnectionId)
        {
            int RoomId = Convert.ToInt32(roomId);

            Room r = _Roomdata.get(RoomId);
            if (r == null || !r.EndUserIds.Contains(Context.ConnectionId) && r.employee.ConnectionString != Context.ConnectionId)
            {
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
        public async Task SendMedia(string base64, string roomId, string? ConnectionId)
        {
            int RoomId = Convert.ToInt32(roomId);
            Room r = _Roomdata.get(RoomId);
            if (r == null || !r.EndUserIds.Contains(Context.ConnectionId) && r.employee.ConnectionString != Context.ConnectionId)
            {
                return;
            }
            if (ConnectionId != null)
            {//currently unused
                await Clients.Client(ConnectionId).SendAsync("ReceiveMedia", base64);
            }
            else
            {
                await Clients.Client(r.employee.ConnectionString).SendAsync("ReceiveMediaWorker", base64, Context.ConnectionId);
            }
        }
        /// <summary>
        /// Add new user to the room that requested it.
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        public async Task AddEndUserToRoom(EndUser? enduser, Room? r)
        {
            if(r == null)
            {
                 r = _Roomdata.FindFree();
            }
            if (enduser == null)
            {
                enduser = _EndUserdata.FindFree();
            }
            if (enduser == null) return;
            if (r == null) return;
            enduser.RoomId = r.Id;
            enduser.inRoom = true;
            _EndUserdata.Update(enduser, enduser.ConnectionString);
            r.EndUserIds.Add(enduser.ConnectionString);
            _Roomdata.Update(r, r.Id);
            Count--;
            await Clients.Client(enduser.ConnectionString).SendAsync("RecieveRoomId", r.Id.ToString());
            await Clients.Client(r.employee.ConnectionString).SendAsync("RecieveEndUserId", enduser.ConnectionString);
            await Clients.All.SendAsync("GetQueue", Count);
        }
        /// <summary>
        /// Function of the employee to start his room. De end-User is not allowed to acces this
        /// </summary>
        /// <param name="id">id of the employee</param>
        /// <param name="FirstName">The name of the employee</param>
        /// <param name="RoomId">The name of the employee</param>
        /// <returns></returns>
        public async Task StartRoom(int id, string FirstName,int? RoomId)
        {
            if (RoomId == null)
            {
                return;
            }
            Employee e = new Employee { Id = id, ConnectionString = Context.ConnectionId, FirstName = FirstName };
            Room r = new() { Id = (int)RoomId, employee = e };

            _Roomdata.Add(r, r.Id);
            await Clients.Client(r.employee.ConnectionString).SendAsync("ReceiveRoomId", r.Id.ToString());
            
        }

        public async Task StopRoom(int? Roomid)
        {
            if(Roomid == null)
            {
                return;
            }
            _Roomdata.remove((int)Roomid);
            await Clients.Client(Context.ConnectionId).SendAsync("StopRoom");
        }

        public async Task StopChat(string Connection, string roomId)
        {
            int RoomId = Convert.ToInt32(roomId);
            try{
                Room r = _Roomdata.get(RoomId);
                string connectionValidaded = r.EndUserIds.Find(x => x == Connection);
                if (connectionValidaded != null)
                {
                    r.EndUserIds.Remove(connectionValidaded);
                }

                EndUser e = _EndUserdata.get(Connection);

                if(e != null)
                {
                    e.RoomId = -1;
                    _EndUserdata.Update(e,Connection);
                }
            }
            catch(Exception ex)
            {
                return;
            }
            await Clients.Client(Connection).SendAsync("CloseChat");
        
        }

        /// <summary>
        /// New EndUser use this function
        /// </summary>
        /// <returns></returns>
        public async Task ConnectUser()
        {
            Count++;
            string id = Context.ConnectionId;
            EndUser e = new(id);
            _EndUserdata.Add(e, id);
            await AddEndUserToRoom(e, null);
            await Clients.All.SendAsync("Count", Count);
            await Clients.All.SendAsync("GetQueue", Count);
        }

        /// <summary>
        /// Removes the user when they disconnect
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
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
                        await Clients.Client(r.employee.ConnectionString).SendAsync("DisconnectUser", e.ConnectionString);
                    }
                    else if(e.RoomId == 1 && e.inRoom == true)
                    {
                        Count--;
                    }
                }
            }

            _EndUserdata.remove(Connection);
            await base.OnDisconnectedAsync(exception);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("GetQueue", Count);
            await base.OnConnectedAsync();
        }

        public async void OpenWorker(string roomid)
        {
            int RoomId = Convert.ToInt32(roomid);
            Room r = _Roomdata.get(RoomId);
            if (r == null) return;
            r.employee.IsOpen = true;
            _Roomdata.Update(r, RoomId);
            await AddEndUserToRoom(null, r);
        }

        public void CloseWorker(string roomid)
        {
            int RoomId = Convert.ToInt32(roomid);
            Room r = _Roomdata.get(RoomId);
            if (r == null) return;
            r.employee.IsOpen = false;
            _Roomdata.Update(r, RoomId);
        }

        public List<string> GetAllEmploye()
        {
            List<string> employes = new List<string>();
            List<Room> rooms = new List<Room>();

            for (int i = 0; i < _EndUserdata.Count(); i++)
            {
                Room r = _Roomdata.get(i);
                if (r != null)
                {
                    rooms.Add(_Roomdata.get(i));
                }
            }
            if(rooms.Count > 0)
            {
                foreach (Room room in rooms)
                {
                    employes.Add(room.employee.ConnectionString);
                }
            }
            return employes;
        }


    }
}
