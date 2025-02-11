namespace CSharpProject.Pointers;

public class PointerConcept
{
    public unsafe struct PtrStruct { }
    public unsafe class PtrClass { }
    public unsafe int* PtrInt;
    public unsafe void PtrMethod() { }
    public void UnsafeMethod()
    {
        unsafe
        {
            // 托管堆上的對象需要固定
            byte[] managedArray = new byte[100];
            fixed (byte* ptr = managedArray)
            {
                // 此時對象被固定，GC 不會移動它
                // ptr 可以安全使用
            }
            // 離開 fixed 塊後，對象可以被 GC 移動
        }
    }

    public static void Test()
    {
        unsafe
        {
            // 宣告並初始化一個整數
            int number = 42;

            // 創建一個指向該整數的指針
            int* pointer = &number;

            // 通過指針讀取值
            Console.WriteLine($"通過指針讀取的值: {*pointer}");  // 輸出: 42

            // 通過指針修改值
            *pointer = 100;
            Console.WriteLine($"修改後的值: {number}");  // 輸出: 100

            // 指針算術運算示例
            int* nextPointer = pointer + 1;  // 移動到下一個 int 位置（危險操作！）

            // 固定數組示例
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            fixed (int* arrayPointer = &numbers[0])
            {
                // 安全地訪問數組元素
                Console.WriteLine($"數組第一個元素: {*arrayPointer}");
            }
        }
    }
}

file unsafe class PointerExample<T> where T : unmanaged
{
    public unsafe T* Pointer;
    public unsafe T Value;
    public unsafe void PrintValue()
    {
        Console.WriteLine($"Value: {Value}");
    }
}
