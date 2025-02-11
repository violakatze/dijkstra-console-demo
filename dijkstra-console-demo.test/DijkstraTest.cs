using Assert = Xunit.Assert;

namespace dijkstra_console_demo;

/// <summary>
/// Dijkstraテスト
/// </summary>
public class DijkstraTest
{
    [Fact]
    public void 初期状態()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodes = new[] { nodeA, nodeB };
        var edges = new[] { new Edge(nodeA, nodeB, 1), };

        var dijkstra = new Dijkstra(nodes, edges);

        Assert.Equal(nodes, dijkstra.Nodes);
        Assert.Equal(edges, dijkstra.Edges);
    }

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
    public void 通常3()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodes = new[] { nodeA, nodeB };
        var edges = new[] { new Edge(nodeA, nodeB, 1), };

        var dijkstra = new Dijkstra(nodes, edges);
        var result = dijkstra.Solve();

        Assert.Equal(1, result.TotalCost);
        Assert.Equal("a-b", result.Route);
    }

    [Fact]
    public void エッジに紐づかないノードあり()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodes = new[] { nodeA, nodeB };
        var edges = new[] { new Edge(nodeA, nodeB, 1), };

        var dijkstra = new Dijkstra(nodes, edges);
        var result = dijkstra.Solve();

        Assert.Equal(1, result.TotalCost);
        Assert.Equal("a-b", result.Route);
        Assert.Equal("c", nodeC.Name);
    }

    [Fact]
    public void ノード無し()
    {
        var nodes = Enumerable.Empty<Node>();
        var edges = Enumerable.Empty<Edge>();

        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra(nodes, edges));
        Assert.Equal("ノードがありません", exception.Message);
    }

    [Fact]
    public void エッジ無し()
    {
        var nodeA = new Node("a");
        var nodes = new[] { nodeA };
        var edges = Enumerable.Empty<Edge>();

        var dijkstra = new Dijkstra(nodes, edges);
        var result = dijkstra.Solve();

        Assert.Equal(0, result.TotalCost);
        Assert.Equal("a", result.Route);
    }

    [Fact]
    public void エッジ循環1()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var edge1 = new Edge(nodeA, nodeB, 1);
        var edge2 = new Edge(nodeA, nodeB, 2);

        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra([nodeA, nodeB], [edge1, edge2]));
        Assert.Equal("同じ経路のエッジが複数あります:a-b", exception.Message);
    }

    [Fact]
    public void エッジ循環2()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var edge1 = new Edge(nodeB, nodeA, 1);
        var edge2 = new Edge(nodeA, nodeB, 2);

        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra([nodeA, nodeB], [edge1, edge2]));
        Assert.Equal("同じ経路のエッジが複数あります:b-a", exception.Message);
    }
}
