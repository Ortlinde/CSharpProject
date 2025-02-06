// 1. 定義條件編譯符號
#define DEBUG_MODE
#define TRADITIONAL_CHINESE

// 5. 取消定義
#undef DEBUG_MODE

namespace CSharpProject.CoreCSharpProgramming;

public class PreprocessingDirectiveExample
{
    // 8. 禁用警告
#pragma warning disable CS1591
    // 這裡的缺少文件註解警告會被禁用
    public void UndocumentedMethod() { }
#pragma warning restore CS1591

    public void Test()
    {
        // 2. 條件編譯
#if DEBUG_MODE
        Console.WriteLine("除錯模式已啟用");
#else
        Console.WriteLine("正式發布模式");
#endif

        // 3. 多重條件
#if DEBUG_MODE && TRADITIONAL_CHINESE
        Console.WriteLine("除錯模式 + 繁體中文");
#elif DEBUG_MODE
        Console.WriteLine("僅除錯模式");
#else
        Console.WriteLine("其他模式");
#endif

        // 4. 可折疊區域
        #region 資料處理方法
#pragma warning disable CS8321
        void ProcessData()
        {
            Console.WriteLine("處理資料中...");
        }

        void ValidateData()
        {
            Console.WriteLine("驗證資料中...");
        }
#pragma warning restore CS8321
        #endregion

        // 6. 警告和錯誤
        // #warning 這是一個警告訊息
#if DEBUG_MODE
#error 這是一個錯誤訊息
#endif

        // 7. 行號控制
#line 200 "CustomFileName.cs"
        // Console.WriteLine($"目前行號：{nameof(CustomFileName)}.cs:200");
#line default
    }
}