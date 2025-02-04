namespace CSharpProject.CoreCSharpProgramming;

public class IntrinsicDataType
{

    public static void TestDescimal()
    {
        decimal i = 10.000M;
        Console.WriteLine(i);
    }

    static Point p;
    public static void TestStruct()
    {
        Console.WriteLine(p);
        Console.WriteLine(p.x);
        Console.WriteLine(p.y);
    }

    static PointClass? pClass;
    public static void TestClass()
    {
        Console.WriteLine(pClass);
        // Console.WriteLine(pClass.x);
        // Console.WriteLine(pClass.y);
    }

    static Color c;
    public static void TestEnum()
    {
        Console.WriteLine(c);
    }
}

class PointClass
{
    public int x;
    public int y;
}

struct Point
{
    public int x;
    public int y;
}

enum Color
{
    Red,
    Green,
    Blue
}
