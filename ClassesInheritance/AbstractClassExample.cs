namespace CSharpProject.ClassesInheritance;

file abstract class BaseClass
{
    public abstract void Print();
}

file class ChildClass : BaseClass
{
    public override void Print()
    {
        System.Console.WriteLine("ChildClass");
    }
}

public class AbstractClassExample
{
    public static void Test()
    {
        BaseClass baseClass = new ChildClass();
        baseClass.Print();
    }
}
