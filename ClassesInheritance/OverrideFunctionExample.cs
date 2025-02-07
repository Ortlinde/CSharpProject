namespace CSharpProject.ClassesInheritance;

file class Person
{
    public string? Name { get; set; }
    public override string ToString()
    {
        return $"人: {Name}";
    }

    public override bool Equals(object? obj)
    {
        if (Name == null)
            return false;

        if (obj is Person other)
        {
            return this.Name == other.Name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
}

public class OverrideFunctionExample
{
    public static void Test()
    {
        Person person = new() { Name = "John" };
        System.Console.WriteLine(person);

        Person person2 = new() { Name = "John" };
        System.Console.WriteLine(person2);

        Person person3 = new() { Name = "Henry" };
        System.Console.WriteLine(person3);

        System.Console.WriteLine(person.Equals(person2));
        System.Console.WriteLine(person.Equals(person3));

        System.Console.WriteLine(person.GetHashCode());
        System.Console.WriteLine(person2.GetHashCode());
        System.Console.WriteLine(person3.GetHashCode());
    }
}
