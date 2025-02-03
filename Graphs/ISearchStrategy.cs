namespace CSharpProject.Graphs;

public interface ISearchStrategy<T>
{
    bool HasPath(INode<T> source, INode<T> destination);
}