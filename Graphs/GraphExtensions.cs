namespace CSharpProject.Graphs;

public static class GraphExtensions
{
    public static void ValidateNodes<T>(this INode<T>? source, INode<T>? destination)
    {
        ArgumentNullException.ThrowIfNull(source, "起始節點不能為空");
        ArgumentNullException.ThrowIfNull(destination, "目標節點不能為空");
    }

    public static void ValidateNode<T>(this INode<T>? node, string paramName = "節點")
    {
        ArgumentNullException.ThrowIfNull(node, $"{paramName}不能為空");
    }
}