using System.Collections;

namespace CSharpProject.StructuredExceptionHandling;

public class ExceptionExample
{
    public static void Test()
    {
        try
        {
            A();
        }
        catch (Exception ex)
        {
            // 添加自定義資訊
            ex.Data["時間"] = DateTime.Now;
            ex.Data["使用者"] = "當前使用者";

            Console.WriteLine($"異常方法: {ex.TargetSite}");
            Console.WriteLine($"堆疊追蹤: {ex.StackTrace}");
            Console.WriteLine("額外資訊:");
            foreach (DictionaryEntry entry in ex.Data)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }

    public static void A() { B(); }
    public static void B() { C(); }
    public static void C() { throw new OrderProcessingException("發生錯誤", "訂單處理錯誤"); }

    public static void Test2()
    {
        try
        {
            int[] numbers = new int[5];
            Console.WriteLine(numbers[10]);  // 將拋出 IndexOutOfRangeException
        }
        catch (Exception ex)
        {
            if (ex is SystemException)
            {
                Console.WriteLine("捕獲到系統異常");
            }
            throw;
        }
    }

    public static void Test3()
    {
        string orderId = "";
        try
        {
            if (!ValidateOrder(orderId))
            {
                throw new OrderProcessingException(
                    orderId,
                    "訂單驗證失敗"
                );
            }
        }
        catch (OrderProcessingException ex)
        {
            Console.WriteLine($"訂單 {ex.OrderId} 處理失敗：{ex.Message}");
        }
    }

    public static bool ValidateOrder(string orderId)
    {
        return !string.IsNullOrEmpty(orderId);
    }

    public static void Test4()
    {
        try
        {
            // 可能拋出異常的代碼
            A();
        }
        catch (OrderProcessingException)  // 最具體的異常
        {
            throw;  // 重新拋出
        }
        catch (ApplicationException)      // 較通用的異常
        {
            throw;
        }
        catch (Exception)                 // 最通用的異常
        {
            throw;
        }
    }

    public static void Test5()
    {
        string orderId = "123";
        try
        {
            try
            {
                // 原始操作
                ProcessOrder(orderId);
            }
            catch (DbException ex)
            {
                // 將資料庫異常包裝為業務異常，並保留原始異常信息
                throw new OrderProcessingException(
                    orderId,
                    "訂單處理過程中發生資料庫錯誤",
                    ex  // 保存為內部異常
                );
            }
        }
        catch (OrderProcessingException ex)
        {
            // 可以訪問完整的異常鏈
            Console.WriteLine($"主要錯誤: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"原始錯誤: {ex.InnerException.Message}");
            }
        }
    }

    public static void ProcessOrder(string orderId)
    {
        throw new DbException("資料庫錯誤");
    }
}

file class MyException : Exception

{
    public MyException(string message) : base(message)
    {
    }
}

file class DbException : Exception
{
    public DbException(string message) : base(message)
    {
    }
}

// 與特定業務邏輯相關的自定義異常
file class OrderProcessingException : ApplicationException

{
    public string OrderId { get; }
    public OrderProcessingException(string orderId, string message)
        : base(message)
    {
        OrderId = orderId;
    }

    public OrderProcessingException(string orderId, string message, Exception innerException)
        : base(message, innerException)
    {
        OrderId = orderId;
    }
}