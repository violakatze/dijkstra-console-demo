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
    /// このノードのコスト
    /// </summary>
    public int Cost { get; private set; } = int.MaxValue;

    /// <summary>
    /// 直前のノード
    /// </summary>
    public Node? Previous { get; private set; } = default;

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
        Previous = default;
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
    /// <param name="preivousRoutes">直前のノード</param>
    /// <param name="edge">通ったエッジのコスト</param>
    public void Update(Node preivous, int edgeCost)
    {
        var newTotalCost = edgeCost + preivous.TotalCost;

        if (newTotalCost < TotalCost)
        {
            // コスト更新
            Cost = edgeCost;
            TotalCost = newTotalCost;

            // 直前のノード更新
            Previous = preivous;
        }
    }
}
