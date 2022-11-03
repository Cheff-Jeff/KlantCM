namespace SignalRHub.Repo
{
    public interface IRepo<Class, Identifier>
    {
        void Add(Class item, Identifier key);
        void Update(Class item, Identifier key);
        bool Exists(Identifier key);
        Class? get(Identifier key);
        int Count();

        Class? FindFree(); 

        void remove(Identifier key);
    }
}