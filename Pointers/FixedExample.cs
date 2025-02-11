namespace CSharpProject.Pointers;

public class FixedExample
{
    public static unsafe void Test()
    {
        // 創建一個簡單的字節陣列
        byte[] bytes = [1, 2, 3, 4, 5];

        // 使用 fixed 來固定陣列在內存中的位置
        fixed (byte* p = bytes)
        {
            // 使用指標訪問陣列元素
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.WriteLine($"bytes[{i}] = {p[i]}");
            }
        }
    }
}