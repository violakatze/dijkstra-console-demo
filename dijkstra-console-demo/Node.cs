namespace dijkstra_console_demo;

/// <summary>
/// ノード
/// </summary>
public class Node(string name)
{
    /// <summary>
    /// ノード名
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// 
    /// このノードのコスト
    /// </summary>
    public int Cost { get; private set; } = int.MaxValue;

    /// <summary>
    /// このノードまでの経路
    /// </summary>
    public Node[] Routes { get; private set; } = [];

    /// <summary>
    /// このノードまでのコスト(合計コスト)
    /// </summary>
    public int TotalCost { get; private set; } = int.MaxValue;

    /// <summary>
    /// 確定フラグ
    /// </summary>
    public bool Fixed { get; private set; } = false;

    /// <summary>
    /// このノードを開始ノードに設定する
    /// </summary>
    public void SetStartNode()
    {
        Cost = 0;
        TotalCost = 0;
        Routes = [this];
    }

    /// <summary>
    /// このノードを確定ノードにする
    /// </summary>
    public void Fix()
    {
        Fixed = true;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="preivousRoutes">ここまでの経路</param>
    /// <param name="edge">通ったエッジのコスト</param>
    public void Update(IEnumerable<Node> preivousRoutes, int edgeCost)
    {
        var newTotalCost = edgeCost + preivousRoutes.LastOrDefault()?.TotalCost ?? 0;

        if (newTotalCost < TotalCost)
        {
            // コスト更新
            Cost = edgeCost;
            TotalCost = newTotalCost;

            // ここまでの経路更新
            var list = new List<Node>(preivousRoutes) { this };
            Routes = [.. list];
        }
    }
}
