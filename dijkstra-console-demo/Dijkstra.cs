namespace dijkstra_console_demo;

/// <summary>
/// ダイクストラ(オーソドックスなアルゴリズム)
/// </summary>
public class Dijkstra
{
    /// <summary>
    /// 全ノード
    /// </summary>
    public IEnumerable<Node> Nodes { get; }

    /// <summary>
    /// 全エッジ
    /// </summary>
    public IEnumerable<Edge> Edges { get; }

    /// <summary>
    /// ダイクストラ(オーソドックスなアルゴリズム)
    /// </summary>
    /// <param name="nodes">ノード(配列の最初がスタート, 最後がゴールになる)</param>
    /// <param name="edges">エッジ</param>
    public Dijkstra(IEnumerable<Node> nodes, IEnumerable<Edge> edges)
    {
        if (!nodes.Any())
        {
            throw new ArgumentException("ノードがありません");
        }

        // 循環(同一経路に複数エッジ)チェック
        foreach (var edge in edges)
        {
            var node1 = edge.Nodes.ElementAt(0);
            var node2 = edge.Nodes.ElementAt(1);
            var others = edges.Except([edge]).ToArray();
            if (others.Any(x => x.Nodes.Any(n => n == node1) && x.Nodes.Any(n => n == node2)))
            {
                throw new ArgumentException($"同じ経路のエッジが複数あります:{node1.Name}-{node2.Name}");
            }
        }

        Nodes = nodes;
        Edges = edges;
    }
    /// <summary>
    /// 計算実行
    /// </summary>
    public DijkstraResult Solve()
    {
        var start = Nodes.First();
        var goal = Nodes.Last();

        start.SetStartNode();

        while (true)
        {
            // 未確定が無ければ終わり
            var notFixeds = Nodes.Where(n => !n.Fixed).ToArray();
            if (notFixeds.Length == 0)
            {
                break;
            }

            // 合計コスト最小のノードを確定する
            var current = notFixeds.First(n => n.TotalCost == notFixeds.Select(n2 => n2.TotalCost).Min());
            current.Fix();

            // 確定ノードに隣接する未確定ノードを更新
            foreach (var edge in Edges)
            {
                if (edge.Nodes.FirstOrDefault(n => n.Fixed) is { } previous && edge.Nodes.FirstOrDefault(n => !n.Fixed) is { } next)
                {
                    // 確定と未確定があったら未確定側を更新
                    next.Update(previous.Routes, edge.Cost);
                }
            }
        }

        return new DijkstraResult(goal.Routes);
    }
}

/// <summary>
/// ダイクストラ計算結果
/// </summary>
/// <param name="routes">ゴールノードまでの経路</param>
public class DijkstraResult(IEnumerable<Node> routes)
{
    /// <summary>
    /// 合計コスト
    /// </summary>
    public int TotalCost => routes.LastOrDefault()?.TotalCost ?? 0;

    /// <summary>
    /// 最短経路
    /// </summary>
    public string Route => string.Join("-", routes.Select(x => x.Name));
}
