public class LinkedList<T>
{
    // 巢狀類別：節點定義
    private class Node
    {
        public T Data { get; set; }
        public Node? Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    // 私有成員
    private Node? head;
    private int count;

    // 公開屬性
    public int Count => count;
    public bool IsEmpty => count == 0;

    // 建構函式
    public LinkedList()
    {
        head = null;
        count = 0;
    }

    // 新增節點到開頭
    public void AddFirst(T data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
        count++;
    }

    // 新增節點到結尾
    public void AddLast(T data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        count++;
    }

    // 移除第一個節點
    public bool RemoveFirst()
    {
        if (head == null) return false;

        head = head.Next;
        count--;
        return true;
    }

    // 搜尋元素
    public bool Contains(T data)
    {
        Node? current = head;
        while (current != null)
        {
            if (current.Data?.Equals(data) == true)
                return true;
            current = current.Next;
        }
        return false;
    }

    // 轉換為陣列
    public T[] ToArray()
    {
        T[] array = new T[count];
        Node? current = head;
        int index = 0;

        while (current != null)
        {
            array[index++] = current.Data;
            current = current.Next;
        }

        return array;
    }

    // 清空串列
    public void Clear()
    {
        head = null;
        count = 0;
    }
}