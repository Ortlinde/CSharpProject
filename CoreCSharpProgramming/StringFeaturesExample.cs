namespace CSharpProject.CoreCSharpProgramming;

public class StringFeaturesExample
{
    public void Test()
    {
        // 1. 從字串解析值
        Console.WriteLine("1. 字串解析：");
        bool b = bool.Parse("True");
        double d = double.Parse("123.45");
        int i = int.Parse("1234");
        Console.WriteLine($"布林值: {b}");
        Console.WriteLine($"浮點數: {d}");
        Console.WriteLine($"整數: {i}");

        // 2. 逐字字串（Verbatim String）
        Console.WriteLine("\n2. 逐字字串：");
        string verbatimString = @"Test for verbatim string \
The second line
""The third line with double quote""";
        Console.WriteLine(verbatimString);

        // 3. 字串相等性比較
        Console.WriteLine("\n3. 字串相等性比較：");
        string str1 = "Hello";
        string str2 = "Hello";
        string str3 = new string(new char[] { 'H', 'e', 'l', 'l', 'o' });

        // 比較字串內容
        Console.WriteLine($"str1 == str2: {str1 == str2}");          // True
        Console.WriteLine($"str1 == str3: {str1 == str3}");          // True

        // 比較參考
        Console.WriteLine($"ReferenceEquals(str1, str2): {ReferenceEquals(str1, str2)}");  // True（字串池）
        Console.WriteLine($"ReferenceEquals(str1, str3): {ReferenceEquals(str1, str3)}");  // False（新物件）

        // 比較內容使用 Equals
        Console.WriteLine($"str1.Equals(str2): {str1.Equals(str2)}");  // True
        Console.WriteLine($"str1.Equals(str3): {str1.Equals(str3)}");  // True
    }
}