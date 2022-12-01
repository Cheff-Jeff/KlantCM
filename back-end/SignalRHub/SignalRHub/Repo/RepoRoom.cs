using SignalRHub.Models;
using SignalRHub.Repo;

namespace SignalRHub
{
    public class RepoRoom:IRepo<Room, int>
    {
        public readonly Dictionary<int, Room> _data =
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
            if(free.Count == 0)
            {
                return null;
            }
            free.Sort();
            if (free[0].EndUserIds.Count == 8 || free[0].employee.IsOpen == false) // 8 should not be hardcoded here
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
