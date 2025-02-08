using System.Runtime.CompilerServices;

namespace CSharpProject.OperatorOverloading;

file class Vector2 : IComparable<Vector2>

{
    public float X { get; private set; }
    public float Y { get; private set; }

    public float MagnitudeSquare => X * X + Y * Y;
    public float Magnitude
    {
        get
        {
            if (_isModified)
            {
                _magnitude = MathF.Sqrt(MagnitudeSquare);
                _isModified = false;
            }
            return _magnitude;
        }
    }
    public bool IsZero => X == 0 && Y == 0;

    public static Vector2 Zero => new(0, 0);
    public static Vector2 One => new(1, 1);
    public static Vector2 UnitX => new(1, 0);
    public static Vector2 UnitY => new(0, 1);

    private bool _isModified = false;
    private float _magnitude = 0;

    #region 建構子
    public Vector2(float x = 0, float y = 0)


    {
        SetVector(x, y);
    }

    public Vector2(Vector2 vector)
    {
        SetVector(vector.X, vector.Y);
    }
    #endregion

    #region 單元運算子
    public static Vector2 operator -(Vector2 a)
    {
        return new Vector2 { X = -a.X, Y = -a.Y };
    }
    #endregion

    #region 布林運算子
    [Obsolete("示範用，不建議使用")]
    public static bool operator true(Vector2 a)
    {
        return !a.IsZero;
    }

    [Obsolete("示範用，不建議使用")]
    public static bool operator false(Vector2 a)
    {
        return a.IsZero;
    }

    [Obsolete("示範用，不建議使用")]
    public static bool operator !(Vector2 a)
    {
        return a.IsZero;
    }
    #endregion

    #region 算術運算子
    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return Add(a, b);
    }

    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return Subtract(a, b);
    }

    public static Vector2 operator *(Vector2 a, float scalar)
    {
        return Multiply(a, scalar);
    }

    public static Vector2 operator *(float scalar, Vector2 a)
    {
        return Multiply(a, scalar);
    }

    public static Vector2 operator /(Vector2 a, float scalar)
    {
        return Divide(a, scalar);
    }
    #endregion


    #region 比較運算子
    public static bool operator ==(Vector2 a, Vector2 b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return !a.Equals(b);
    }

    public static bool operator <(Vector2 a, Vector2 b)
    {
        return a.CompareTo(b) < 0;
    }

    public static bool operator >(Vector2 a, Vector2 b)
    {
        return a.CompareTo(b) > 0;
    }

    public static bool operator <=(Vector2 a, Vector2 b)
    {
        return !(a > b);
    }

    public static bool operator >=(Vector2 a, Vector2 b)
    {
        return !(a < b);
    }
    #endregion

    #region 靜態方法
    public static Vector2 Min(Vector2 a, Vector2 b)
    {
        return a < b ? a : b;
    }

    public static Vector2 Max(Vector2 a, Vector2 b)
    {
        return a > b ? a : b;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Add(Vector2 a, Vector2 b)
    {
        return new Vector2 { X = a.X + b.X, Y = a.Y + b.Y };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Subtract(Vector2 a, Vector2 b)
    {
        return Add(a, -b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Multiply(Vector2 a, float scalar)
    {
        return new Vector2 { X = a.X * scalar, Y = a.Y * scalar };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Multiply(float scalar, Vector2 a)
    {
        return Multiply(a, scalar);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Divide(Vector2 a, float scalar)
    {
        return Multiply(a, 1 / scalar);
    }
    #endregion


    #region 一般方法


    public void SetVector(float x, float y)
    {
        X = x;
        Y = y;

        _isModified = true;
    }

    public Vector2 Normalize()
    {
        if (IsZero)
            return Zero;

        return this / Magnitude;
    }

    public float Dot(Vector2 vector)
    {
        return X * vector.X + Y * vector.Y;
    }
    #endregion

    #region 覆寫 ToString 、 Equals 、 GetHashCode
    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is Vector2 vector)
        {
            return X == vector.X && Y == vector.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
    #endregion

    #region 實作 IComparable<Vector2>
    public int CompareTo(Vector2? other)
    {
        if (other is null)
            return -1;

        return MagnitudeSquare.CompareTo(other.MagnitudeSquare);
    }
    #endregion

}


public class OverloadOperatorsExample

{
    /*
    public static void Test()
    {
        if (Vector2.One) // 等同於 if (v.Magnitude != 0)
        {
            Console.WriteLine("這是非零向量");
        }

        if (!Vector2.Zero) // 等同於 if (zero.Magnitude == 0)
        {
            Console.WriteLine("這是零向量");
        }
    }
    */

    public static void Test2()
    {
        Vector2 a = new(1, 2);
        Vector2 b = new(3, 4);

        Console.WriteLine(a);
        Console.WriteLine(b);

        Console.WriteLine("--------------------------------");

        Console.WriteLine(-a);
        Console.WriteLine(-b);

        Console.WriteLine("--------------------------------");

        Console.WriteLine(a + b);
        Console.WriteLine(a - b);
        Console.WriteLine(a * 2);
        Console.WriteLine(2 * a);
        Console.WriteLine(a / 2);

        Console.WriteLine("--------------------------------");

        Console.WriteLine(a == b);
        Console.WriteLine(a != b);
        Console.WriteLine(a < b);
        Console.WriteLine(a > b);
        Console.WriteLine(a <= b);
        Console.WriteLine(a >= b);
    }


    public static void Test3()
    {
        Vector2[] vectors = [
            new(7, 8),
            new(3, 4),
            new(5, 6),
            new(1, 2)
        ];

        Array.Sort(vectors);

        foreach (var vector in vectors)
        {
            Console.WriteLine(vector);
        }

    }
}