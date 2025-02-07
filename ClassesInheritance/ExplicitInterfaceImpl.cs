using System.Text;

namespace CSharpProject.ClassesInheritance;

file interface IControl
{
    void Paint();
}

file interface IForm
{
    void Paint();

    // 預設介面方法
    int Close()
    {
        // 提供預設實作
        return 0;
    }

    // 可以呼叫其他介面方法
    void Shutdown()
    {
        Close();
        Paint();
    }
}

file class MyForm : IControl, IForm
{
    // 顯式介面實現
    void IControl.Paint()
    {
        Console.WriteLine("IControl.Paint");
    }

    void IForm.Paint()
    {
        Console.WriteLine("IForm.Paint");
    }

    // 一般的公開方法
    public void Paint()
    {
        Console.WriteLine("MyForm.Paint");
    }
}

public class ExplicitInterfaceImpl
{
    public static void Test()
    {
        var form = new MyForm();
        form.Paint();           // 呼叫 "MyForm.Paint"
        ((IControl)form).Paint(); // 呼叫 "IControl.Paint"
        ((IForm)form).Paint();    // 呼叫 "IForm.Paint"
    }
}

file interface IExample
{
    // 1. 一般方法實作
    void Method1()
    {
        Console.WriteLine("Default implementation");
    }

    // 2. 屬性的預設實作
    string PropertyName
    {
        get => "Default Value";
        set => Console.WriteLine($"Setting value: {value}");
    }

    // 3. 事件的預設實作
    event EventHandler MyEvent
    {
        add => Console.WriteLine("Event added");
        remove => Console.WriteLine("Event removed");
    }

    // 4. 索引器的預設實作
    string this[int index]
    {
        get => $"Default value at {index}";
        set => Console.WriteLine($"Setting value at {index}: {value}");
    }

    // 5. 靜態成員
    static void StaticMethod() => Console.WriteLine("Static method");
    static string StaticProperty { get; set; } = "Static property";

    // 6. 常數和靜態欄位
    const int Constant = 100;
    static readonly string ReadOnlyField = "Read-only";

    // 7. 可以呼叫其他介面方法
    void CompositeMethod()
    {
        Method1();
        Console.WriteLine(PropertyName);
    }

    // 可以使用 LINQ 和其他 C# 功能
    void LinqExample()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
    }

    // 可以使用非同步方法
    async Task AsyncMethod()
    {
        await Task.Delay(1000);
        Console.WriteLine("Async operation completed");
    }

    // 可以使用泛型
    T GenericMethod<T>(T input) where T : class
    {
        return input;
    }

    // 複雜的演算法實作
    int CalculateFactorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("數字不能小於0");

        int result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    // 複雜的字串處理
    string ProcessText(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        var words = input.Split(' ');
        var result = new StringBuilder();

        foreach (var word in words)
        {
            if (word.Length > 3)
            {
                result.Append(char.ToUpper(word[0]))
                      .Append(word.Substring(1).ToLower())
                      .Append(' ');
            }
        }

        return result.ToString().Trim();
    }

    // 複雜的集合處理
    Dictionary<string, int> AnalyzeText(string text)
    {
        var wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        if (string.IsNullOrEmpty(text))
            return wordCount;

        foreach (var word in text.Split(new[] { ' ', '.', ',', '!', '?' },
                                      StringSplitOptions.RemoveEmptyEntries))
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }

        return wordCount;
    }

    // 遞迴方法
    int CalculateFibonacci(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;

        return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
    }
}
