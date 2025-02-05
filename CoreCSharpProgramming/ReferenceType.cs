namespace CSharpProject.CoreCSharpProgramming;

public class ReferenceType
{
    public static void Test()
    {
        object obj = "Hello";
        // Console.WriteLine(obj.Length);  // 編譯錯誤：object沒有Length屬性
        Console.WriteLine(((string)obj).Length);  // 正確：需要明確轉型
    }

    public static void TestDynamic()
    {
        dynamic dyn = "Hello";
        Console.WriteLine(dyn.Length);  // 正確：運行時發現是 string，有 Length 屬性
        dyn = 123;                      // 正確：運行時才決定型別
        Console.WriteLine(dyn.Length);  // 運行時錯誤：發現是 int，沒有 Length 屬性
    }
}