namespace CSharpProject.CoreCSharpProgramming;

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"員工: {Name}, 薪資: {Salary:C}";
    }
}

public class ReferenceTypeExample
{
    public void Test()
    {
        // 在堆積上創建 Employee 物件
        Employee ee1 = new Employee("張三", 50000m);

        // ee2 指向與 ee1 相同的物件
        Employee ee2 = ee1;

        // 修改 ee2 會影響 ee1，因為它們指向相同物件
        ee2.Salary = 55000m;

        Console.WriteLine("修改後的結果：");
        Console.WriteLine($"ee1: {ee1}");
        Console.WriteLine($"ee2: {ee2}");

        // 使用相等運算子比較參考
        Console.WriteLine($"\n參考比較：");
        Console.WriteLine($"ee1 == ee2: {ee1 == ee2}");  // 會返回 true

        // 創建新的 Employee 物件
        Employee ee3 = new Employee("張三", 55000m);
        Console.WriteLine($"ee1 == ee3: {ee1 == ee3}");  // 會返回 false，因為是不同物件
    }
}