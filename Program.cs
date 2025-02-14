global using UnityEngine;

namespace CSharpProject;

internal class Program
{
    static async Task Main(string[] args)
    {

        Pointers.StackallocExample.Test2();

        await Task.Delay(0);
        Console.WriteLine("程式結束");
    }
}