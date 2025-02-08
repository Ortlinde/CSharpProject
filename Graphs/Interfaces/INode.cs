namespace Graphs.Interfaces;

public interface INode<T>
{
    public T GetData();
    public List<INode<T>> GetNeighbors();
    public bool HasNeighbor(INode<T> neighbor);
    public void AddNeighbor(INode<T> neighbor);
    public void RemoveNeighbor(INode<T> neighbor);
}