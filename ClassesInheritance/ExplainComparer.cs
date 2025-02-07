using System.Collections;

namespace CSharpProject.ClassesInheritance;

public class Person : IComparable
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public int CompareTo(object? obj)
    {
        if (obj is Person other)
            return this.Age.CompareTo(other.Age);
        throw new ArgumentException("物件不是 Person");
    }
}

public class NameComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        if (x is Person p1 && y is Person p2)
            return string.Compare(p1.Name, p2.Name);
        throw new ArgumentException("物件不是 Person");
    }
}

public class ExplainComparer
{
    public static void Test()
    {
        // 使用
        Person[] people = new Person[] {
            new Person { Name = "小明", Age = 30 },
            new Person { Name = "小華", Age = 25 },
            new Person { Name = "小李", Age = 35 }
        };
        Array.Sort(people);  // 按年齡排序 (IComparable)
        Array.Sort(people, new NameComparer());  // 按姓名排序 (IComparer)
    }
}