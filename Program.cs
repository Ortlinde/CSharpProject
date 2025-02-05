namespace CSharpProject;

internal class Program
{
    static async Task Main(string[] args)
    {
        var foreachApp = new Applications.ForeachLoopApplication();
        await foreachApp.RunAsync();

        // 之後可以在這裡添加其他範例的調用
    }
}