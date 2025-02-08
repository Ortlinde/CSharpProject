namespace CSharpProject.StructuredExceptionHandling;

public class FinallyExample
{
    public static void Test()
    {
        string connectionString = "ConnectionString";
        SqlConnection? conn = null;
        try
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            // 資料庫操作...
            DoWork(); // 可能拋出 SqlException
        }
        catch (SqlException ex)

        {
            Console.WriteLine($"資料庫錯誤：{ex.Message}");
            throw;
        }
        finally
        {
            conn?.Close();
        }
    }

    private static void DoWork()
    {
        Console.WriteLine("執行工作");
    }

    public void ProcessData()
    {
        string connectionString = "ConnectionString";
        SqlConnection? conn = null;
        SqlTransaction? trans = null;

        try
        {
            conn = new SqlConnection(connectionString);
            conn.Open();

            trans = conn.BeginTransaction();

            // 資料庫操作...

            trans.Commit();
        }
        catch (Exception)
        {
            trans?.Rollback();
            throw;
        }
        finally
        {
            trans?.Dispose();
            conn?.Dispose();
        }
    }

    public void ProcessDataUsing()
    {
        string connectionString = "ConnectionString";
        using SqlConnection? conn = new SqlConnection(connectionString);

        conn.Open();

        using SqlTransaction? trans = conn.BeginTransaction();

        try
        {
            // 資料庫操作...
            trans.Commit();
        }
        catch (Exception)
        {
            trans?.Rollback();
            throw;
        }
    } // 使用 using 可以確保資源在離開作用域時被釋放
}


file class SqlException : Exception
{
    public SqlException(string message) : base(message)
    {
    }
}

file class SqlConnection : IDisposable
{
    string connectionString;


    public SqlConnection(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Open()
    {
        Console.WriteLine("開啟資料庫");
        if (connectionString == null)
        {
            throw new SqlException("ConnectionString is null");
        }
    }

    public void Close()
    {
        Console.WriteLine("釋放資源");
    }

    public SqlTransaction BeginTransaction()
    {
        return new SqlTransaction();
    }

    public void Dispose()
    {
        Console.WriteLine("釋放資源");
    }
}

file class SqlTransaction : IDisposable

{
    public void Commit()
    {
        Console.WriteLine("提交交易");
    }

    public void Rollback()
    {
        Console.WriteLine("回滾交易");
    }

    public void Dispose()
    {
        Console.WriteLine("釋放資源");
    }
}