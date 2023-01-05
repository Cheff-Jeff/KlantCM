namespace SignalRHub.Repo
{
    public class RepoImage : IRepo<List<string>, string>
    {
        public readonly Dictionary<string, List<string>> _data =
        new Dictionary<string, List<string>>();

        public void Add(List<string> item, string key)
        {
            _data.Add(key, item);
        }

        public int Count()
        {
            return Convert.ToInt32(_data.Count);
        }

        public bool Exists(string key)
        {
            return _data.ContainsKey(key);
        }

        public List<string>? FindFree()
        {
            throw new NotImplementedException();
        }

        public List<string>? get(string key)
        {
            _data.TryGetValue(key, out var p);
            return p;
        }

        public void remove(string key)
        {
            _data.Remove(key);
        }

        public void Update(List<string> item, string key)
        {
            _data[key] = item;
        }
    }
}
