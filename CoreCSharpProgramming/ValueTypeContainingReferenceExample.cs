namespace CSharpProject.CoreCSharpProgramming;

// 值型別（結構）
public struct ValContainRef
{
    public ClassTest2 refObject;    // 參考型別欄位
    public string infoString;      // 參考型別欄位

    public void Display()
    {
        Console.WriteLine($"{infoString} contains reference object (value1: {refObject.Value1} and value2: {refObject.Value2})");
    }
}

// 參考型別（類別）
public class ClassTest2
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
}

public class ValueTypeContainingReferenceExample
{
    public void Test()
    {
        // 建立第一個結構實例
        ValContainRef vr1;
        vr1.refObject = new ClassTest2();
        vr1.infoString = "object 1";

        // 複製結構（值型別的複製）
        ValContainRef vr2 = vr1;
        vr2.infoString = "object 2";  // 修改字串參考

        Console.WriteLine("修改前：");
        vr1.Display();
        vr2.Display();

        // 修改參考型別的內容
        vr1.refObject.Value1 = 10;
        vr1.refObject.Value2 = 10;

        Console.WriteLine("\n修改後：");
        vr1.Display();
        vr2.Display();
    }
}