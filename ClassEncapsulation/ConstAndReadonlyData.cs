namespace CSharpProject.ClassEncapsulation;

public class ConstAndReadonlyData
{
    public const double PI = 3.141592653589793;
    public readonly double PI2 = 3.141592653589793;

    public ConstAndReadonlyData()
    {
        PI2 = 3.141592653589793;
    }

    public void PrintPI()
    {
        System.Console.WriteLine(PI);
        System.Console.WriteLine(PI2);
    }
}