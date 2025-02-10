namespace CSharpProject.StructuredExceptionHandling;

public class DisposableExample
{
    public static void Test()
    {
        Console.WriteLine("開始測試可釋放資源的類別");
        // 使用可釋放資源的類別
        using var disposableClass = new DisposableClass();

    } // 離開區塊時，會自動呼叫 Dispose 方法
}

file class DisposableClass : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("釋放資源");

        // 告訴垃圾回收器不要呼叫終結器
        GC.SuppressFinalize(this);
    }

    ~DisposableClass()
    {
        Console.WriteLine("釋放 DisposableClass 資源");
    }
}
