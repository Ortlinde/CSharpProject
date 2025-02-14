namespace CSharpProject.Pointers;

public unsafe class StackallocExample
{
    public static void Test()
    {
        // 1. 基本使用 - 分配在棧上的整數數組
        Span<int> numbers = stackalloc int[5];
        for (int i = 0; i < 5; i++)
        {
            numbers[i] = i * 10;
        }

        // 2. 使用初始化器
        Span<int> initialized = stackalloc int[] { 1, 2, 3, 4, 5 };

        // 3. 指針方式使用
        int* pointer = stackalloc int[3];
        pointer[0] = 10;
        pointer[1] = 20;
        pointer[2] = 30;

        // 4. 結構體數組
        Point* points = stackalloc Point[2];
        points[0] = new Point { X = 1, Y = 1 };
        points[1] = new Point { X = 2, Y = 2 };
    }

    static int[] nums = [10, 20, 30, 40, 50];
    public static void Test2()
    {
        Span<int> span = nums;

        foreach (var number in nums)
        {
            Console.WriteLine(number);
        }

        span[4] = 100;
        Console.WriteLine("--------------------------------");

        foreach (var number in nums)
        {
            Console.WriteLine(number);
        }
    }

    struct Point
    {
        public int X;
        public int Y;
    }
}

public unsafe ref struct StackallocStruct
{
    public Span<int> Numbers = stackalloc int[5]; // 
    // public int* NumbersPtr = stackalloc int[5]; // 

    public StackallocStruct()
    {
        // NumbersPtr = stackalloc int[5];
    }
}
