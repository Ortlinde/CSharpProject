namespace CSharpProject.StructuredExceptionHandling;

internal class FinalizerExample
{
    public static void Test()
    {
        Console.WriteLine("開始測試終結器");
        // 將區塊變為一個獨立的方法
        TestFinalizer();
        // 強制進行完整的垃圾回收
        System.Console.WriteLine("第一次垃圾回收");
        GC.Collect(2, GCCollectionMode.Forced, true);
        // GC.WaitForPendingFinalizers();

        Console.WriteLine("第一次垃圾回收完成");

        // 再次強制回收
        System.Console.WriteLine("第二次垃圾回收");
        GC.Collect(2, GCCollectionMode.Forced, true);
        // GC.WaitForPendingFinalizers();

        Console.WriteLine("第二次垃圾回收完成");
    }

    public static void TestFinalizer()
    {
        var finalizableClass = new FinalizableClass();
        finalizableClass = null;
    }
}

file class FinalizableClass
{
    public FinalizableClass()
    {
        Console.WriteLine($"建立 FinalizableClass 實例 {GetHashCode()}");
    }

    ~FinalizableClass()
    {
        Console.WriteLine($"終結器執行中 - 實例 {GetHashCode()}");
        Console.WriteLine("釋放資源");
    }
}