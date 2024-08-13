namespace DataStructures.Linear.DoubleLinkedList;

public sealed class Node<T>
{
    public required T Value { get; set; }
    public Node<T>? Next { get; set; }
    public Node<T>? Previous { get; set; }
}

public sealed class LinkedList<T>
{
    public Node<T>? First { get; set; }
}