﻿namespace dijkstra_console_demo;

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
    /// 開始ノード
    /// </summary>
    public IEnumerable<Node> StartNodes { get; }

    /// <summary>
    /// 終了ノード
    /// </summary>
    public IEnumerable<Node> EndNodes { get; }

    /// <summary>
    /// 全エッジ
    /// </summary>
    public IEnumerable<Edge> Edges { get; }

    /// <summary>
    /// ダイクストラ(オーソドックスなアルゴリズム)
    /// </summary>
    /// <param name="nodes">ノード</param>
    /// <param name="startNodes">開始ノード</param>
    /// <param name="endNodes">終了ノード</param>
    /// <param name="edges">エッジ</param>
    public Dijkstra(IEnumerable<Node> nodes, IEnumerable<Node> startNodes, IEnumerable<Node> endNodes, IEnumerable<Edge> edges)
    {
        if (!nodes.Any())
        {
            throw new ArgumentException("ノードがありません");
        }

        if (!startNodes.Any())
        {
            throw new ArgumentException("開始ノードがありません");
        }

        if (!endNodes.Any())
        {
            throw new ArgumentException("終了ノードがありません");
        }

        // 開始ノードがノードに含まれているかチェック
        if (startNodes.Any(n => !nodes.Contains(n)))
        {
            throw new ArgumentException("開始ノードがノードに含まれていません");
        }

        // 終了ノードがノードに含まれているかチェック
        if (endNodes.Any(n => !nodes.Contains(n)))
        {
            throw new ArgumentException("終了ノードがノードに含まれていません");
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
        StartNodes = startNodes;
        EndNodes = endNodes;
        Edges = edges;
    }
    /// <summary>
    /// 計算実行
    /// </summary>
    public DijkstraResult Solve()
    {
        foreach (var start in StartNodes)
        {
            start.SetStartNode();
        }

        while (true)
        {
            // 終了ノードのいずれかが確定していたら終了
            if (EndNodes.FirstOrDefault(n => n.Fixed) is { } goal)
            {
                return new DijkstraResult(goal);
            }

            // 未確定が無ければエラー(以上系)
            var notFixeds = Nodes.Where(n => !n.Fixed).ToArray();
            if (notFixeds.Length == 0)
            {
                throw new InvalidOperationException("未確定のノードがありません");
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
                    next.Update(previous, edge.Cost);
                }
            }
        }
    }
}

/// <summary>
/// ダイクストラ計算結果
/// </summary>
/// <param name="routes">ゴールノード</param>
public class DijkstraResult(Node goal)
{
    /// <summary>
    /// 合計コスト
    /// </summary>
    public int TotalCost => goal.TotalCost;

    /// <summary>
    /// 最短経路
    /// </summary>
    public string Route => RecursiveGenerateRoute(goal);

    /// <summary>
    /// 最短経路文字列作成
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private static string RecursiveGenerateRoute(Node node)
    {
        if (node.Previous == default)
        {
            return node.Name;
        }
        else
        {
            return $"{RecursiveGenerateRoute(node.Previous)}-{node.Name}";
        }
    }
}
