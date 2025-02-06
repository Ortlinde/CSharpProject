namespace CSharpProject;

internal class Program
{
    static async Task Main(string[] args)
    {
        TestProgram.Test();

        await Task.Delay(0);
    }
}