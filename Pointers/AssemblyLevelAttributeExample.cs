using System.Reflection;
using System.Configuration;

// 必須放在 namespace 之外
[assembly: AssemblyDescription("這是描述")]
[assembly: AssemblyCopyright("版權所有")]

namespace CSharpProject.Pointers;
// 這裡不能放置 assembly 特性

class AssemblyLevelAttributeExample
{
    public static void Test()
    {
        Console.WriteLine("這是一個組件級別特性示例");

        // 讀取配置值的例子
        // AppSettingsReader reader = new AppSettingsReader();
        // string value = (string)reader.GetValue("設置名稱", typeof(string));
    }
}
