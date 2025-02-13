namespace CSharpProject.LanguageFeatures;

public class ObjectsInitializerExample
{
    public void Example()
    {
        var person = new Person("Default Name", 0)
        {
            Name = "John",
            Age = 30
        };

        Console.WriteLine($"person: {person.Name}, {person.Age}");

        var point = new Point { X = 1, Y = 2 };
        Console.WriteLine($"point: {point.X}, {point.Y}");
    }
}

file class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }

    public Person(string name = "Default Name", int age = 20)
    {
        Name = name;
        Age = age;
    }
}

file struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
