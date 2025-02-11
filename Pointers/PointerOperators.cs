namespace CSharpProject.Pointers;

public unsafe class PointerOperators
{
    public struct Point
    {
        public int X;
        public int Y;
    }

    public static void Test()
    {
        // 1. * 解引用運算符
        int number = 42;
        int* ptr = &number;
        Console.WriteLine($"解引用值: {*ptr}");  // 輸出: 42
        *ptr = 100;  // 通過指針修改值
        Console.WriteLine($"修改後的值: {number}");  // 輸出: 100

        // 2. & 取地址運算符
        double value = 3.14;
        double* addressPtr = &value;
        Console.WriteLine($"變量地址: {(long)addressPtr:X}");

        // 3. -> 成員訪問運算符（用於結構體）
        Point point = new Point { X = 10, Y = 20 };
        Point* pointPtr = &point;

        // 使用 -> 運算符訪問成員
        Console.WriteLine($"X: {pointPtr->X}");  // 輸出: 10
        Console.WriteLine($"Y: {pointPtr->Y}");  // 輸出: 20

        // 等價的寫法（使用 * 和 .）
        Console.WriteLine($"X: {(*pointPtr).X}"); // 與 pointPtr->X 相同
    }
}