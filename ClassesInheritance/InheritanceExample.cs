namespace CSharpProject.ClassesInheritance;

file class BaseClass
{
    protected int x = 10;
    public virtual void Print()
    {
        System.Console.WriteLine("BaseClass");
    }
}

file interface IInterface1
{
    void Print1();
}

file interface IInterface2
{
    void Print2();
}

file class ChildClass : BaseClass, IInterface1, IInterface2
{
    public ChildClass() : base()
    {
        base.x = 20;
    }

    public override void Print()
    {
        base.Print();
    }

    public void Print1()
    {
        System.Console.WriteLine("ChildClass Print1");
    }

    public void Print2()
    {
        System.Console.WriteLine("ChildClass Print2");
    }
}

// public sealed class SealedClass
// {
// }

// public class ExtendedClass : SealedClass
// {
// }

// public struct Struct
// {
// }

// public class Struct2 : Struct
// {
// }
