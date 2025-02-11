namespace CSharpProject.Pointers;

public class PointerOperatorExample
{
    public static unsafe void Test()
    {
        // int* p1, p2; // C# 宣告指標
        // int *p3, *p4; // C, C++ 宣告指標

        // 基本指標宣告和運算
        int x = 10;
        int y = 20;
        int* px = &x;
        int* py = &y;

        // 1. 解引用運算符 (*)
        Console.WriteLine($"px 指向的值: {*px}");  // 輸出: 10

        // 2. 地址運算符 (&)
        Console.WriteLine($"x 的地址: {(long)px:X}");

        // 3. 指標算術運算
        int[] numbers = new int[] { 1, 2, 3, 4, 5 };
        fixed (int* pArray = &numbers[0])
        {
            // 指標加法
            int* p1 = pArray;
            int* p2 = p1 + 2;  // 移動到第三個元素
            Console.WriteLine($"第三個元素: {*p2}");  // 輸出: 3

            // 指標減法
            int* p3 = p2 - 1;  // 回到第二個元素
            Console.WriteLine($"第二個元素: {*p3}");  // 輸出: 2

            // 指標比較
            Console.WriteLine($"p2 > p1: {p2 > p1}");  // 輸出: True

            // 計算指標之間的距離
            long distance = p2 - p1;  // 單位是元素個數，不是字節
            Console.WriteLine($"p2 和 p1 之間的距離: {distance}");  // 輸出: 2
        }

        // 4. 指標遞增/遞減
        fixed (int* pArray = &numbers[0])
        {
            int* current = pArray;
            Console.WriteLine($"當前元素: {*current}");  // 輸出: 1
            current++;  // 移動到下一個元素
            Console.WriteLine($"下一個元素: {*current}");  // 輸出: 2
        }
    }
}
