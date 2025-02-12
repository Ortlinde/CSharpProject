using System.Runtime.CompilerServices;

namespace CSharpProject.StructuredExceptionHandling;

internal class FinalizerExample
{
    static int GCCount = 0;

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.NoInlining)]
    public static void Test()
    {
        Console.WriteLine("開始測試終結器");
        new FinalizableClass();
        // 將區塊變為一個獨立的方法
        // static void TestFinalizer() => new FinalizableClass();
        // TestFinalizer(); // 離開方法區域後，GC確認這個物件已經沒有任何參考

        // 強制進行完整的垃圾回收
        ForceGC();

        // 再次強制回收
        ForceGC();
    } // 物件至少會活到方法結束

    public static void ForceGC()
    {
        System.Console.WriteLine($"第 {++GCCount} 次垃圾回收");
        GC.Collect(2, GCCollectionMode.Forced, true);
        // GC.WaitForPendingFinalizers();
        Console.WriteLine("垃圾回收完成");
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