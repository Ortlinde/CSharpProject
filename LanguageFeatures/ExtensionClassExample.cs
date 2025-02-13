namespace CSharpProject.LanguageFeatures;

/// <summary>
/// 示範擴展方法的使用
/// </summary>
public static class ExtensionClassExample
{
    /// <summary>
    /// 為 int 類型添加加法擴展方法
    /// </summary>
    public static int Add(this int a, int b) => a + b;

    /// <summary>
    /// 檢查字符串是否為空或空白
    /// </summary>
    public static bool IsNullOrWhiteSpace(this string? text)
        => string.IsNullOrWhiteSpace(text);

    /// <summary>
    /// 將字符串轉換為指定長度，如果過長則截斷並添加省略號
    /// </summary>
    public static string Truncate(this string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text)) return text;
        return text.Length <= maxLength ? text : text[..maxLength] + "...";
    }
}

/// <summary>
/// 示範擴展方法的用法
/// </summary>
public class ExtensionMethodUsage
{
    public void Example()
    {
        int result = 5.Add(3); // 使用擴展方法
        // 很長的字串
        string text = "The life and strange surprizing adventures of Robinson Crusoe, of York, mariner: who lived eight and twenty years all alone in an un-inhabited island on the coast of America, near the mouth of the great river of Oroonoque; having been cast on shore by shipwreck, wherein all the men perished but himself.";
        string truncated = text.Truncate(10); // 使用擴展方法
        // 編譯器實際上大概的調用情形
        // truncated = ExtensionClassExample.Truncate(text, 10);

        Console.WriteLine($"result: {result}");
        Console.WriteLine($"text: {text}");
        Console.WriteLine($"truncated: {truncated}");
    }
}

file class Person
{
    private int age;  // 無法在擴展方法中存取

    public string? Name { get; set; }  // 可以在擴展方法中存取
}

file static class PersonExtensions
{
    public static void PrintName(this Person p)
    {
        Console.WriteLine(p.Name);  // ✅ 可存取
        // Console.WriteLine(p.age); // ❌ 錯誤：無法存取 private 成員
    }
}
