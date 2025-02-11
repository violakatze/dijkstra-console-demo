namespace dijkstra_console_demo;

/// <summary>
/// Edgeテスト
/// </summary>
public class EdgeTest
{
    [Fact]
    public void 通常()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var edge = new Edge(nodeA, nodeB, 1);

        Assert.Equal(nodeA, edge.Nodes.ElementAt(0));
        Assert.Equal(nodeB, edge.Nodes.ElementAt(1));
        Assert.Equal(1, edge.Cost);
    }

    [Fact]
    public void エッジの両端が同じノード()
    {
        var nodeA = new Node("a");

        var exception = Assert.Throws<ArgumentException>(() => _ = new Edge(nodeA, nodeA, 1));
        Assert.Equal("同じノードが引数になっています", exception.Message);
    }

    [Fact]
    public void エッジコストが0()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var edge = new Edge(nodeA, nodeB, 0);

        Assert.Equal(0, edge.Cost);
    }

    [Fact]
    public void エッジコストがマイナス()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");

        var exception = Assert.Throws<ArgumentException>(() => _ = new Edge(nodeA, nodeB, -1));
        Assert.Equal("コストがマイナスになっています:-1", exception.Message);
    }
}
