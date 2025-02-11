namespace CSharpProject.Collections;

public class GenericExample
{
    public static void Test()
    {
        // 1. 基本泛型類使用
        var numberBox = new Box<int>(42);
        var stringBox = new Box<string>("Hello");

        // 2. 泛型介面使用
        var repository = new Repository<Customer>();

        // 3. 使用泛型約束
        var calculator = new Calculator<decimal>();

        // 4. 使用預設值
        var defaultValue = GetDefaultExample<int>.GetDefault();
    }
}

// 基本泛型類
file class Box<T>
{
    private T _value;

    public Box(T value)
    {
        _value = value;
    }

    public T GetValue() => _value;
}

// 泛型介面
file interface IRepository<T>
{
    void Add(T item);
    T GetById(int id);

    public void Method(T item)
    {
        // Console.WriteLine((int)item == 5);
    }
}

// 實作泛型介面
file class Repository<T> : IRepository<T> where T : struct
{
    public void Add(T item) { }
    public T GetById(int id) => default;
}

// 使用泛型約束
file class Calculator<T> where T : struct
{
    public T Add(T a, T b) => throw new NotImplementedException();
}

file static class GetDefaultExample<T> where T : struct
{
    // 使用預設值的泛型方法
    public static T GetDefault() => default;
}

// 自定義類型作為泛型參數
file struct Customer
{
    public string? Name { get; set; }
    public int Age { get; set; }
}

