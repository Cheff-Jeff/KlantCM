using SignalRHub.Models;
namespace SignalRHub.Repo
{
    public class RepoEndUser:IRepo<EndUser, string>
    {
        private readonly Dictionary<string, EndUser> _data =
        new Dictionary<string, EndUser>();

        public void Add(EndUser r, string key)
        {
            _data.Add(key, r);
        }
        public bool Exists(string key)
        {
            return _data.ContainsKey(key);
        }
        public void Update(EndUser e, string key)
        {
            _data[key] = e;
        }

        public EndUser? get(string key)
        {
            _data.TryGetValue(key, out var p);
            return p;
        }

        public EndUser? FindFree() /// this can be done better hash set ?
        {
            foreach (KeyValuePair<string, EndUser> entry in _data)
            {
                if (!entry.Value.inRoom)
                {
                    return entry.Value;
                }
            }
            return null;
        }

        public int Count()
        {
            return Convert.ToInt32(_data.Count);
        }

        public void remove(string key)
        {
           _data.Remove(key);
        }

    }
}
