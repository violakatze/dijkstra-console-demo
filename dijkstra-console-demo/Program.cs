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
var edge1 = new Edge(nodeA, nodeB, 10);
var edge2 = new Edge(nodeA, nodeC, 16);
var edge3 = new Edge(nodeA, nodeD, 12);
var edge4 = new Edge(nodeB, nodeC, 18);
var edge5 = new Edge(nodeC, nodeD, 3);
var edge6 = new Edge(nodeB, nodeE, 10);
var edge7 = new Edge(nodeC, nodeF, 1);
var edge8 = new Edge(nodeD, nodeF, 5);
var edge9 = new Edge(nodeE, nodeG, 21);
var edge10 = new Edge(nodeF, nodeG, 9);
var edges = new[] { edge1, edge2, edge3, edge4, edge5, edge6, edge7, edge8, edge9, edge10, };

var dijkstra = new Dijkstra(nodes, edges);
var result = dijkstra.Solve();

Console.WriteLine($"TotalCost: {result.TotalCost}");
Console.WriteLine($"ShortestRoute: {result.Route}");
Console.WriteLine($"");
Console.WriteLine($"　┌───{EdgeString(edge1)}─{NodeString(nodeB)}─{EdgeString(edge6)}─{NodeString(nodeE)}─{EdgeString(edge9)}─┐");
Console.WriteLine($"　│         │                │");
Console.WriteLine($"　│        {EdgeString(edge4)}                │");
Console.WriteLine($"　│         │                │");
Console.WriteLine($"{NodeString(nodeA)}─{EdgeString(edge2)}─{NodeString(nodeC)}─{EdgeString(edge7)}──┐    {NodeString(nodeG)}");
Console.WriteLine($"　│         │        │       │");
Console.WriteLine($"　│        {EdgeString(edge5)}        │       │");
Console.WriteLine($"　│         │        │       │");
Console.WriteLine($"　└───{EdgeString(edge3)}─{NodeString(nodeD)}─{EdgeString(edge8)}─{NodeString(nodeF)}─{EdgeString(edge10)}─┘");

string NodeString(Node node) => $"[{node.Name}{node.TotalCost,3}]";

string EdgeString(Edge edge) => $"{edge.Cost,2}";
