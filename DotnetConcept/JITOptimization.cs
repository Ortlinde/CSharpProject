namespace CSharpProject.DotnetConcept;

public class JITOptimization
{
    #region 內聯優化 (Inlining)
    // 優化前
    private int Add(int a, int b) => a + b;
    public int BeforeInlining() => Add(5, 3);

    // 優化後等效於
    public int AfterInlining() => 5 + 3;
    #endregion

    #region 常數折疊 (Constant Folding)
    // 優化前
    public int BeforeConstantFolding()
    {
        int result = 60 * 60 * 24;
        return result;
    }

    // 優化後
    public int AfterConstantFolding()
    {
        int result = 86400;
        return result;
    }
    #endregion

    #region 循環優化 (Loop Optimization)
    // 優化前 - 循環展開
    public void BeforeLoopUnrolling(int[] array)
    {
        for (int i = 0; i < 4; i++)
        {
            array[i]++;
        }
    }

    // 優化後 - 循環展開
    public void AfterLoopUnrolling(int[] array)
    {
        array[0]++;
        array[1]++;
        array[2]++;
        array[3]++;
    }

    // 優化前 - 循環不變量
    public void BeforeLoopInvariant(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var len = array.Length;
            array[i] = array[i] * len;
        }
    }

    // 優化後 - 循環不變量
    public void AfterLoopInvariant(int[] array)
    {
        var len = array.Length;
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = array[i] * len;
        }
    }
    #endregion

    #region 空值檢查消除 (Null Check Elimination)
    public void ProcessText(string text)
    {
        // 優化前的 IL 代碼會包含兩次 null 檢查
        if (text != null)
        {
            Console.WriteLine(text);      // IL 會產生 null 檢查
            Console.WriteLine(text.Length); // IL 會產生另一個 null 檢查
        }
    }

    // JIT 優化後，第二次存取 text 時會移除 null 檢查
    // 因為 JIT 能夠追蹤到 text 在第一次檢查後必定不為 null
    #endregion

    #region 公共子表達式消除 (Common Subexpression Elimination)
    // 優化前
    public void BeforeCSE(int x, int y, int z, int w)
    {
        var a = x * y + z;
        var b = x * y + w;
    }

    // 優化後
    public void AfterCSE(int x, int y, int z, int w)
    {
        var temp = x * y;
        var a = temp + z;
        var b = temp + w;
    }
    #endregion

    #region 死碼消除 (Dead Code Elimination)
    // 優化前
    public int BeforeDeadCode()
    {
        var unused = Calculate();
        int result = 42;
        return result;

        int Calculate() => 100;
    }

    // 優化後
    public int AfterDeadCode()
    {
        return 42;
    }
    #endregion

    #region SIMD 向量化 (Vectorization)
    // 優化前
    public void BeforeVectorization(float[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] *= 2.0f;
        }
    }

    // 優化後 (概念示意，實際由 JIT 實現)
    public void AfterVectorization(float[] array)
    {
        // 使用 SIMD 指令同時處理多個元素
        int i = 0;
        for (; i <= array.Length - 4; i += 4)
        {
            // 同時處理 4 個元素
            array[i] *= 2.0f;
            array[i + 1] *= 2.0f;
            array[i + 2] *= 2.0f;
            array[i + 3] *= 2.0f;
        }
        // 處理剩餘元素
        for (; i < array.Length; i++)
        {
            array[i] *= 2.0f;
        }
    }
    #endregion

    #region 尾調用優化 (Tail Call Optimization)
    // 優化前
    public long BeforeFactorial(long n, long acc = 1)
    {
        if (n <= 1) return acc;
        return BeforeFactorial(n - 1, n * acc);
    }

    // 優化後 (概念示意，實際由 JIT 實現)
    public long AfterFactorial(long n, long acc = 1)
    {
        while (n > 1)
        {
            acc = n * acc;
            n = n - 1;
        }
        return acc;
    }
    #endregion

    #region 其他雜項
    public int FibonacciRecursive(int value)
    {
        if (value == 0)
            return 0;
        else if (value == 1)
            return 1;
        else
            return FibonacciRecursive(value - 1) + FibonacciRecursive(value - 2);
    }

    public int FibonacciIterative(int value)
    {
        int a = 0, b = 1;
        for (int i = 0; i < value; i++)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return a;
    }

    public int FibonacciIterativeTuple(int value)
    {
        (int a, int b) = (0, 1);
        for (int i = 0; i < value; i++)
        {
            (a, b) = (b, a + b);
        }
        return a;
    }
    #endregion
}