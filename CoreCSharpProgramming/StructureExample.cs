namespace CSharpProject.CoreCSharpProgramming;

// 定義一個簡單的結構
public struct PointStruct
{
    public int X;
    public int Y;

    // 自定義建構函式
    public PointStruct(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

public class StructureExample
{
    public void Test()
    {
        // 使用 new 和自定義建構函式
        PointStruct p1 = new PointStruct(10, 20);
        Console.WriteLine($"p1: {p1}");

        // 使用 new 和預設建構函式
        PointStruct p2 = new PointStruct();  // X 和 Y 會被設為 0
        Console.WriteLine($"p2: {p2}");

        // 直接宣告並手動賦值
        PointStruct p3;
        p3.X = 30;
        p3.Y = 40;
        Console.WriteLine($"p3: {p3}");
    }
}