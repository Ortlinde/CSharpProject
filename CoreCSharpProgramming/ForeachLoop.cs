namespace CSharpProject.CoreCSharpProgramming;
using CSharpProject.Extensions;

public class ForeachLoop
{
    int[] numbers = { 1, 2, 3, 4, 5 };

    public void TestLoop()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }

    public void TestForeach()
    {
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }

    object[] objects = [1, "Hello", 3.14, true];
    // 運行時可能會拋出錯誤，objects內的成員不一定為int
    public void TestForeachObject()
    {
        foreach (int obj in objects)
        {
            Console.WriteLine(obj);
            // obj = 111; // 編譯錯誤：無法對 foreach 迭代變數進行賦值
        }
    }

    List<object> objectsList = [1, "Hello", 3.14, true];
    public void TestForeachList()
    {
        foreach (var obj in objectsList)
        {
            objectsList.Add(111); // 運行時錯誤：foreach 迭代過程中不能修改集合
        }
    }

    // 異步數據源
    private async IAsyncEnumerable<int> GenerateNumbersAsync()
    {
        for (int i = 1; i <= 5; i++)
        {
            LoggingExtensions.LogWithThread($"生成數字 {i}");
            await Task.Delay(500);
            yield return i;
        }
    }

    // 使用 await foreach 示例
    public async Task TestAwaitForeach()
    {
        LoggingExtensions.LogWithThread("開始異步迭代");
        await foreach (int number in GenerateNumbersAsync())
        {
            LoggingExtensions.LogWithThread($"異步接收到數字：{number}");
            await Task.Delay(1000);
        }
        LoggingExtensions.LogWithThread("異步迭代完成");
    }

    // 取消令牌示例
    public async Task TestAwaitForeachWithCancellation(CancellationToken cancellationToken)
    {
        await foreach (int number in GenerateNumbersAsync().WithCancellation(cancellationToken))
        {
            LoggingExtensions.LogWithThread($"異步接收到數字：{number}");
        }
    }
}