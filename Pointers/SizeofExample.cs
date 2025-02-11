namespace CSharpProject.Pointers;

public class SizeofExample
{
    public static void Test()
    {
        Console.WriteLine($"int 的大小：{sizeof(int)} bytes");
        Console.WriteLine($"long 的大小：{sizeof(long)} bytes");
        Console.WriteLine($"float 的大小：{sizeof(float)} bytes");
        Console.WriteLine($"double 的大小：{sizeof(double)} bytes");
        unsafe
        {
            Console.WriteLine($"Point 的大小：{sizeof(Point)} bytes");
        }
    }
}
file struct Point
{
    public Point(byte tag, double x, double y) => (Tag, X, Y) = (tag, x, y);

    public byte Tag { get; }
    public double X { get; }
    public double Y { get; }
}

file class SizeOfOperator
{
    public static void Test()
    {
        Console.WriteLine(sizeof(byte));  // output: 1
        Console.WriteLine(sizeof(double));  // output: 8

        DisplaySizeOf<Point>();  // output: Size of Point is 24
        DisplaySizeOf<decimal>();  // output: Size of System.Decimal is 16

        unsafe
        {
            Console.WriteLine(sizeof(Point*));  // output: 8
        }
    }

    static unsafe void DisplaySizeOf<T>() where T : unmanaged
    {
        Console.WriteLine($"Size of {typeof(T)} is {sizeof(T)}");
    }
}