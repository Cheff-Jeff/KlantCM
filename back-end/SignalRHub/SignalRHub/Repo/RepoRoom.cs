using SignalRHub.Models;
using SignalRHub.Repo;

namespace SignalRHub
{
    public class RepoRoom:IRepo<Room, int>
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

        public Room? FindFree()
        {
            List<Room> free = _data.Values.ToList();
            free.Sort();
            if (free[0].EndUserIds.Count == 5) // 5 should not be hardcoded here
            {
                return null;
            }
            return free[0];
        }

        public void remove(int key)
        {
            _data.Remove(key);
        }

        public Room? Find(string connection)
        {
            throw new NotImplementedException();
        }
    }
}
