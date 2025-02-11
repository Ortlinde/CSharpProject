namespace CSharpProject;

internal class Program
{
    static async Task Main(string[] args)
    {
        StructuredExceptionHandling.FinalizerExample.Test();

        await Task.Delay(0);
        Console.WriteLine("程式結束");
    }
}