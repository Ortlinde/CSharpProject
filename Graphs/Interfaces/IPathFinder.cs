using Graphs.Enums;

namespace Graphs.Interfaces;

public interface IPathFinder<T>
{
    bool HasPath(INode<T> source, INode<T> destination, SearchStrategy strategy = SearchStrategy.DFS);
}