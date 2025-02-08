namespace CSharpProject.StructuredExceptionHandling;

internal class ExceptionProformance
{

}

file class OrderProcessor
{
    // 不好的做法 - 使用異常進行流程控制
    public void BadExample(Order order)
    {
        try
        {
            if (order.Amount <= 0)
                throw new ArgumentException("金額必須大於零");
            // 處理訂單...
        }
        catch (ArgumentException)
        {
            // 不應該用異常處理正常的業務邏輯
        }
    }

    // 好的做法 - 使用條件判斷進行流程控制
    public bool GoodExample(Order order)
    {
        if (order.Amount <= 0)
        {
            return false;  // 直接返回結果
        }

        // 處理訂單...
        return true;
    }
}

file class Order
{
    public decimal Amount { get; set; }
}