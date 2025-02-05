namespace CSharpProject.Applications;

public class ForeachLoopApplication
{
    private readonly CoreCSharpProgramming.ForeachLoop _foreachLoop;

    public ForeachLoopApplication()
    {
        _foreachLoop = new CoreCSharpProgramming.ForeachLoop();
    }

    public async Task RunAsync()
    {
        LogThreadInfo("主線程開始");

        // 啟動異步任務
        var asyncTask = RunAsyncIterationAsync();

        // 同時執行主線程工作
        await RunMainThreadWorkAsync();

        // 等待異步任務完成
        await asyncTask;

        LogThreadInfo("所有操作完成");
    }

    private async Task RunAsyncIterationAsync()
    {
        await _foreachLoop.TestAwaitForeach();
    }

    private async Task RunMainThreadWorkAsync()
    {
        for (int i = 1; i <= 5; i++)
        {
            LogThreadInfo($"主線程執行中... {i}");
            await Task.Delay(1000);
        }
    }

    private void LogThreadInfo(string message)
    {
        Console.WriteLine($"[線程 {Environment.CurrentManagedThreadId}] {message}");
    }
}
