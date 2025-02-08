namespace CSharpProject.OperatorOverloading;

file readonly struct Digit
{
    public int Value { get; }
    public Digit(int value)
    {
        // 為保證值在 0~9 範圍內
        Value = value % 10;
    }

    // 定義隱式轉換：Digit → int
    // 呼叫者可以直接將 Digit 賦值給 int 變量，不需明確轉換。
    public static implicit operator int(Digit d) => d.Value;

    // 定義顯式轉換：int → Digit
    // 呼叫者必須使用 (Digit) 強制轉換才能將 int 轉換為 Digit。
    public static explicit operator Digit(int i) => new Digit(i);
}

public class TypeConversionExample
{
    public static void Test()
    {
        Digit digit = (Digit)15;  // 使用顯式轉換，結果為 5（15 % 10）
        int number = digit;  // 自動調用 implicit operator
    }
}
