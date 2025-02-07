using System.Collections;

namespace CSharpProject.ClassesInheritance;

file class MyList<T> : IEnumerable<T>
{
    private T[] _items;
    private int _count;
    private const int InitialCapacity = 4;

    public MyList()
    {
        _items = new T[InitialCapacity];
        _count = 0;
    }

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
        _items[_count++] = item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class ExplainIEnumerable
{
    public static void Test()
    {
        var myList = new MyList<int>
        {
            1,
            2,
            3,
            4,
            5
        };

        foreach (var item in myList)
        {
            System.Console.WriteLine(item);
        }
    }
}