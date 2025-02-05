namespace CSharpProject.CoreCSharpProgramming;

public struct Customer
{
    public string Name;
    public int Age;
    public decimal Balance;

    public Customer(string name, int age, decimal balance)
    {
        Name = name;
        Age = age;
        Balance = balance;
    }

    public override string ToString()
    {
        return $"客戶: {Name}, 年齡: {Age}, 餘額: {Balance:C}";
    }
}

public class ValueTypeExample
{
    public void Test()
    {
        // 在方法範圍內建立值型別
        Customer customer1 = new Customer("張三", 30, 1000m);

        // 值型別的複製會複製所有欄位資料
        Customer customer2 = customer1;
        customer2.Name = "李四";  // 修改 customer2 不會影響 customer1

        Console.WriteLine("複製後的結果：");
        Console.WriteLine($"customer1: {customer1}");
        Console.WriteLine($"customer2: {customer2}");

        // 展示值型別是 System.ValueType 的子類
        Console.WriteLine($"\n型別資訊：");
        Console.WriteLine($"是否為值型別: {customer1.GetType().IsValueType}");
        Console.WriteLine($"基底類型: {customer1.GetType().BaseType}");

        DemonstrateStackAllocation();
    }

    private void DemonstrateStackAllocation()
    {
        // 這個方法結束時，temp 會立即從堆疊中移除
        Customer temp = new Customer("臨時客戶", 25, 500m);
        Console.WriteLine($"\n臨時物件: {temp}");
    } // temp 在這裡自動釋放
}