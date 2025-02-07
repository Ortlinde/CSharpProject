namespace CSharpProject.ClassesInheritance;

// File1.cs
partial class Customer
{
    public string? Name { get; set; }
}

// File2.cs
partial class Customer
{
    /// <summary>
    /// 計算兩個數字的總和
    /// </summary>
    /// <param name="x">第一個數字</param>
    /// <param name="y">第二個數字</param>
    /// <returns>兩數之和</returns>
    public int Add(int x, int y)
    {
        return x + y;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(Name);
    }
}

public class NumberGenerator
{
    public IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 0; i <= max; i++)
        {
            if (i % 2 == 0)
            {
                yield return i;
            }
        }
    }
}

