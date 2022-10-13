using SignalRHub.Models;
namespace SignalRHub.Repo
{
    public class RepoEndUser:IRepo<EndUser>
    {
        private readonly Dictionary<int, EndUser> _data =
        new Dictionary<int, EndUser>();

        public void Add(EndUser r, int key)
        {
            _data.Add(key, r);
        }
        public bool Exists(int key)
        {
            return _data.ContainsKey(key);
        }
        public void Update(EndUser e, int key)
        {
            _data[key] = e;
        }

        public EndUser? get(int key)
        {
            _data.TryGetValue(key, out var p);
            return p;
        }

        public EndUser? FindFreeUser() /// this can be done better
        {
            for (int i = 0; i < _data.Count; i++)
            {
                EndUser e = _data[i];
                if (!e.inRoom)
                {
                    e.inRoom = true;
                    Update(e, i);
                    return e;
                }
            }
            return null;
        }

        public int Count()
        {
            return Convert.ToInt32(_data.Count);
        }
    }
}
