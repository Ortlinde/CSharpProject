namespace CSharpProject.CoreCSharpProgramming;

public class DecisionConstructs
{
    public void TestIfElse()
    {
        int count = 1;
        // C# 正確寫法
        if (count > 0)    // 布林表達式
        {
            // 程式碼
        }

        // C# 錯誤寫法
        // if (count)    // 在 C/C++ 可行，但在 C# 中不允許
        // {
        //     // 程式碼
        // }
    }

    public void TestSwitch()
    {
        string color = "red";
        switch (color)
        {
            case "red":
                Console.WriteLine("紅色");
                break;
            case "blue":
                Console.WriteLine("藍色");
                break;
            default:
                Console.WriteLine("其他顏色");
                break;
        }
    }

    public void TestSwitchWithBreak()
    {
        int number = 1;
        switch (number)
        {
            case 0: // 空的 case，會穿透到下一個 case 
            case 1:
                Console.WriteLine("一");
                break;  // 必須有 break
            case 2:
                Console.WriteLine("二");
                break;  // 不能省略
            default:
                Console.WriteLine("其他數字");
                break;
        }
    }
}
