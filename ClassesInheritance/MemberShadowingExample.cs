namespace CSharpProject.ClassesInheritance;

file class BaseClass
{
    public BaseClass()
    {
        Print();
    }

    protected int x = 10;
    public virtual void Print()
    {
        System.Console.WriteLine("BaseClass");
    }
}

file class ChildClass : BaseClass
{
    protected new int x = 20;
    public new void Print()
    {
        System.Console.WriteLine("ChildClass");
    }
}

public class MemberShadowingExample
{
    public static void Test()
    {
        ChildClass child = new();
        child.Print();
    }

    public static void TestPolymorphism()
    {
        BaseClass baseClass = new ChildClass();
        baseClass.Print();
    }

    public static void TestQuestion()
    {
        ChildClass child = new();
    }
}