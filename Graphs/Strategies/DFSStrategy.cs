namespace CSharpProject.Graphs.Strategies;

public class DFSStrategy<T> : ISearchStrategy<T>
{
    private readonly HashSet<INode<T>> _visited;
    private readonly Stack<INode<T>> _stack;

    public DFSStrategy()
    {
        _visited = new HashSet<INode<T>>();
        _stack = new Stack<INode<T>>();
    }

    public bool HasPath(INode<T> source, INode<T> destination)
    {
        ArgumentNullException.ThrowIfNull(source, "起始節點不能為空");
        ArgumentNullException.ThrowIfNull(destination, "目標節點不能為空");

        _visited.Clear();
        _stack.Clear();

        InitializeSearch(source);
        return SearchPath(destination);
    }

    private void InitializeSearch(INode<T> source)
    {
        _stack.Push(source);
    }

    private bool SearchPath(INode<T> destination)
    {
        while (HasNotVisitedNodes())
        {
            var current = _stack.Pop();
            if (IsDestination(current, destination)) return true;
            if (!TryVisitNode(current)) continue;

            AddUnvisitedNeighbors(current);
        }
        return false;
    }

    private bool HasNotVisitedNodes()
    {
        return _stack.Count > 0;
    }

    private bool IsDestination(INode<T> current, INode<T> destination)
    {
        return current.Equals(destination);
    }

    private bool TryVisitNode(INode<T> node)
    {
        if (IsVisited(node)) return false;
        _visited.Add(node);
        return true;
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
        _stack.Push(neighbor);
    }
}