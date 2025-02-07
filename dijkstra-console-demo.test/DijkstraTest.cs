using Assert = Xunit.Assert;

namespace dijkstra_console_demo;

/// <summary>
/// Dijkstraテスト
/// </summary>
public class DijkstraTest
{
    [Fact]
    public void 通常1()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, };
        var edges = new[]
        {
            new Edge(nodeA, nodeB, 7),
            new Edge(nodeA, nodeC, 4),
            new Edge(nodeA, nodeD, 3),
            new Edge(nodeB, nodeC, 1),
            new Edge(nodeB, nodeE, 2),
            new Edge(nodeC, nodeE, 6),
            new Edge(nodeD, nodeE, 5),
        };

        var dijkstra = new Dijkstra(nodes, edges);
        var result = dijkstra.Solve();

        Assert.Equal(7, result.TotalCost);
        Assert.Equal("a-c-b-e", result.Route);
    }

    [Fact]
    public void 通常2()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, };
        var edges = new[]
        {
            new Edge(nodeA, nodeB, 10),
            new Edge(nodeA, nodeC, 16),
            new Edge(nodeA, nodeD, 12),
            new Edge(nodeB, nodeC, 18),
            new Edge(nodeC, nodeD, 3),
            new Edge(nodeB, nodeE, 10),
            new Edge(nodeC, nodeF, 1),
            new Edge(nodeD, nodeF, 5),
            new Edge(nodeE, nodeG, 21),
            new Edge(nodeF, nodeG, 9),
        };

        var dijkstra = new Dijkstra(nodes, edges);
        var result = dijkstra.Solve();

        Assert.Equal(25, result.TotalCost);
        Assert.Equal("a-d-c-f-g", result.Route);
    }

    [Fact]
    public void エッジに紐づかないノードあり()
    {
        // TODO:
    }

    [Fact]
    public void ノード無し()
    {
        // TODO:
    }

    [Fact]
    public void エッジ無し()
    {
        // TODO:
    }

    [Fact]
    public void エッジの両端が同じノード()
    {
        // TODO:
    }

    [Fact]
    public void エッジ循環()
    {
        // TODO:
    }

    [Fact]
    public void エッジコストがマイナス()
    {
        // TODO:
    }
}
