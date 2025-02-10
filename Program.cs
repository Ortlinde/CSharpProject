namespace CSharpProject;

internal class Program
{
    static async Task Main(string[] args)
    {
        Collections.BoxingAndUnboxingExample.Test();

        await Task.Delay(0);
        Console.WriteLine("程式結束");
    }
}