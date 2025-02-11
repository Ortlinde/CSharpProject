using System.Collections;

namespace CSharpProject.Collections;

public class CollectionsExample
{
    public static void Test()
    {
        List<int> intList = new List<int>();      // 生成int版本
        List<double> dblList = new List<double>(); // 生成double版本

        List<string> strList = new List<string>(); // JIT生成機器碼
        List<object> objList = new List<object>(); // 共享之前的機器碼
    }

    public static void Test2()
    {
        Example example = new Example();
        int a = 1;
        int b = 2;

        example.Swap<int>(ref a, ref b);

        example.Swap(ref a, ref b); // <int> 可以省略
    }
}

file class Example
{
    public void Swap<T>(ref T a, ref T b)
    {
        (b, a) = (a, b);
    }
}