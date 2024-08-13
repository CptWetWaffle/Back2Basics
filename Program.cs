
Console.WriteLine("Hello, World!");
var list = new DataStructures.Linear.SingleLinkedList.LinkedList<int>([1, 2, 3, 4]);

Console.WriteLine(list.Print());
list.Reverse();
Console.WriteLine(list.Print());
list.Swap(2, 4);
Console.WriteLine(list.Print());
list.Remove(3);
Console.WriteLine(list.Print());
Console.WriteLine(list.GetIterativeLength());
Console.WriteLine(list.GetRecursiveLength());