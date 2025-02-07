namespace CSharpProject.ClassesInheritance;

public class ExplainICloneable
{
    public static void Test()
    {
        // 創建一個Person物件
        Person person1 = new Person { Name = "小明", Age = 25 };

        // 使用ICloneable的Clone方法複製物件
        Person person2 = (Person)person1.Clone();

        Console.WriteLine($"原始物件: {person1.Name}, {person1.Age}");
        Console.WriteLine($"複製物件: {person2.Name}, {person2.Age}");

        // 修改複製後的物件
        person2.Name = "小華";

        Console.WriteLine("\n修改後:");
        Console.WriteLine($"原始物件: {person1.Name}, {person1.Age}");
        Console.WriteLine($"複製物件: {person2.Name}, {person2.Age}");
    }
}

file class Person : ICloneable
{
    public string? Name { get; set; }
    public int Age { get; set; }

    // 實作ICloneable介面的Clone方法
    public object Clone()
    {
        // 建立一個新的Person物件，並複製所有屬性
        return new Person
        {
            Name = this.Name,
            Age = this.Age
        };
    }
}
