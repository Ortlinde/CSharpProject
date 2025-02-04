using System;
using System.IO;
using static System.Math;
using ConsoleWriter = System.Console;

namespace CSharpProject.CoreCSharpProgramming;

public class UsingKeyword
{
    public void ExampleUsingKeyword()
    {
        // 使用完整限定名稱
        System.Console.WriteLine("Hello");

        // 使用 using 簡化後
        Console.WriteLine("Hello");
    }

    // 1. using 用於資源釋放
    public void UsingForDisposable()
    {
        using (StreamReader reader = new StreamReader("file.txt"))
        {
            string? content = reader.ReadLine();
            Console.WriteLine(content);
        } // 自動呼叫 Dispose()

        // C# 8.0+ using 宣告簡化寫法
        using var writer = new StreamWriter("output.txt");
        writer.WriteLine("Hello");
    } // 作用域結束時自動釋放

    // 2. using static 導入靜態成員
    public void UsingStaticExample()
    {
        // 假設檔案頂部有：using static System.Math;
        double result = Pow(2, 3); // 直接使用 Math.Pow
        Console.WriteLine(PI);     // 直接使用 Math.PI
    }

    // 3. using alias 為型別建立別名
    public void UsingAliasExample()
    {
        // 假設檔案頂部有：using ConsoleWriter = System.Console;
        ConsoleWriter.WriteLine("使用別名");
    }
}

// 正確的方式
public class CSharpDemands
{
    private static int counter = 0;  // 類別層級的變數

    public static void DoSomething()
    {
        // 方法必須在類別內
    }
}

// // 錯誤 - 不允許全域變數或函數
// int globalCounter = 0;  // 這在 C# 中是不允許的
// void GlobalFunction() { }  // 這也是不允許的
/**
public class Program
{
    // 1. 最簡單的形式
    public static void Main() { }

    // 2. 帶參數的形式
    public static void Main(string[] args) { }

    // 3. 帶返回值的形式
    public static int Main() { return 0; }

    // 4. 帶參數和返回值的形式
    public static int Main(string[] args) { return 0; }

    // 5. 非同步無參數(C# 7.1+)
    public static async Task Main() { await Task.Delay(1000); }

    // 6. 非同步帶參數(C# 7.1+)
    public static async Task Main(string[] args) { await Task.Delay(1000); }

    // 7. 非同步帶返回值無參數(C# 7.1+)
    public static async Task<int> Main()
    {
        await Task.Delay(1000);
        return 0;
    }

    // 8. 非同步帶返回值和參數(C# 7.1+)
    public static async Task<int> Main(string[] args)
    {
        await Task.Delay(1000);
        return 0;
    }
}
*/