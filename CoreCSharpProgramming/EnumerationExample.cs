namespace CSharpProject.CoreCSharpProgramming;

// 定義不同基礎型別的列舉
public enum ColorEnum : int  // 預設是 int，可以省略
{
    Red = 1,
    Green = 2,
    Blue = 3
}

public enum SizeEnum : byte
{
    Small = 1,
    Medium = 2,
    Large = 3
}

public class EnumerationExample
{
    public void Test()
    {
        // 使用列舉
        ColorEnum myColor = ColorEnum.Red;
        Console.WriteLine($"顏色名稱: {myColor}");  // 使用 ToString()
        Console.WriteLine($"顏色數值: {(int)myColor}");  // 轉換為底層型別

        // 使用 byte 型別的列舉
        SizeEnum mySize = SizeEnum.Medium;
        Console.WriteLine($"尺寸名稱: {mySize}");
        Console.WriteLine($"尺寸數值: {(byte)mySize}");
    }
}