namespace CSharpProject.CoreCSharpProgramming;

public class ParameterModifier
{
    public void Test()
    {
        int number = 1;
        TestRef(ref number);
        Console.WriteLine(number);

        int number2;
        TestOut(out number2);
        Console.WriteLine(number2);
    }

    public void TestRef(ref int number)
    {
        number = 10;
    }

    public void TestOut(out int number)
    {
        // number++;
        number = 10;
    }
}