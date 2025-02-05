namespace CSharpProject.Extensions;

public static class LoggingExtensions
{
    public static void LogWithThread(string message)
    {
        Console.WriteLine($"[線程 {Environment.CurrentManagedThreadId}] {message}");
    }
}