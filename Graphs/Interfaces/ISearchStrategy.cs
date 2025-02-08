namespace Graphs.Interfaces;

public interface ISearchStrategy<T>
{
    bool HasPath(INode<T> source, INode<T> destination);
}