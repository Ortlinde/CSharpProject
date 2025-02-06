namespace CSharpProject.CoreCSharpProgramming;

public class NullableTypeExample
{
    public void Test()
    {
        // 1. 宣告可空值型別
        int? nullableInt = null;           // 使用 ? 語法
        Nullable<double> nullableDouble = null;  // 使用完整語法
        bool? nullableBool = null;

        Console.WriteLine("1. 可空值型別的基本使用：");
        Console.WriteLine($"nullableInt: {nullableInt ?? 0}");
        Console.WriteLine($"nullableDouble: {nullableDouble ?? 0.0}");
        Console.WriteLine($"nullableBool: {nullableBool ?? false}");

        // 2. 賦值和檢查
        Console.WriteLine("\n2. 賦值和檢查：");
        nullableInt = 42;
        Console.WriteLine($"是否有值：{nullableInt.HasValue}");
        Console.WriteLine($"值：{nullableInt.Value}");  // 如果為 null 會拋出異常

        // 3. ?? 運算子的使用
        Console.WriteLine("\n3. ?? 運算子：");
        // 如果 nullableInt 為 null，使用 -1
        int definiteInt = nullableInt ?? -1;
        Console.WriteLine($"definiteInt: {definiteInt}");

        // 4. 條件運算和 null 檢查
        Console.WriteLine("\n4. 條件運算和 null 檢查：");
        nullableInt = null;
        if (nullableInt.HasValue)
        {
            Console.WriteLine($"值為：{nullableInt.Value}");
        }
        else
        {
            Console.WriteLine("值為 null");
        }

        // 5. 可空值型別的運算
        Console.WriteLine("\n5. 可空值型別的運算：");
        int? a = 10;
        int? b = null;
        Console.WriteLine($"a + b = {a + b}");  // 結果為 null
        Console.WriteLine($"a + 5 = {a + 5}");  // 結果為 15

        // 6. 比較運算
        Console.WriteLine("\n6. 比較運算：");
        int? x = 10;
        int? y = null;
        Console.WriteLine($"x > y: {x > y}");     // false
        Console.WriteLine($"x == null: {x == null}");  // false
        Console.WriteLine($"y == null: {y == null}");  // true
    }
}