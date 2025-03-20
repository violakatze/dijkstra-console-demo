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
        var startNodes = new[] { nodeA };
        var endNodes = new[] { nodeB };
        var edges = new[] { new Edge(nodeA, nodeB, 1), };

        var dijkstra = new Dijkstra(nodes, startNodes, endNodes, edges);

        Assert.Equal(nodes, dijkstra.Nodes);
        Assert.Equal(startNodes, dijkstra.StartNodes);
        Assert.Equal(endNodes, dijkstra.EndNodes);
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
        var startNodes = new[] { nodeA };
        var endNodes = new[] { nodeE };
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

        var dijkstra = new Dijkstra(nodes, startNodes, endNodes, edges);
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
        var startNodes = new[] { nodeA };
        var endNodes = new[] { nodeG };
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

        var dijkstra = new Dijkstra(nodes, startNodes, endNodes, edges);
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
        var startNodes = new[] { nodeA };
        var endNodes = new[] { nodeB };
        var edges = new[] { new Edge(nodeA, nodeB, 1), };

        var dijkstra = new Dijkstra(nodes, startNodes, endNodes, edges);
        var result = dijkstra.Solve();

        Assert.Equal(1, result.TotalCost);
        Assert.Equal("a-b", result.Route);
    }

    [Fact]
    public void 通常4_始点2終点1()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, };
        var starts = new[] { nodeA, nodeG };
        var ends = new[] { nodeC };
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
            new Edge(nodeE, nodeG, 6),
            new Edge(nodeF, nodeG, 9),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(10, result.TotalCost);
        Assert.Equal("g-f-c", result.Route);
    }

    [Fact]
    public void 通常5_始点1終点2()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, };
        var starts = new[] { nodeD };
        var ends = new[] { nodeB, nodeE };
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
            new Edge(nodeE, nodeG, 6),
            new Edge(nodeF, nodeG, 9),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(19, result.TotalCost);
        Assert.Equal("d-c-f-g-e", result.Route);
    }

    [Fact]
    public void 通常6_始点2終点2()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, };
        var starts = new[] { nodeA, nodeG };
        var ends = new[] { nodeC, nodeD };
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
            new Edge(nodeE, nodeG, 6),
            new Edge(nodeF, nodeG, 9),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(10, result.TotalCost);
        Assert.Equal("g-f-c", result.Route);
    }

    [Fact]
    public void エッジに紐づかないノードあり()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodes = new[] { nodeA, nodeB };
        var startNodes = new[] { nodeA };
        var endNodes = new[] { nodeB };
        var edges = new[] { new Edge(nodeA, nodeB, 1), };

        var dijkstra = new Dijkstra(nodes, startNodes, endNodes, edges);
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

        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra(nodes, [], [], edges));
        Assert.Equal("ノードがありません", exception.Message);
    }

    [Fact]
    public void 開始ノード無し()
    {
        var nodeA = new Node("a");
        var nodes = new[] { nodeA };
        var edges = Enumerable.Empty<Edge>();
        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra(nodes, [], [nodeA], edges));
        Assert.Equal("開始ノードがありません", exception.Message);
    }

    [Fact]
    public void 終了ノード無し()
    {
        var nodeA = new Node("a");
        var nodes = new[] { nodeA };
        var edges = Enumerable.Empty<Edge>();
        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra(nodes, [nodeA], [], edges));
        Assert.Equal("終了ノードがありません", exception.Message);
    }

    [Fact]
    public void 開始ノードがノードに含まれていない()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodes = new[] { nodeA };
        var edges = Enumerable.Empty<Edge>();
        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra(nodes, [nodeB], [nodeA], edges));
        Assert.Equal("開始ノードがノードに含まれていません", exception.Message);
    }

    [Fact]
    public void 終了ノードがノードに含まれていない()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodes = new[] { nodeA };
        var edges = Enumerable.Empty<Edge>();
        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra(nodes, [nodeA], [nodeB], edges));
        Assert.Equal("終了ノードがノードに含まれていません", exception.Message);
    }

    [Fact]
    public void エッジ無し()
    {
        var nodeA = new Node("a");
        var nodes = new[] { nodeA };
        var edges = Enumerable.Empty<Edge>();

        var dijkstra = new Dijkstra(nodes, [nodeA], [nodeA], edges);
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

        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra([nodeA, nodeB], [nodeA], [nodeB], [edge1, edge2]));
        Assert.Equal("同じ経路のエッジが複数あります:a-b", exception.Message);
    }

    [Fact]
    public void エッジ循環2()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var edge1 = new Edge(nodeB, nodeA, 1);
        var edge2 = new Edge(nodeA, nodeB, 2);

        var exception = Assert.Throws<ArgumentException>(() => _ = new Dijkstra([nodeA, nodeB], [nodeA], [nodeB], [edge1, edge2]));
        Assert.Equal("同じ経路のエッジが複数あります:b-a", exception.Message);
    }
}
