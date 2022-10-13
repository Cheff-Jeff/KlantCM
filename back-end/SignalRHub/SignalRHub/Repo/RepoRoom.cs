using SignalRHub.Models;
using SignalRHub.Repo;

namespace SignalRHub
{
    public class RepoRoom:IRepo<Room>
    {
        private readonly Dictionary<int, Room> _data =
            new Dictionary<int, Room>();

        public void Add(Room r, int key)
        {
            _data.Add(key, r);
        }

        public void Update(Room r, int key)
        {
            _data[key] = r;
        }
        public bool Exists(int key)
        {
            return _data.ContainsKey(key);
        }

        public Room? get(int key)
        {
            _data.TryGetValue(key, out var p);
            return p;
        }

        public int Count()
        {
            return Convert.ToInt32(_data.Count);
        }

        public Room? FindFreeUser()
        {
            throw new NotImplementedException();
        }
    }
}
