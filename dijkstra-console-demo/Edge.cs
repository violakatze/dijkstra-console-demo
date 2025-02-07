namespace dijkstra_console_demo;

/// <summary>
/// エッジ(線)
/// </summary>
public class Edge
{
    /// <summary>
    /// 両端のノード(順不同)
    /// </summary>
    public IEnumerable<Node> Nodes { get; }

    /// <summary>
    /// このエッジのコスト
    /// </summary>
    public int Cost { get; }

    /// <summary>
    /// エッジ(線)
    /// </summary>
    /// <param name="node1">ノード(両端のうちの一つ)</param>
    /// <param name="node2">ノード(両端のうちの一つ)</param>
    /// <param name="cost">エッジのコスト</param>
    public Edge(Node node1, Node node2, int cost)
    {
        if (node1 == node2)
        {
            throw new ArgumentException("同じノードが引数になっています");
        }

        if (cost < 0)
        {
            throw new ArgumentException($"コストがマイナスになっています:{cost}");
        }

        Nodes = [node1, node2];
        Cost = cost;
    }
}
