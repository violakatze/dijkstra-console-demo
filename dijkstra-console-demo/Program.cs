// See https://aka.ms/new-console-template for more information

using dijkstra_console_demo;

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

Console.WriteLine($"TotalCost: {result.TotalCost}");
Console.WriteLine($"ShortestRoute: {result.Route}");
