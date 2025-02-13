global using UnityEngine;

namespace CSharpProject;

internal class Program
{
    static async Task Main(string[] args)
    {
        LanguageFeatures.LINQExample example = new();
        example.GroupExample();

        await Task.Delay(0);
        Console.WriteLine("程式結束");
    }
}