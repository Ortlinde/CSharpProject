#pragma warning disable CS0618 // 類型或成員已過時

namespace CSharpProject.Pointers;

// 標示這個類別可以序列化
[SerializableAttribute]
public class AttributeExample
{
    public static void Test()
    {
        ObsoleteMethod();
    }

    // 標示這個方法已過時
    [Obsolete("這個方法已過時，請使用新版本")]
    public static void ObsoleteMethod()
    {
        Console.WriteLine("這是一個過時的方法");
    }
}
