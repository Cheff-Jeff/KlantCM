namespace SignalRHub
{
    public class RepoRoom<Room>
    {
        private readonly Dictionary<int, Room> _data =
            new Dictionary<int, Room>();
        public int Count 
        { 
            get { return _data.Count; }
        }

        public bool Add(Room r, int key)
        {
            _data.Add(key, r);
            if(r != null && key != null) { return true; }
            return false;
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
    }
}
