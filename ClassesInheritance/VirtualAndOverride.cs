namespace CSharpProject.ClassesInheritance;

file class BaseClass
{
    public BaseClass()
    {
        Print();
    }

    public virtual void Print()
    {
        System.Console.WriteLine("BaseClass");
    }
}

file class ChildClass : BaseClass
{
    public sealed override void Print()
    {
        base.Print();
        System.Console.WriteLine("ChildClass");
    }

    public override string ToString()
    {
        return "This is a ChildClass";
    }
}

file interface IDrawable
{
    void Draw();
}

file interface IShape
{
    abstract double CalculateArea();
    abstract double CalculatePerimeter();
    abstract string Color { get; set; }
}

file class Circle : IShape, IDrawable
{
    public void Draw()
    {
        System.Console.WriteLine($"Drawing a {Color} circle with radius {Radius}");
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double CalculatePerimeter()
    {
        return 2.0 * Math.PI * Radius;
    }

    public double Radius { get; set; }
    public string Color { get; set; } = "Red";
}

public class VirtualAndOverride
{
    public static void Test()
    {
        ChildClass child = new();
        child.Print();
    }

    public static void Test2()
    {
        // Auto upcasting
        BaseClass UpcastToBaseClass = new ChildClass();
        System.Console.WriteLine(UpcastToBaseClass);

        UpcastToBaseClass.Print();

        // Downcasting will check at runtime
        ChildClass DowncastToChildClass = (ChildClass)UpcastToBaseClass;
        DowncastToChildClass.Print();

        // Another way to downcast
        // This will return null if the object is not of the specified type
        ChildClass? DowncastToChildClass2 = UpcastToBaseClass as ChildClass;
        DowncastToChildClass2?.Print();

        // Use "is" keyword to check if the object is of a certain type
        if (UpcastToBaseClass is ChildClass DowncastToChildClass3)
        {
            DowncastToChildClass3.Print();
        }
    }

    public static void Test3()
    {
        BaseClass baseClass = new();

        // This will throw a runtime exception
        ChildClass childClass = (ChildClass)baseClass;
        childClass.Print();

        // This will return null    
        ChildClass? childClass2 = baseClass as ChildClass;
        childClass2?.Print();

        // This will check if the object is of a certain type
        if (baseClass is ChildClass childClass3)
        {
            // This code will not be executed
            childClass3.Print();
        }
    }

    public static void Test4()
    {
        string s = "Hello";
        string s2 = "Hello";
        string s3 = new string("Hello");

        System.Console.WriteLine(s == s2);
        System.Console.WriteLine(s == s3);
        System.Console.WriteLine("--------------------------------");

        System.Console.WriteLine(s.Equals(s2));
        System.Console.WriteLine(s.Equals(s3));
        System.Console.WriteLine("--------------------------------");

        System.Console.WriteLine(s.GetHashCode());
        System.Console.WriteLine(s2.GetHashCode());
        System.Console.WriteLine(s3.GetHashCode());
        System.Console.WriteLine("--------------------------------");

        System.Console.WriteLine(ReferenceEquals(s, s2));
        System.Console.WriteLine(ReferenceEquals(s, s3));
    }

    public static void Test5()
    {
        Circle circle = new() { Radius = 10, Color = "Blue" };

        IShape shape = circle;
        System.Console.WriteLine(shape.CalculateArea());

        if (circle is IDrawable drawable)
        {
            drawable.Draw();
        }
    }
}