using System.Net.NetworkInformation;

namespace CSharpProject.ClassEncapsulation;

public class PropertyExample
{
    // 自動實作屬性
    public string? AutoProperty { get; set; }
    public string? AutoPrivateSetProperty { get; private set; }

    // 唯讀屬性
    public string? ReadOnly { get; }

    public string? ReadOnlyLambda => field;

    // 唯寫屬性
    public string WriteOnly
    {
        set { /* 設定值 */ }
    }

    // 計算屬性
    public int Age { get; set; }
    public bool IsAdult
    {
        get { return Age >= 18; }
    }

    // 靜態屬性
    private static int _count;
    public static int Count
    {
        get { return _count; }
        set { _count = value; }
    }

    // 帶有驗證的屬性
    // private int _score; // 不需要再宣告備份欄位
    public int Score
    {
        get;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("分數必須在0-100之間");
            field = value;
        }
    }
}