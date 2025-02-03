namespace CSharpProject.Graphs;

public class PathFinder<T> : IPathFinder<T>
{
    private readonly Dictionary<SearchStrategy, ISearchStrategy<T>> strategies;

    public PathFinder()
    {
        strategies = new Dictionary<SearchStrategy, ISearchStrategy<T>>
        {
            { SearchStrategy.DFS, new Strategies.DFSStrategy<T>() },
            { SearchStrategy.BFS, new Strategies.BFSStrategy<T>() }
        };
    }

    public bool HasPath(INode<T> source, INode<T> destination, SearchStrategy strategy = SearchStrategy.DFS)
    {
        source.ValidateNodes(destination);

        if (!strategies.TryGetValue(strategy, out var searchStrategy))
        {
            throw new ArgumentException("不支援的搜尋策略");
        }

        return searchStrategy.HasPath(source, destination);
    }
}
