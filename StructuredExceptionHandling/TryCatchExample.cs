namespace CSharpProject.StructuredExceptionHandling;

public class TryCatchExample
{
    public static void Test()
    {
        try
        {
            Console.Write("請輸入一個數字: ");
            string? input = Console.ReadLine();
            int number = int.Parse(input!);

            int result = 100 / number;
            Console.WriteLine($"100 除以 {number} 的結果是: {result}");
        }
        // 當用戶輸入的不是數字時，會拋出 FormatException 異常
        catch (FormatException ex)
        {
            Console.WriteLine($"輸入格式錯誤: {ex.Message}");
        }
        // 當用戶輸入的是 0 時，會拋出 DivideByZeroException 異常
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"除數不能為零: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("程式執行完畢");
        }
    }
}