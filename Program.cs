namespace CSharpProject;

internal class Program
{
    static async Task Main(string[] args)
    {
        StructuredExceptionHandling.FinallyExample.Test();

        await Task.Delay(0);
    }
}