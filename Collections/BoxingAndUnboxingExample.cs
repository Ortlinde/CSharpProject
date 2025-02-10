namespace CSharpProject.Collections;

public class BoxingAndUnboxingExample
{
    public static void Test()
    {
        // Boxing：將 int 值類型轉換為 object 參考類型
        int i = 123;
        object o = i;  // 裝箱操作

        // Unboxing：將 object 轉換回 int 值類型
        int j = (int)o;  // 拆箱操作

        // 錯誤的拆箱示例
        try
        {
            double d = (double)o;  // 會拋出 InvalidCastException
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine("類型轉換失敗：" + ex.Message);
        }

        if (o is int intValue)
        {
            Console.WriteLine(intValue);
        }
        else
        {
            Console.WriteLine("o 不是 int 類型");
        }

        Console.WriteLine(string.Format("Hello {0}", o));
    }
}