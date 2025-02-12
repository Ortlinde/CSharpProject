namespace CSharpProject.Delegates;

public class AnonymousMethod
{
    // 定義委派類型
    public delegate void PrintDelegate(string message);

    public static void Test()
    {
        // 使用匿名方法創建委派
        PrintDelegate printMessage = delegate (string message)
        {
            Console.WriteLine($"訊息: {message}");
        };

        // 調用匿名方法
        printMessage("Hello, World!");

        // 使用匿名方法進行數學運算
        Func<int, int, int> add = delegate (int x, int y)
        {
            return x + y;
        };

        // 使用 Lambda 表達式的替代寫法（更現代的方式）
        Func<int, int, int> multiply = (x, y) => x * y;

        Console.WriteLine($"加法結果：{add(5, 3)}");
        Console.WriteLine($"乘法結果：{multiply(4, 2)}");
    }
}

