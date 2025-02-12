namespace CSharpProject.Delegates;

public class DelegateConceptsExample
{
    // 定義一個委派類型
    public delegate void MessageDelegate(string message);
    // 定義一個有返回值的委派
    public delegate int CalculateDelegate(int x, int y);

    // 使用委派的方法示例
    public static void Test()
    {
        // 創建委派實例
        MessageDelegate messageHandler = ShowMessage;

        // 調用委派
        messageHandler.Invoke("This is a message from the delegate");

        // 使用多播委派
        messageHandler += ShowMessageUpperCase;
        messageHandler.Invoke("This message will be displayed twice");

        // 使用 Lambda 表達式
        MessageDelegate lambdaDelegate = msg => Console.WriteLine($"Lambda: {msg}");
        lambdaDelegate.Invoke("This message is processed through the Lambda expression");
    }

    public static void TestAsyncDelegate()
    {
        // 創建委派實例
        CalculateDelegate calculateHandler = SlowCalculation;

        // 開始異步調用
        IAsyncResult asyncResult = calculateHandler.BeginInvoke(10, 20, ar =>
        {
            // 這是回調方法，在異步操作完成時執行
            Console.WriteLine($"異步操作完成！線程ID: {Environment.CurrentManagedThreadId}");
        }, null);

        Console.WriteLine("主線程繼續執行其他工作...");

        // 獲取異步操作的結果
        int result = calculateHandler.EndInvoke(asyncResult);
        Console.WriteLine($"計算結果: {result}");
    }

    private static void ShowMessage(string message)
    {
        Console.WriteLine($"消息: {message}");
    }

    private static void ShowMessageUpperCase(string message)
    {
        Console.WriteLine($"大寫消息: {message.ToUpper()}");
    }

    private static int SlowCalculation(int x, int y)
    {
        // 模擬耗時操作
        Thread.Sleep(2000);
        return x + y;
    }
}