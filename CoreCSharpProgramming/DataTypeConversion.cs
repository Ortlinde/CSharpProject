namespace CSharpProject.CoreCSharpProgramming;

public class DataTypeConversion
{
    public static void DemonstrateConversions()
    {
        // 隱式轉換（Widening）- 自動進行，安全
        short smallNumber = 100;
        int largerNumber = smallNumber;  // short 自動轉換為 int
        Console.WriteLine("largerNumber: " + largerNumber);
        long evenLarger = largerNumber;  // int 自動轉換為 long
        Console.WriteLine("evenLarger: " + evenLarger);
        object obj = evenLarger; // long 自動轉換為 object
        Console.WriteLine("--------------------------------");

        // 顯式轉換（Narrowing）- 需要明確轉型，可能損失資料
        int bigNumber = 1000;
        short smallerNumber = (short)bigNumber;  // 需要明確轉型
        Console.WriteLine("smallerNumber: " + smallerNumber);
        long longTypeNumber = (long)obj; // object 轉換為 long 需要明確轉型
        // string str = (string)obj; // object 轉換為 string 需要明確轉型
        Console.WriteLine("--------------------------------");

        // 可能發生溢出的範例
        int veryBigNumber = 40000;
        short willOverflow = (short)veryBigNumber;  // 超出 short 的範圍會溢出
        Console.WriteLine("willOverflow: " + willOverflow);
        Console.WriteLine("--------------------------------");

        // 使用 checked 關鍵字來檢查溢出
        int maxValue = int.MaxValue;
        // int result = maxValue + 1;
        // int result = int.MaxValue + 1; // 編譯器在計算時就溢出，編譯不會過
        int result = checked(maxValue + 1);  // 會拋出 OverflowException
        Console.WriteLine("result: " + result);
        Console.WriteLine("--------------------------------");

        checked
        {
            try
            {
                short willThrow = (short)veryBigNumber;
                Console.WriteLine("willThrow: " + willThrow);
            }
            catch (OverflowException)
            {
                // 處理溢出異常
                throw;
            }
        }
    }
}