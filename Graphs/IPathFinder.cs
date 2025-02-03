namespace CSharpProject.Graphs;

public interface IPathFinder<T>
{
    bool HasPath(INode<T> source, INode<T> destination, SearchStrategy strategy = SearchStrategy.DFS);
}