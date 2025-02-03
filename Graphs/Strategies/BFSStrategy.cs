namespace CSharpProject.Graphs.Strategies;

public class BFSStrategy<T> : ISearchStrategy<T>
{
    private readonly HashSet<INode<T>> _visited;
    private readonly Queue<INode<T>> _queue;

    public BFSStrategy()
    {
        _visited = new HashSet<INode<T>>();
        _queue = new Queue<INode<T>>();
    }

    public bool HasPath(INode<T> source, INode<T> destination)
    {
        source.ValidateNodes(destination);

        _visited.Clear();
        _queue.Clear();

        InitializeSearch(source);
        return SearchPath(destination);
    }

    private void InitializeSearch(INode<T> source)
    {
        _visited.Add(source);
        _queue.Enqueue(source);
    }

    private bool SearchPath(INode<T> destination)
    {
        while (HasNotVisitedNodes())
        {
            var current = _queue.Dequeue();
            if (IsDestination(current, destination)) return true;

            AddUnvisitedNeighbors(current);
        }
        return false;
    }

    private bool HasNotVisitedNodes()
    {
        return _queue.Count > 0;
    }

    private bool IsDestination(INode<T> current, INode<T> destination)
    {
        return current.Equals(destination);
    }

    private bool IsVisited(INode<T> node)
    {
        return _visited.Contains(node);
    }

    private void AddUnvisitedNeighbors(INode<T> node)
    {
        foreach (var neighbor in node.GetNeighbors())
        {
            AddUnvisitedNeighbor(neighbor);
        }
    }

    private void AddUnvisitedNeighbor(INode<T> neighbor)
    {
        if (IsVisited(neighbor)) return;

        _visited.Add(neighbor);
        _queue.Enqueue(neighbor);
    }
}