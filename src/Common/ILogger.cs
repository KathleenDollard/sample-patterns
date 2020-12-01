namespace Common

{
    public interface ILogger
    {
        void SendMessage(string message, LogLevel error = 0);
    }
}