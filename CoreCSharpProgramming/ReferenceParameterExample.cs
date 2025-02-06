namespace CSharpProject.CoreCSharpProgramming;

public class ClassTest
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }

    public void Display()
    {
        Console.WriteLine($"Value1: {Value1}, Value2: {Value2}");
    }
}

public class ReferenceParameterExample
{
    private static void PassRefTypeByValueAndRef
    (ClassTest valClassObj, ref ClassTest refClassObj)
    {
        // 修改傳值參數的屬性
        valClassObj.Value1 = 100;
        // 重新分配傳值參數（不影響原始參考）
        valClassObj = new ClassTest();
        valClassObj.Value1 = -100;

        // 修改傳參考參數的屬性
        refClassObj.Value1 = 200;
        // 重新分配傳參考參數（會影響原始參考）
        refClassObj = new ClassTest();
        refClassObj.Value1 = -200;
    }

    public void Test()
    {
        // 建立測試物件
        ClassTest testClassObj1 = new ClassTest();
        ClassTest testClassObj2 = new ClassTest();
        ClassTest testClassObj2Ref = testClassObj2;

        // 設定初始值
        testClassObj2.Value1 = 1;
        testClassObj2.Value2 = 1;

        Console.WriteLine("呼叫方法前的狀態：");
        testClassObj1.Display();
        testClassObj2.Display();
        testClassObj2Ref.Display();

        // 呼叫測試方法
        PassRefTypeByValueAndRef(testClassObj1, ref testClassObj2Ref);

        Console.WriteLine("\n呼叫方法後的狀態：");
        testClassObj1.Display();
        testClassObj2.Display();
        testClassObj2Ref.Display();
    }
}