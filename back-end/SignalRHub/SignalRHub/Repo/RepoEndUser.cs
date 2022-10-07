using SignalRHub.Exceptions;
using SignalRHub.Models;
namespace SignalRHub.Repo
{
    public class RepoEndUser
    {
        private readonly Dictionary<int, EndUser> _data =
        new Dictionary<int, EndUser>();
        public int Count
        {
            get { return _data.Count; }
        }

        public bool Add(EndUser r, int key)
        {
            _data.Add(key, r);
            if(key != null && r != null) { return true; }
            return false;
        }
        public bool Exists(int key)
        {
            return _data.ContainsKey(key);
        }

        public EndUser? get(int key)
        {
            _data.TryGetValue(key, out var p);
            return p;
        }

        //dit was internal
        public EndUser? FindFreeUser() /// this can be done better
        {
            for (int i = 0; i < _data.Count; i++)
            {
                EndUser e = _data[i];
                if (!e.inRoom)
                {
                    return e;
                }
            }
            throw new RepoEndUserException("There are no free users");
        }
    }
}
