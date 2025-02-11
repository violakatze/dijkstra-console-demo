namespace dijkstra_console_demo;

/// <summary>
/// Nodeテスト
/// </summary>
public class NodeTest
{
    [Fact]
    public void 通常1()
    {
        var nodeA = new Node("a");

        Assert.Equal("a", nodeA.Name);
        Assert.Equal(int.MaxValue, nodeA.Cost);
        Assert.Equal(int.MaxValue, nodeA.TotalCost);
        Assert.Empty(nodeA.Routes);
        Assert.False(nodeA.Fixed);
    }

    [Fact]
    public void 通常2()
    {
        var nodeA = new Node("");

        Assert.Empty(nodeA.Name);
        Assert.Equal(int.MaxValue, nodeA.Cost);
        Assert.Equal(int.MaxValue, nodeA.TotalCost);
        Assert.Empty(nodeA.Routes);
        Assert.False(nodeA.Fixed);
    }

    [Fact]
    public void 開始ノード()
    {
        var nodeA = new Node("a");
        nodeA.SetStartNode();

        Assert.Equal("a", nodeA.Name);
        Assert.Equal(0, nodeA.Cost);
        Assert.Equal(0, nodeA.TotalCost);
        Assert.Equal([nodeA], nodeA.Routes);
        Assert.False(nodeA.Fixed);
    }

    [Fact]
    public void 確定()
    {
        var nodeA = new Node("a");
        nodeA.Fix();

        Assert.True(nodeA.Fixed);
    }

    [Fact]
    public void 更新1_通常()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");

        nodeA.SetStartNode();
        nodeA.Fix();
        nodeB.Update(nodeA.Routes, 1);

        Assert.Equal("b", nodeB.Name);
        Assert.Equal(1, nodeB.Cost);
        Assert.Equal(1, nodeB.TotalCost);
        Assert.Equal([nodeA, nodeB], nodeB.Routes);
        Assert.False(nodeB.Fixed);
    }

    [Fact]
    public void 更新2_通常()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");

        nodeA.SetStartNode();
        nodeA.Fix();
        nodeB.Update(nodeA.Routes, 1);
        nodeB.Fix();
        nodeC.Update(nodeB.Routes, 2);

        Assert.Equal("c", nodeC.Name);
        Assert.Equal(2, nodeC.Cost);
        Assert.Equal(3, nodeC.TotalCost);
        Assert.Equal([nodeA, nodeB, nodeC], nodeC.Routes);
        Assert.False(nodeC.Fixed);
    }

    [Fact]
    public void 更新3_通常上書き()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");

        nodeA.SetStartNode();
        nodeA.Fix();
        nodeB.Update(nodeA.Routes, 1);
        nodeC.Update(nodeA.Routes, 3);
        nodeB.Fix();
        nodeC.Update(nodeB.Routes, 1);

        Assert.Equal("c", nodeC.Name);
        Assert.Equal(1, nodeC.Cost);
        Assert.Equal(2, nodeC.TotalCost);
        Assert.Equal([nodeA, nodeB, nodeC], nodeC.Routes);
        Assert.False(nodeC.Fixed);
    }

    [Fact]
    public void 更新4_コスト高で非更新()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");

        nodeA.SetStartNode();
        nodeA.Fix();
        nodeB.Update(nodeA.Routes, 1);
        nodeC.Update(nodeA.Routes, 3);
        nodeB.Fix();
        nodeC.Update(nodeB.Routes, 3);

        Assert.Equal("c", nodeC.Name);
        Assert.Equal(3, nodeC.Cost);
        Assert.Equal(3, nodeC.TotalCost);
        Assert.Equal([nodeA, nodeC], nodeC.Routes);
        Assert.False(nodeC.Fixed);
    }

    [Fact]
    public void 更新4_コスト同じで先勝ち()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");

        nodeA.SetStartNode();
        nodeA.Fix();
        nodeB.Update(nodeA.Routes, 1);
        nodeC.Update(nodeA.Routes, 3);
        nodeB.Fix();
        nodeC.Update(nodeB.Routes, 2);

        Assert.Equal("c", nodeC.Name);
        Assert.Equal(3, nodeC.Cost);
        Assert.Equal(3, nodeC.TotalCost);
        Assert.Equal([nodeA, nodeC], nodeC.Routes);
        Assert.False(nodeC.Fixed);
    }
}
