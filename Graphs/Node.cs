namespace CSharpProject.Graphs;

public class Node<T> : INode<T>
{
    private readonly T data;
    private readonly List<INode<T>> neighbors;

    public Node(T data)
    {
        ArgumentNullException.ThrowIfNull(data, "資料不能為空");
        this.data = data;
        this.neighbors = new List<INode<T>>();
    }

    public T GetData()
    {
        return data;
    }

    public List<INode<T>> GetNeighbors()
    {
        return neighbors;
    }

    public bool HasNeighbor(INode<T> neighbor)
    {
        ArgumentNullException.ThrowIfNull(neighbor, "鄰居不能為空");
        return neighbors.Contains(neighbor);
    }

    public void AddNeighbor(INode<T> neighbor)
    {
        ArgumentNullException.ThrowIfNull(neighbor, "鄰居不能為空");
        if (!HasNeighbor(neighbor))
        {
            neighbors.Add(neighbor);
            neighbor.AddNeighbor(this);
        }
    }

    public void RemoveNeighbor(INode<T> neighbor)
    {
        if (HasNeighbor(neighbor))
        {
            neighbors.Remove(neighbor);
            neighbor.RemoveNeighbor(this);
        }
    }
}