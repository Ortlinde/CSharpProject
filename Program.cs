namespace CSharpProject;

internal class Program
{
    static async Task Main(string[] args)
    {
        Delegates.YouTube.YouTubeNotificationDemo.Test();

        await Task.Delay(0);
        Console.WriteLine("程式結束");
    }
}