namespace CSharpProject.Delegates;

public class AnonymousMethod
{
    // 定義委派類型
    public delegate void PrintDelegate(string message);

    static PrintDelegate? stringToNumber;
    public static void RefParameterFunction(ref int number, ref string strInt)
    {
        stringToNumber = strInt =>
        {
            // number = int.Parse(strInt);
            int num = int.Parse(strInt);
        };
    }

    public static void AnotherFunction()
    {
        stringToNumber?.Invoke("10");
    }

    public static void Test()
    {
        // 使用匿名方法創建委派
        PrintDelegate printMessage = delegate (string message)
        {
            Console.WriteLine($"訊息: {message}");
        };

        PrintDelegate printMessage2 = delegate
        {
            Console.WriteLine($"訊息: Fixed Message");
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

file class OuterVariableLifetimeDemo
{
    public Action CreateCounter()
    {
        int counter = 0;  // 外部變數

        // 這個匿名方法捕獲了外部變數
        Action increment = delegate
        {
            counter++;  // 存取外部變數
            Console.WriteLine(counter);
        };

        // 即使 CreateCounter 方法結束，counter 變數仍然存活
        return increment;
    }

    public void DemoUsage()
    {
        Action counter = CreateCounter();
        counter();  // 輸出: 1
        counter();  // 輸出: 2
        counter();  // 輸出: 3
    }
}