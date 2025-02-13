namespace CSharpProject.LanguageFeatures;

public class AnonymousTypeExample
{
    public void Example()
    {
        var person = new { Name = "John", Age = 30 };
        var person2 = new { Name = "Alex", Age = 20 };

        Console.WriteLine($"person: {person.Name}, {person.Age}");
        Console.WriteLine($"person2: {person2.Name}, {person2.Age}");
        System.Console.WriteLine(person.GetType());
        System.Console.WriteLine(person2.GetType());

        var point = new { X = 1, Y = 2 };

        Console.WriteLine($"point: {point.X}, {point.Y}");
        System.Console.WriteLine(point.GetType());
    }

    public void EqualityExample()
    {
        var person = new { Name = "John", Age = 30 };
        var person2 = new { Name = "John", Age = 30 };

        Console.WriteLine(person.Equals(person2));
        Console.WriteLine(person == person2);
    }

    public void NestedExample()
    {
        var person = new { Name = "John", Age = 30, Address = new { City = "New York", Country = "USA" } };
        var person2 = new { Name = "Alex", Age = 20, Address = new { City = "Los Angeles", Country = "USA" } };

        Console.WriteLine($"person: {person.Name}, {person.Age}");
        Console.WriteLine($"person2: {person2.Name}, {person2.Age}");
        System.Console.WriteLine(person.GetType());
        System.Console.WriteLine(person2.GetType());
    }
}

