namespace CSharpProject.ClassEncapsulation;

// 只在這個檔案中可見的類別
file class Logger
{
    public static void Log(string message)
    {
        Console.WriteLine(message);
    }
}

// 只在這個檔案中可見的介面
file interface IRepository
{
    void Save();
}

// 只在這個檔案中可見的記錄
file record Point(int X, int Y);

// 在同一個檔案中使用
file class Program
{
    public void Test()
    {
        Logger.Log("這可以運作");  // 可以存取
        var point = new Point(1, 2);  // 可以存取
    }
}