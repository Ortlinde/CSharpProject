namespace CSharpProject.CoreCSharpProgramming;

public class ArrayExample
{
    // 使用 [,] 宣告
    int[,] rectArray = new int[5, 6];   // 5行6列的二維陣列
    // 每一行的長度都相同

    public void TestRectArray()
    {
        // 訪問方式：rectArray[2,3]
        rectArray[2, 3] = 10;
    }

    // 使用 [][] 宣告
    int[][] jaggedArray = new int[5][];    // 5個內部陣列
    // 每個內部陣列可以有不同長度

    public void TestJaggedArray()
    {
        jaggedArray[0] = new int[3];    // 第一行有3個元素
        jaggedArray[1] = new int[4];    // 第二行有4個元素
                                        // 訪問方式：jaggedArray[2][3]
    }
}