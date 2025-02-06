#pragma warning disable CS8618

namespace CSharpProject.CoreCSharpProgramming;

public class Person
{
    public string Name { get; set; }
    public Address? Address { get; set; }
    public List<string>? PhoneNumbers { get; set; }
}

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
}

public class NullConditionalExample
{
    public void Test()
    {
        // 1. 基本使用
        Person? person = null;
        Console.WriteLine("1. 基本使用：");
        // 不會拋出 NullReferenceException
        Console.WriteLine($"姓名：{person?.Name}");

        // 2. 鏈式呼叫
        Console.WriteLine("\n2. 鏈式呼叫：");
        // 如果 person 或 Address 為 null，返回 null 而不是拋出異常
        Console.WriteLine($"城市：{person?.Address?.City}");

        // 3. 陣列和集合
        Console.WriteLine("\n3. 陣列和集合：");
        // 安全地存取集合元素
        Console.WriteLine($"第一個電話：{person?.PhoneNumbers?[0]}");
        Console.WriteLine($"電話數量：{person?.PhoneNumbers?.Count}");

        // 4. 有資料的情況
        person = new Person
        {
            Name = "張三",
            Address = new Address { City = "台北", Street = "中正路" },
            PhoneNumbers = new List<string> { "1234567", "7654321" }
        };

        Console.WriteLine("\n4. 有資料的情況：");
        Console.WriteLine($"姓名：{person?.Name}");
        Console.WriteLine($"城市：{person?.Address?.City}");
        Console.WriteLine($"第一個電話：{person?.PhoneNumbers?[0]}");

        // 5. 搭配 ?? 運算子
        Console.WriteLine("\n5. 搭配 ?? 運算子：");
        string city = person?.Address?.City ?? "未知城市";
        string phone = person?.PhoneNumbers?[2] ?? "無此號碼";
        Console.WriteLine($"城市：{city}");
        Console.WriteLine($"第三個電話：{phone}");
    }
}