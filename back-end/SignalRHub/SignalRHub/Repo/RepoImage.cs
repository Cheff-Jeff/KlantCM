namespace SignalRHub.Repo
{
    public class RepoImage : IRepo<string, string>
    {
        public readonly Dictionary<string, string> _data =
        new Dictionary<string, string>();

        public void Add(string item, string key)
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

        public string? FindFree()
        {
            throw new NotImplementedException();
        }

        public string? get(string key)
        {
            _data.TryGetValue(key, out var p);
            return p;
        }

        public void remove(string key)
        {
            _data.Remove(key);
        }

        public void Update(string item, string key)
        {
            _data[key] = item;
        }
    }
}
