// See https://aka.ms/new-console-template for more information

using dijkstra_console_demo;

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

Console.WriteLine($"TotalCost: {result.TotalCost}");
Console.WriteLine($"ShortestRoute: {result.Route}");
