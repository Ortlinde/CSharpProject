namespace CSharpProject.OperatorOverloading;

file class MyClass
{
    private int[] _data = new int[100];

    public int this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }

    public int this[string index]
    {
        get => _data[int.Parse(index)];
        set => _data[int.Parse(index)] = value;
    }
}

file interface IMyInterface
{
    int this[int index] { get; set; }
    int this[string index] { get; set; }
}

public class IndexerExample


{
    public static void Test()
    {
        var myClass = new MyClass();
        myClass[0] = 10;
        Console.WriteLine(myClass[0]);
    }
}