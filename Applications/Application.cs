namespace CSharpProject.Applications;

public class Application
{
    public void Run()
    {
        ClassTest c1 = new();
        ClassTest c2 = c1;
        Console.WriteLine(c1.ToString());
        Console.WriteLine(c2.ToString());

        c1.value1 = 10;
        Console.WriteLine(c1.ToString());
        Console.WriteLine(c2.ToString());
    }
}

file class ClassTest
{
    public int value1;
    public int value2;

    public override string ToString()
    {
        return $"value1: {value1}, value2: {value2}";
    }
}

file struct StructTest
{
    public int value1;
    public int value2;

    public override string ToString()
    {
        return $"value1: {value1}, value2: {value2}";
    }
}