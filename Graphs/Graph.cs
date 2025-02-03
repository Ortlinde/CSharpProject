namespace CSharpProject.Graphs;

public class Graph<T>
{
    private List<INode<T>> nodes;
    private readonly IPathFinder<T> pathFinder;

    public Graph(IPathFinder<T>? pathFinder = null)
    {
        nodes = new List<INode<T>>();
        this.pathFinder = pathFinder ?? new PathFinder<T>();
    }

    public void AddNode(INode<T> node)
    {
        node.ValidateNode();
        nodes.Add(node);
    }

    public void AddEdge(INode<T> source, INode<T> destination)
    {
        source.ValidateNodes(destination);

        if (!source.HasNeighbor(destination))
        {
            source.AddNeighbor(destination);
        }
    }

    public void RemoveEdge(INode<T> source, INode<T> destination)
    {
        source.ValidateNodes(destination);
        source.RemoveNeighbor(destination);
    }

    public bool HasPath(INode<T> source, INode<T> destination, SearchStrategy strategy = SearchStrategy.DFS)
    {
        source.ValidateNodes(destination);
        return pathFinder.HasPath(source, destination, strategy);
    }
}