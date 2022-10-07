namespace SignalRHub.Exceptions
{
    public class RepoRoomException : Exception
    {
        public RepoRoomException() { }

        public RepoRoomException(string message)
            : base(message) { }
        public RepoRoomException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}
