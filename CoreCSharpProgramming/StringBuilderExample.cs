using System.Text;

namespace CSharpProject.CoreCSharpProgramming;

public class StringBuilderExample
{
    public void Test()
    {
        Console.WriteLine("1. 使用一般字串連接：");
        UseTraditionalString();

        Console.WriteLine("\n2. 使用 StringBuilder：");
        UseStringBuilder();

        Console.WriteLine("\n3. 字串操作比較：");
        CompareStringOperations();
    }

    private void UseTraditionalString()
    {
        string result = "";
        for (int i = 0; i < 5; i++)
        {
            result += $"第{i + 1}行文字\n";
            // 每次連接都會創建新的字串物件
        }
        Console.WriteLine(result);
    }

    private void UseStringBuilder()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 5; i++)
        {
            sb.AppendFormat("第{0}行文字\n", i + 1);
            // 直接修改內部緩衝區
        }
        Console.WriteLine(sb.ToString());
    }

    private void CompareStringOperations()
    {
        // 1. 一般字串操作
        string str = "Hello";
        str = str.Replace('l', 'L');   // 創建新字串
        str = str.ToUpper();           // 創建新字串
        Console.WriteLine($"字串結果: {str}");

        // 2. StringBuilder 操作
        StringBuilder sb = new StringBuilder("Hello");
        sb.Replace('l', 'L');          // 修改現有內容
        for (int i = 0; i < sb.Length; i++)
        {
            sb[i] = char.ToUpper(sb[i]);  // 直接修改字元
        }
        Console.WriteLine($"StringBuilder 結果: {sb}");

        // 3. 展示 StringBuilder 的其他功能
        StringBuilder sb2 = new StringBuilder();
        sb2.Append("第一行");          // 添加字串
        sb2.AppendLine();             // 添加換行
        sb2.AppendFormat("數字：{0:D5}", 123);  // 格式化
        sb2.Insert(0, "開始：");        // 插入文字
        sb2.Remove(8, 2);             // 移除部分文字
        Console.WriteLine($"\nStringBuilder 進階操作：\n{sb2}");
    }
}