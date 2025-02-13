namespace LanguageFeatures;

public abstract class VarExample
{
    public int PropertyVar
    {
        get; set
        {
            var input = value;
            field = input;
        }
    } = 5;

    public abstract int AbstractProperty { get; set; } // 抽象屬性
    public int AutoProperty { get; set; } = Return5(); // 自動實作屬性
    public static float E => 2.71828f; // 唯讀自動屬性
    public bool IsSuccess { get; init; } = false; // 只初始化
    public required int RequiredProperty { get; set; } // 必填屬性
    public required string Name
    {
        get;
        init => field = SetNameIfNotEmpty(value);
    } // 使用field代替後備欄位

    private static string SetNameIfNotEmpty(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Name cannot be null or empty");
        return value;
    }

    public static int Return5() => 5; // 靜態方法
    public void Test()
    {
        var a = 6;
        var b = "Hello";
        var c = new int[] { 1, 2, 3 };

        Console.WriteLine(a.GetType().Name);
        Console.WriteLine(b.GetType().Name);
        Console.WriteLine(c.GetType().Name);
    }

    public void Test2()
    {
        var anon = new { Gender = "M", Age = 20 }; // 匿名型別
        OutFunction(out var a);
        // 等同於
        // int a;
        // OutFunction(out a);
    }

    public void OutFunction(out int a)
    {
        a = 0;
    }
}
