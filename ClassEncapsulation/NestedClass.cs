namespace CSharpProject.ClassEncapsulation;

file class OuterClass
{
    private int x = 10;
    public class NestedClass
    {
        OuterClass outerClass = new OuterClass();
        public void Print()
        {
            System.Console.WriteLine("NestedClass");
            System.Console.WriteLine(outerClass.x);
        }
    }


    public NestedClass nestedClass = new NestedClass();
    public void Print()
    {
        nestedClass.Print();
    }
}

file class OtherClass
{
    OuterClass.NestedClass nestedClass = new OuterClass.NestedClass();
    public void Print()
    {
        nestedClass.Print();
    }
}