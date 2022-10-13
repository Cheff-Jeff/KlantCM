namespace SignalRHub.Repo
{
    public interface IRepo<Class, Identifier>
    {
        void Add(Class item, Identifier key);
        void Update(Class item, Identifier key);
        bool Exists(Identifier key);
        Class? get(Identifier key);
        int Count();

        Class? FindFreeUser(); // should be done different

        void remove(Identifier key);
    }
}