namespace SignalRHub.Exceptions
{
    [Serializable]
    public class RepoEndUserException : Exception
    {
        public RepoEndUserException() { }

        public RepoEndUserException(string message)
            : base(message) { }

        public RepoEndUserException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
