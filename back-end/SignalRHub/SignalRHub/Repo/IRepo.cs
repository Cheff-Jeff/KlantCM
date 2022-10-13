namespace SignalRHub.Repo
{
    public interface IRepo<Class>
    {
        void Add(Class item, int key);
        void Update(Class item, int key);
        bool Exists(int key);
        Class? get(int key);
        int Count();

        Class? FindFreeUser(); // should be done different

    }
}