namespace CSharpProject.CoreCSharpProgramming;

// 使用 [Flags] 標記表示這是位元旗標列舉
[Flags]
public enum FilePermissions
{
    None = 0,            // 0000
    Read = 1,            // 0001
    Write = 1 << 1,      // 0010
    Execute = 1 << 2,    // 0100
    All = Read | Write | Execute  // 0111
}

[Flags]
public enum DaysOfWeek
{
    None = 0,
    Monday = 1,
    Tuesday = 1 << 1,
    Wednesday = 1 << 2,
    Thursday = 1 << 3,
    Friday = 1 << 4,
    Saturday = 1 << 5,
    Sunday = 1 << 6,
    Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,
    Weekends = Saturday | Sunday,
    All = Weekdays | Weekends
}

public class BitFlagsExample
{
    public void Test()
    {
        // 1. 基本使用
        Console.WriteLine("1. 基本使用：");
        var permissions = FilePermissions.Read | FilePermissions.Write;
        Console.WriteLine($"權限：{permissions}");  // 輸出：Read, Write

        // 2. 檢查旗標
        Console.WriteLine("\n2. 檢查旗標：");
        bool canRead = permissions.HasFlag(FilePermissions.Read);
        bool canExecute = permissions.HasFlag(FilePermissions.Execute);
        Console.WriteLine($"可讀取：{canRead}");
        Console.WriteLine($"可執行：{canExecute}");

        // 3. 新增和移除旗標
        Console.WriteLine("\n3. 新增和移除旗標：");
        permissions |= FilePermissions.Execute;  // 新增執行權限
        Console.WriteLine($"新增執行權限後：{permissions}");

        permissions &= ~FilePermissions.Write;   // 移除寫入權限
        Console.WriteLine($"移除寫入權限後：{permissions}");

        // 4. 實際應用範例
        Console.WriteLine("\n4. 實際應用範例：");
        var workingDays = DaysOfWeek.Weekdays;
        Console.WriteLine($"工作日：{workingDays}");

        // 新增加班日
        workingDays |= DaysOfWeek.Saturday;
        Console.WriteLine($"加上週六後：{workingDays}");

        // 檢查特定日期
        bool isWorkingOnMonday = workingDays.HasFlag(DaysOfWeek.Monday);
        bool isWorkingOnSunday = workingDays.HasFlag(DaysOfWeek.Sunday);
        Console.WriteLine($"週一要上班：{isWorkingOnMonday}");
        Console.WriteLine($"週日要上班：{isWorkingOnSunday}");
    }
}