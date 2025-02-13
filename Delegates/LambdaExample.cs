namespace Delegates;

public class LambdaExample
{
    public void BasicExamples()
    {
        // 1. 傳統匿名方法
        Func<int, bool> isEven1 = delegate (int i)
        {
            return i % 2 == 0;
        };

        // 2. Lambda 表達式 - 完整語法
        Func<int, bool> isEven2 = (int i) =>
        {
            return i % 2 == 0;
        };

        // 3. Lambda 表達式 - 簡化語法
        Func<int, bool> isEven3 = i => i % 2 == 0;
    }
}

public class LambdaParameters
{
    public void ParameterExamples()
    {
        // 無參數
        Action noParam = () => Console.WriteLine("Hello");

        // 單一參數
        Action<string> singleParam = name => Console.WriteLine($"Hello {name}");

        // 多個參數
        Func<int, int, int> add = (x, y) => x + y;

        // 明確類型
        Func<double, double> square = (double x) => x * x;

        // 隱含類型（編譯器自動推斷）
        Func<int, int> number = x => x * 2;
    }
}

