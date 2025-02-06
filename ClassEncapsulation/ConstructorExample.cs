namespace CSharpProject.ClassEncapsulation;

public class ConstructorExample
{
    public class Person
    {
        private string name;
        private int age;

        // 主要建構函式
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // 次要建構函式，使用this()鏈結到主要建構函式
        public Person(string name) : this(name, 0)
        {
        }

        // 明確宣告預設建構函式
        public Person() : this("未命名", 0)
        {
        }
    }
}

public static class MathUtility
{
    static int calculationCount = 0;

    static MathUtility()
    {
        Console.WriteLine("MathUtility 靜態建構函式被呼叫");
    }

    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int GetCalculationCount()
    {
        return calculationCount;
    }
}

public class Calculator
{
    // 靜態欄位
    private static int calculationCount = 0;

    // 非靜態欄位
    private int lastResult;

    // 靜態方法
    public static int Add(int a, int b)
    {
        calculationCount++; // 可以存取靜態欄位
        return a + b;
        // 無法存取 lastResult，因為它是非靜態的
    }

    // 非靜態方法
    public void Calculate(int x, int y)
    {
        // 非靜態方法可以同時存取靜態和非靜態成員
        lastResult = Add(x, y);  // 可以呼叫靜態方法
        calculationCount++;      // 可以存取靜態欄位
    }

    // 靜態屬性
    public static int TotalCalculations
    {
        get { return calculationCount; }
    }
}

// 使用方式
file class Program
{
    static void Test()
    {
        // 直接通過類別呼叫靜態方法
        int result = Calculator.Add(5, 3);

        // 查看總計算次數
        int total = Calculator.TotalCalculations;
    }
}